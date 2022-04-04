using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using saque_library;

namespace saque_FGTS_forms
{
    public partial class frmForm1 : Form
    {
        public frmForm1()
        {
            InitializeComponent();

        }

        string jsonFGTS;
        string jsonFluxo;
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //se nenhuma das text box forem preenchidas, ou forem preenchidas com letras, o erro será tratado
            if (string.IsNullOrEmpty(txtSaldoHJ.Text) || string.IsNullOrEmpty(txtTaxaAM.Text) || txtSaldoHJ.Text.All(char.IsLetter) || txtTaxaAM.Text.All(char.IsLetter) || string.IsNullOrEmpty(txtPrazo.Text))
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
               

                //pega os valores dos dateTimePicker do dia de hoje e do dia do primeiro saque
                string dataHJstr = dtpHJ.Value.ToString("yyyy-MM-dd");
                
               
                string dataFutstr = dtpPrimSaq.Value.ToString("yyyy-MM-dd");
                

                //pega a taxa ao mês, converte em double e divíde por 100 para funcionar corretamente como porcentagem
                string taxaAMstr = txtTaxaAM.Text.Replace(',', '.');

                string Base = txtBase.Text;
                string TAC = txtTAC.Text, iof_dia = txtTaxaIOFBas.Text.Replace(',','.'), iof_flat = txtTaxaIofFlat.Text.Replace(',', '.');

                string quantidadeParcelas_str = txtPrazo.Text;

                string jsonEntrada = "{\n\"TYPE\":\"FLUXO\",\n";
                jsonEntrada += "\"TAXA%_MENSAL\":" + taxaAMstr + ",\n";
                jsonEntrada += "\"TAC_VALOR\":" + TAC + ",\n";
                jsonEntrada += "\"BASE\":" + Base + ",\n";
                jsonEntrada += "\"QTD_PARCELAS\":" + quantidadeParcelas_str + ",\n";
                jsonEntrada += "\"DATA_CALCULO\":\"" + dataHJstr + "\",\n";
                jsonEntrada += "\"DATA_INICIOPGTO\":\"" + dataFutstr + "\",\n";
                jsonEntrada += "\"TOTALFINANCIADO_VALOR\":" + saldoStr + ",\n";
                jsonEntrada += "\"TAXA_IOF_DIA\":" + iof_dia + ",\n";
                jsonEntrada += "\"TAXA_IOF_FLAT\":" + iof_flat;
                jsonEntrada += "}\n";


                

                richTextBox1.Clear();
                richTextBox1.AppendText(jsonEntrada);


                jsonFGTS = fgts.JSON_FGTS(jsonEntrada);
                jsonFluxo = fgts.FGTS_FLUXO(jsonFGTS);

               // string jsonRes = fgts.Resgate_json(jsonEntrada, jsonEntradaRes);

    
                richTextBoxInput.Clear();
                richTextBoxInput.AppendText(jsonFGTS);

                richTextBoxOutPut.Clear();
                richTextBoxOutPut.AppendText(jsonFluxo);

                Dictionary<string, Object> listJson = RecieveJson.RecebeJson(jsonFluxo);

                string[] tabelaArray = RecieveJson.CalculoFluxo(listJson, "TABELA_FLUXO_PARCELAS");

                

                
                //richTextBoxOutPut.AppendText(string.Join(" ", tabelaArray));

                List<string> parcelaList = RecieveJson.ListaParcela(tabelaArray);
                List<string> dataParcelaList = RecieveJson.ListaDataParcela(tabelaArray);
                List<string> dcList = RecieveJson.ListaDc(tabelaArray);
                List<string> valorParcelaList = RecieveJson.ListaValorParcela(tabelaArray);
                List<string> jurosValorList = RecieveJson.ListaJurosValor(tabelaArray);
                List<string> amortizadoValorList = RecieveJson.ListaAmortizadoValor(tabelaArray);
                List<string> iofTotalValor = RecieveJson.ListaIofTotalValor(tabelaArray);
                List<string> dividaSaldoDevedorList = RecieveJson.ListaDividaSaldoDevedor(tabelaArray);
                
                List<string> iofBasicoList = RecieveJson.ListaIofBasico(tabelaArray);
                List<string> iofFlatList = RecieveJson.ListaIofFlat(tabelaArray);
                List<string> desagioList = RecieveJson.ListaDesagio(tabelaArray);
                List<string> valorPresenteList = RecieveJson.ListaValorPresente(tabelaArray);



                string vpBruto = RecieveJson.valorVPbruto(listJson);
                lblVPbruto.Text = ("R$ " + vpBruto);

                string tac = RecieveJson.valorTAC(listJson);
                lblTac.Text = ("R$ " + tac);

                string iof_total = RecieveJson.valorIOFtotal(listJson);
                lblIOF.Text = ("R$ " + iof_total);

                string totalAmortizado = RecieveJson.valorAmortizadoTotal(listJson);
                lblTotalAmo.Text = ("R$ " + totalAmortizado);

                string totalSaque = RecieveJson.valorSaqueTotal(listJson);
                lblTotalSaque.Text = ("R$ " + totalSaque);

