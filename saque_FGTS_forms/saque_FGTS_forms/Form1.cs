using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using saque_library;

namespace saque_FGTS_forms
{
    public partial class frmForm1 : Form
    {
        public frmForm1()
        {
            InitializeComponent();

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //se nenhuma das text box forem preenchidas, ou forem preenchidas com letras, o erro será tratado
            if (string.IsNullOrEmpty(txtSaldoHJ.Text) || string.IsNullOrEmpty(txtTaxaAM.Text) || txtSaldoHJ.Text.All(char.IsLetter) || txtTaxaAM.Text.All(char.IsLetter))
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
            }
            else
            {
                //limpa todas as listas para inserir novos valores
                lstSaques.Items.Clear();
                lstData.Items.Clear();
                lstSaldoDev.Items.Clear();
                lstSaqueAut.Items.Clear();
                lstDias.Items.Clear();
                lstDesagio.Items.Clear();
                lstVP.Items.Clear();
                lstAmortizado.Items.Clear();
                lstIOFBas.Items.Clear();
                lstJuros.Items.Clear();
                lstIOFtotal.Items.Clear();
                lstIOFflat.Items.Clear();

                //tranforma o saldo de string para double
                string saldoStr = txtSaldoHJ.Text;
                double saldo = Convert.ToDouble(saldoStr);

                //pega os valores dos dateTimePicker do dia de hoje e do dia do primeiro saque
                DateTime dataHJ = dtpHJ.Value;
                DateTime dataFut = dtpPrimSaq.Value;

                //pega a taxa ao mês, converte em double e divíde por 100 para funcionar corretamente como porcentagem
                string taxaAMstr = txtTaxaAM.Text;
                double taxaAM = Convert.ToDouble(taxaAMstr);
                taxaAM = taxaAM / 100.0;

                //as funções calculam a taxa ao ano e a taxa ao dia
                double taxaAA = fgts.taxaAA(taxaAM);
                double taxaAD = fgts.taxaAD(taxaAA);

                //define as variáveis a serem incrementadas ao longo do código
                double totalSaque = 0, totalAmortizado = 0, vpBruto = 0, iofBas_total = 0, jurosTot = 0, iof_tot = 0, iofAdd_tot = 0;
                //saldo que será reduzido pelo amortizado
                double saldoDevedor = saldo;


                //labels que mostram as taxas ao ano e ao dia
                lblTaxaAResult.Text = ((Math.Round((taxaAA * 100), 2, MidpointRounding.ToEven)) + "%");
                lblTaxaDResult.Text = ((Math.Round((taxaAD * 100), 2, MidpointRounding.ToEven)) + "%");

                //variável que recebe função que calcula o IOF baseado no valor inserido, para depois aplicar no main o valor em que o IOF não atrapalhará, podendo então sacar exatamente o valor desejado
                double saqueVdd = fgts.Saque_verdadeiro(saldo, dataHJ, dataFut, taxaAM, taxaAD, saldoDevedor);
                //mantem o valor incial do saldo verdadeiro para fazer alguns calculos dentro do for
                double saqueVddIni = saqueVdd;

                

                //enquanto o saldo verdadeiro for maior do que zero
                for (int i = 1; i <= 5; i++)
                {
                    //lista que atualiza o valor do saldo
                    lstSaldoDev.Items.Add(("R$ " + (Math.Round(saqueVdd, 2, MidpointRounding.ToEven))));
                    
                    

                    //calcula o número de dias entre o primeiro saque e os próximos anos
                    double dc = fgts.Dias(dataHJ, dataFut);
                    //calcula o desagio
                    double desagio = fgts.Desagio(taxaAD, dc);

                    //calcula o saque autorizado e depois incrementa para ter um total em uma label
                    double saque = fgts.saque_calculo(saqueVdd);


                    //calcula o valor presente
                    double valorPresente = fgts.ValorPresente(saque, desagio);
                    

                    //calcula juros e incrementa os juros totais
                    double juros = fgts.Juros(saque, valorPresente);
                    jurosTot = fgts.Juros_total(juros, jurosTot);

                    //calcula o amortizado baseado na diferença entre saque e o juros e depois incrementa para mostrar o total em uma label
                    double amortizado = fgts.Amortizado(saque, juros);

                    //Retira o valor do amortizdo do saldo 
                    saqueVdd = fgts.Saldo_devedor(saqueVdd, saque);

                    //calcula o IOF básico e depois aplica na função de incremento para o total
                    double iofBas = fgts.IOF_basico(dc, valorPresente);
                    iofBas_total = fgts.IOF_basico_total(iofBas, iofBas_total);

                    //iof adicional à ser somado no final com IOF básico total. Recebe o valor verdadeiro.
                    double iofAdd = fgts.IOF_adicional(valorPresente);
                    iofAdd_tot += iofAdd;

                    //calcula o IOF total
                    double iofVdd = fgts.IOF_total(dc, valorPresente);
                    iof_tot += iofVdd;
                    valorPresente -= iofVdd;

                    //calcula o total do valor presente
                    vpBruto = fgts.VpBruto(valorPresente, vpBruto);

                    //se saldo verdadeiro for menor que 500 (ou qualquer número) ele saca todo aquele valor restante
                    /*if (saqueVdd < 100)
                    {
                        saque = saqueVdd;
                        amortizado = saque;
                        saqueVdd = 0;

                    }*/


                    //incrementa nos valores de saque e amortizado para mostrar a soma total
                    totalSaque = fgts.TotalSaque(saque, totalSaque);
                    totalAmortizado = fgts.Amortizado_total(amortizado, totalAmortizado);

                    //mostra nas listas os valores dos saques autorizados e do número de saques feitos
                    lstSaqueAut.Items.Add(("R$ " + (Math.Round(saque, 2, MidpointRounding.ToEven))));
                    lstSaques.Items.Add(i + "º Saque");

                    //atualiza as listas com seus respectivos valores
                    lstAmortizado.Items.Add(("R$ " + (Math.Round(amortizado, 2, MidpointRounding.ToEven))));
                    lstIOFtotal.Items.Add(("R$ " + (Math.Round(iofVdd, 2, MidpointRounding.ToEven))));
                    lstIOFflat.Items.Add(("R$ " + (Math.Round(iofAdd, 2, MidpointRounding.ToEven))));
                    lstJuros.Items.Add(("R$ " + Math.Round(juros, 2, MidpointRounding.ToEven)));
                    lstIOFBas.Items.Add(("R$ " + Math.Round(iofBas, 2, MidpointRounding.ToEven)));
                    lstData.Items.Add(dataFut.ToShortDateString());
                    lstDias.Items.Add(dc);
                    lstDesagio.Items.Add(Math.Round(desagio, 6, MidpointRounding.ToEven));
                    lstVP.Items.Add(("R$ " + (Math.Round(valorPresente, 2, MidpointRounding.ToEven))));

                    //aumenta a data em 1 ano
                    dataFut = fgts.Data_fut_mais1A(dataFut);

                }
                
                //calcula o saque verdadeiro do valor, que seria tirando o IOF. O total da o mesmo valor que foi digitado na textBox do saldo
                double totalSemIOF = totalAmortizado - iof_tot;
                //calculo do valor liquido
                double valorLiq = fgts.ValorLiq(vpBruto, iof_tot);

                //mostra nas labels os valores das respectivas variáveis
                lblJurosTot.Text = ("R$ " + (Math.Round(jurosTot, 2, MidpointRounding.ToEven)).ToString());
                lblTotalAmo.Text = ("R$ " + (Math.Round(totalAmortizado, 2, MidpointRounding.ToEven)).ToString());
                
                lblTotalFlat.Text = ("R$ " + (Math.Round(iofAdd_tot, 2, MidpointRounding.ToEven)).ToString());
                lblIOFBasTotal.Text = ("R$ " + (Math.Round(iofBas_total, 2, MidpointRounding.ToEven)).ToString());
                lblIOF.Text = ("R$ " + (Math.Round(iof_tot, 2, MidpointRounding.ToEven)).ToString());
                lblTotalSaque.Text = ("R$ " + (Math.Round(totalSaque, 2, MidpointRounding.ToEven)).ToString());
                lblVPbruto.Text = ("R$ " + (Math.Round(vpBruto, 2, MidpointRounding.ToEven)).ToString());
                //lblLiquido.Text = ("R$ " + (Math.Round(valorLiq, 2, MidpointRounding.ToEven)).ToString());


            }
        }

       
    }
}
