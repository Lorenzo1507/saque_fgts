using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (string.IsNullOrEmpty(txtSaldoHJ.Text) || string.IsNullOrEmpty(txtTaxaAM.Text) || txtSaldoHJ.Text.All(char.IsLetter) || txtTaxaAM.Text.All(char.IsLetter))
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
            }
            else
            {
                lstSaques.Items.Clear();
                lstData.Items.Clear();
                lstSaldoAntes.Items.Clear();
                lstSaqueAut.Items.Clear();
                lstDias.Items.Clear();
                lstDesagio.Items.Clear();
                lstVP.Items.Clear();

                string saldoStr = txtSaldoHJ.Text;
                double saldo = Convert.ToDouble(saldoStr);

                string dataHJ = dtpHJ.Value.ToShortDateString();
                string dataFut = dtpPrimSaq.Value.ToShortDateString();

                string taxaAMstr = txtTaxaAM.Text;
                double taxaAM = Convert.ToDouble(taxaAMstr);
                taxaAM = taxaAM / 100;

                double totalSaque = 0;
                valor_presente(saldo, taxaAM, dataHJ, dataFut, lstData, lstDias, lstDesagio, lstVP, lblVPbruto, lblIOF, lblLiquido, lblTaxaAResult, lblTaxaDResult);

                for (int i = 1; i <= 5; i++)
                {
                    lstSaldoAntes.Items.Add(("R$ " + (Math.Round(saldo, 2, MidpointRounding.ToEven))));

                    double saque = saque_calculo(saldo);
                    saldo = saldo - saque;
                    totalSaque += saque;

                    lstSaqueAut.Items.Add(("R$ " + (Math.Round(saque, 2, MidpointRounding.ToEven))));
                    lstSaques.Items.Add(i + "º Saque");

                }

                lblTotalSaque.Text = ("R$ " + (Math.Round(totalSaque, 2, MidpointRounding.ToEven)).ToString());
            }
        }


        


        public static void valor_presente(double saldo, double taxaAM, string dataH, string dataFut, ListBox lstData, ListBox lstDias, ListBox lstDesagio, ListBox lstVP, Label lblVPbruto, Label lblIOF, Label lblLiquido, Label lblTaxaAResult, Label lblTaxaDResult)
        {
            DateTime dataHJ = Convert.ToDateTime(dataH);
            DateTime data_fut = Convert.ToDateTime(dataFut);

            double taxaAA = Math.Pow((1 + taxaAM), (365.0 / 30.0)) - 1;
            lblTaxaAResult.Text = ((Math.Round((taxaAA * 100), 2, MidpointRounding.ToEven)).ToString() + "%");

            double taxaAD = Math.Pow((1 + taxaAA), (1.0 / 365.0)) - 1;
            lblTaxaDResult.Text = ((Math.Round((taxaAD * 100), 2, MidpointRounding.ToEven)).ToString() + "%");

            double IOF = 0, IOF_tot = 0, vpBruto = 0, valorLiq = 0;


            for (int i = 1; i <= 5; i++)
            {
                //pega os valores do saque
                double saque_aut = saque_calculo(saldo);
                //atualiza os valores do saque
                saldo = saldo - saque_aut;

                //calcula a diferença de dias
                double dc = (data_fut - dataHJ).Days;

                //eleva (1+taxaAM) por dc
                double desagio = Math.Pow((1 + taxaAD), dc);

                double valorPresente = (saque_aut) / (desagio);

                if (dc < 365)
                {
                    IOF = dc * valorPresente * 0.000082;
                    IOF_tot += IOF;
                }
                else
                {
                    IOF = 0.03 * valorPresente;
                    IOF_tot += IOF;
                }

                vpBruto += valorPresente;


                lstData.Items.Add(data_fut);
                lstDias.Items.Add(dc);
                lstDesagio.Items.Add(Math.Round(desagio, 6, MidpointRounding.ToEven));
                lstVP.Items.Add(("R$ " + (Math.Round(valorPresente, 2, MidpointRounding.ToEven))));

                data_fut = data_fut.AddYears(1);
            }

            valorLiq = vpBruto - IOF_tot; 

            lblVPbruto.Text = ("R$ " + (Math.Round(vpBruto, 2, MidpointRounding.ToEven)).ToString());
            lblIOF.Text = ("R$ " + (Math.Round(IOF_tot, 2, MidpointRounding.ToEven)).ToString());
            lblLiquido.Text = ("R$ " + (Math.Round(valorLiq, 2, MidpointRounding.ToEven)).ToString());




        }


        public static double saque_calculo(double saldo)
        {

            double saque = 0;

            if (saldo > 20000)
            {
                saque = (saldo * 0.05) + 2900.0;
            }

            else
            {
                if (saldo > 15000)
                {
                    saque = (saldo * 0.1) + 1900.0;
                }
                else
                {
                    if (saldo > 10000)
                    {
                        saque = (saldo * 0.15) + 1150.0;
                    }
                    else
                    {
                        if (saldo > 5000)
                        {
                            saque = (saldo * 0.2) + 650.0;
                        }
                        else
                        {
                            if (saldo > 1000)
                            {
                                saque = (saldo * 0.3) + 150.0;
                            }
                            else
                            {
                                if (saldo > 500)
                                {
                                    saque = (saldo * 0.4) + 50.0;
                                }
                                else
                                {
                                    saque = saldo * 0.5;
                                }
                            }
                        }
                    }
                }
            }

            return saque;

        }

      
    }
}