                string iofBas_total = RecieveJson.valorIOfBasicoTotal(listJson);
                lblIOFBasTotal.Text = ("R$ " + iofBas_total);

                string iofAdd_tot = RecieveJson.valorIofFlatTotal(listJson);
                lblTotalFlat.Text = ("R$ " + iofAdd_tot);

                string valorLiq = RecieveJson.valorVPliquido(listJson);
                lblLiquido.Text = ("R$ " + valorLiq);

                string jurosTot = RecieveJson.valorJurosTotal(listJson);
                lblJurosTot.Text = ("R$ " + jurosTot);

                string taxaAD = RecieveJson.valorTaxaDia(listJson);
                lblTaxaDResult.Text = (taxaAD);


                string TjaAnual = RecieveJson.valorTjaAnual(listJson);
                lblTaxaAResult.Text = (TjaAnual + "%");



                listasForms(parcelaList, dataParcelaList, dcList, valorParcelaList, jurosValorList, amortizadoValorList, iofTotalValor, dividaSaldoDevedorList, iofBasicoList, iofFlatList, desagioList, valorPresenteList, 
                    lstSaques, lstData, lstDias, lstSaqueAut, lstJuros, lstAmortizado, lstIOFtotal, lstSaldoDev, lstIOFBas, lstIOFflat, lstDesagio, lstVP);

            }
        }

        public static void listasForms(List<string> parcelaList, List<string> dataParcelaList, List<string> dcList, List<string> valorParcelaList, List<string> jurosValorList, List<string> amortizadoValorList, List<string> iofTotalValor, 
            List<string> dividaSaldoDevedorList, List<string> iofBasicoList, List<string> iofFlatList, List<string> desagioList, List<string> valorPresenteList, 
            ListBox lstSaques, ListBox lstData, ListBox lstDias, ListBox lstSaqueAut, ListBox lstJuros, ListBox lstAmortizado, ListBox lstIOFtotal, ListBox lstSaldoDev, ListBox lstIOFBas, ListBox lstIOFflat, ListBox lstDesagio, ListBox lstVP)
        {
            foreach (var item in parcelaList)
            {
                lstSaques.Items.Add(item + "º Saque");
            }

            foreach (var item in dataParcelaList)
            {
                lstData.Items.Add(item);
            }

            foreach (var item in dcList)
            {
                lstDias.Items.Add(item);
            }

            foreach (var item in valorParcelaList)
            {
                lstSaqueAut.Items.Add(("R$ " + item));
            }

            foreach (var item in jurosValorList)
            {
                lstJuros.Items.Add(("R$ " + item));
            }

            foreach (var item in amortizadoValorList)
            {
                lstAmortizado.Items.Add(("R$ " + item));
            }

            foreach (var item in iofTotalValor)
            {
                lstIOFtotal.Items.Add(("R$ " + item));
            }

            foreach (var item in dividaSaldoDevedorList)
            {
                lstSaldoDev.Items.Add(("R$ " + item));
            }

            foreach (var item in iofBasicoList)
            {
                lstIOFBas.Items.Add("R$ " + item);
            }

            foreach (var item in iofFlatList)
            {
                lstIOFflat.Items.Add("R$ " + item);
            }

            foreach (var item in desagioList)
            {
                lstDesagio.Items.Add(item);
            }

            foreach (var item in valorPresenteList)
            {
                lstVP.Items.Add("R$ " + item);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string juroMoraAMStr = txtJurosMora.Text.Replace(',', '.');
            string taxaMulta = txtMulta.Text.Replace(',', '.');

            string dataPagStr = dtpPrimPag.Value.ToString("yyyy-MM-dd");
            string parcelas = txtParcelas.Text;

            string quantidadeParcelas_str = txtPrazo.Text;
            Dictionary<string, Object> listJsonRes = RecieveJson.RecebeJson(jsonFluxo);

            string jsonEntradaRes = "{\n\"TYPE\":\"RESGATE\",\n";
            jsonEntradaRes += "\"DATA_CALCULO\":\"" + dataPagStr + "\",\n";
            jsonEntradaRes += "\"%JUROSMORA\":\"" + juroMoraAMStr + "\",\n";
            jsonEntradaRes += "\"VALORMULTA\":\"" + taxaMulta + "\",\n";
            jsonEntradaRes += "\"QTD_PARCELAS\":" + quantidadeParcelas_str + ",\n";
            jsonEntradaRes += "\"PARCELAS\":";
            jsonEntradaRes += "[ \n";

            jsonEntradaRes += parcelas;

            jsonEntradaRes += "],\n";
            jsonEntradaRes += "\"TABELA_FLUXO_PARCELAS\":";

            jsonEntradaRes += listJsonRes["TABELA_FLUXO_PARCELAS"].ToString();

            jsonEntradaRes += "}\n";

            string resgate = fgts.Resgate_verdadeiro(jsonEntradaRes);

            richTextBox2.Clear();
            richTextBox2.AppendText(resgate);
        }

    }
}
        
