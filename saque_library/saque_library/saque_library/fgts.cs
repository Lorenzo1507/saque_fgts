using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

namespace saque_library
{
    public class fgts
    {
        public static double TaxaAA(double taxaAM)
        {
            //double taxaAA = Math.Pow((1.0 + taxaAM), (365.0 / 30.0)) - 1.0;
            double taxaAA = Math.Pow((1.0 + taxaAM), 12.0) - 1.0;

            return taxaAA;
        }

        public static double TaxaAD(double taxaAA)
        {
            double taxaAD = Math.Pow((1.0 + taxaAA), (1.0 / 365.0)) - 1.0;

            return taxaAD;
        }
        public static double Dias(DateTime dataH, DateTime dataFut)
        {
            DateTime dataHJ = dataH;
            DateTime data_fut = dataFut;

            //calcula a diferença de dias
            double dc = (data_fut - dataHJ).Days;
            return dc;
        }

        //fator de desconto
        public static double Desagio(double taxaAA, double dc)
        {
            /*if(dc < 0)
            {
                dc *= -1;
            }*/

            double desagio = Math.Pow((1.0 + taxaAA), (dc/365.0));

            return desagio;
        }

        public static double ValorPresente(double saque_aut, double desagio)
        {
            double valorPresente = (saque_aut) / (desagio);

            return valorPresente;
        }

        public static double VpBruto(double valorPresente, double vpBruto)
        {
            double vp_bruto = vpBruto;
            vp_bruto += valorPresente;

            return vp_bruto;
        }

        public static double TotalSaque(double saque, double totalSaque)
        {
            double total_saque = totalSaque;
            total_saque += saque;

            return total_saque;
        }

        public static DateTime Data_fut_mais1A(DateTime dataFut)
        {
            dataFut = dataFut.AddYears(1);

            return dataFut;
        }

        public static DateTime Data_fut_mais1M(DateTime dataFut)
        {
            dataFut = dataFut.AddMonths(1);

            return dataFut;
        }



        public static double ValorLiq(double vpBruto, double IOF_tot, double tac)
        {
            double valorLiq = vpBruto - IOF_tot - tac;

            return valorLiq;
        }

        public static double saque_calculo(double saldo)
        {

            double saque = 0;

            if (saldo > 20000)
            {
                saque = (saldo * 0.05) + 2900;
            }

            else
            {
                if (saldo > 15000)
                {
                    saque = (saldo * 0.1) + 1900;
                }
                else
                {
                    if (saldo > 10000)
                    {
                        saque = (saldo * 0.15) + 1150;
                    }
                    else
                    {
                        if (saldo > 5000)
                        {
                            saque = (saldo * 0.2) + 650;
                        }
                        else
                        {
                            if (saldo > 1000)
                            {
                                saque = (saldo * 0.3) + 150;
                            }
                            else
                            {
                                if (saldo > 500)
                                {
                                    saque = (saldo * 0.4) + 50;
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

        //função que faz o mesmo que o main, porém irá retornar o valor exato que o desejado, sem considerar o IOF daquele valor (se formos tirar um valor de 15000
        public static double Saque_verdadeiro(double saldo, double saldoDevedor, DateTime dataHJ, DateTime dataFut, double taxaAM, double iof_dia, double iof_flat, double TAC, int quantidadeParcelas)
        {
            double taxaAA = TaxaAA(taxaAM);


            double totalSaque = 0, totalAmortizado = 0, vpBruto = 0, jurosTot = 0, iof_tot = 0;

            for (int i = 1; i <= quantidadeParcelas; i++)
            {

                //calcula o número de dias entre o primeiro saque e os próximos anos
                double dc = Dias(dataHJ, dataFut);
                //calcula o desagio
                double desagio = Desagio(taxaAA, dc);

                //calcula o saque autorizado e depois incrementa para ter um total em uma label
                double saque = saque_calculo(saldoDevedor);


                //calcula o valor presente
                double valorPresente = ValorPresente(saque, desagio);
                //calcula o total do valor presente
                vpBruto = VpBruto(valorPresente, vpBruto);

                //calcula juros e incrementa os juros totais
                double juros = fgts.Juros(saque, valorPresente);
                jurosTot = Juros_total(juros, jurosTot);

                //calcula o amortizado baseado na diferença entre saque e o juros e depois incrementa para mostrar o total em uma label
                double amortizado = Amortizado(saque, juros);

                //Retira o valor do amortizdo do saldo 
                saldoDevedor = Saldo_devedor(saldoDevedor, saque);

                //calcula o IOF básico e depois aplica na função de incremento para o total
                double iofBas = IOF_basico(dc, valorPresente, iof_dia);


                //iof adicional à ser somado no final com IOF básico total. Recebe o valor verdadeiro.
                double iofAdd = IOF_adicional(valorPresente, iof_flat);


                //calcula o IOF total
                double iofVdd = IOF_verdadeiro(dc, valorPresente, iof_dia, iof_flat);
                iof_tot += iofVdd;


                //se saldo verdadeiro for menor que 500 (ou qualquer número) ele saca todo aquele valor restante
                /*if (saqueVdd < 100)
                {
                    saque = saqueVdd;
                    amortizado = saque;
                    saqueVdd = 0;

                }*/


                //incrementa nos valores de saque e amortizado para mostrar a soma total
                totalSaque = TotalSaque(saque, totalSaque);
                totalAmortizado = Amortizado_total(amortizado, totalAmortizado);

                dataFut = Data_fut_mais1A(dataFut);
            }

            return saldo + iof_tot + jurosTot + TAC;
        }

        public static double Juros(double saque_aut, double valorPresente)
        {
            //double juros = taxaAM * saldo;
            double juros = saque_aut - valorPresente;
            //para não dar juros com valores de 30 casas decimais
            if (juros < 0)
            {
                juros = 0;
            }
            return juros;
        }

        public static double Amortizado(double saque, double juros)
        {
            double amortizado = saque - juros;
            return amortizado;
        }

        //Em vez de simplesmente subtrair o saldo, devemos utilizar o amortizado para aparecer na tabela saldo anterior
        public static double Saldo_devedor(double saldo, double saque)
        {
            double saldo_antes = saldo - saque;

            if (saldo_antes <= 0)
            {
                saldo_antes = 0;
                return saldo_antes;
            }

            return saldo_antes;
        }
        //calcula iof basico
        public static double IOF_basico(double dc, double valorPresente, double iof_dia)
        {
            double IOF_basico = 0;
            if (dc < 365)
            {
                //iof dia é a taxa do iof basico
                IOF_basico = dc * (iof_dia / 365.0) * valorPresente;
            }
            else
            {
                IOF_basico = valorPresente * iof_dia;
            }

            if (IOF_basico < 0.0)
            {
                IOF_basico = 0.0;
            }
            return IOF_basico;
        }
        //faz o incremento para calcular o total do iof básico
        public static double IOF_basico_total(double iof_basico, double iofB_total)
        {
            iofB_total += iof_basico;

            return iofB_total;
        }
        //calcula o iof adicional 
        public static double IOF_adicional(double valorPresente, double iof_flat)
        {
            //iof flat é a taxa do iof adicional
            double iofAdd = valorPresente * iof_flat;
            if (iofAdd < 0)
            {
                iofAdd = 0;
            }
            return iofAdd;
        }

        public static double IOF_adicionalTotal(double iofAdd, double iofAdd_total)
        {
            iofAdd_total += iofAdd;
            return iofAdd_total;
        }
        //calcula o IOF total
        public static double IOF_verdadeiro(double dc, double valorPresente, double iof_dia, double iof_flat)
        {

            double iof_basico = IOF_basico(dc, valorPresente, iof_dia);

            double iof_adicional = IOF_adicional(valorPresente, iof_flat);

            double iofTotal = iof_basico + iof_adicional;

            if (iofTotal < 0)
            {
                iofTotal = 0;
            }

            return iofTotal;
        }

        public static double IOF_verdadeiroTotal(double iofVdd, double iof_tot)
        {
            iof_tot += iofVdd;
            return iof_tot;
        }

        public static double Juros_total(double juros, double jurosTot)
        {
            jurosTot += juros;
            return jurosTot;
        }

        public static double Amortizado_total(double amortizado, double totalAmortizado)
        {
            totalAmortizado += amortizado;
            return totalAmortizado;
        }

        public static double RoundDown(double value, double digits)
        {
            double factor = Math.Pow(10, digits);

            return Math.Truncate(value * factor) / factor;
        }

        //FÓRMULAS RESGATE
        public static double JurosMoraAD(double jurosMoraAM)
        {
            double jurosMoraAD = jurosMoraAM / 30;
            if (jurosMoraAD < 0)
            {
                jurosMoraAD = 0;
            }
            return jurosMoraAD;
        }

        public static double JurosMora(string saqueVddStr, double jurosMoraAD, double dc)
        {
            saqueVddStr = saqueVddStr.Replace('.', ',');
            double saqueVdd = Convert.ToDouble(saqueVddStr);

            double jurosMora = saqueVdd * (jurosMoraAD * (dc * (-1)));
            if (jurosMora < 0)
            {
                jurosMora = 0;
            }

            return jurosMora;
        }

        public static double Mora_DC_porc(double jurosMoraAD, double dc)
        {
            double mora_dc = jurosMoraAD * (dc * (-1));
            if (mora_dc < 0)
            {
                mora_dc = 0;
            }

            return mora_dc;
        }

        public static double Multa(string saldoAtrasoStr, double taxaMulta)
        {
            saldoAtrasoStr = saldoAtrasoStr.Replace('.', ',');
            double saldoAtraso = Convert.ToDouble(saldoAtrasoStr);

            double valorMulta = saldoAtraso * taxaMulta;
            return valorMulta;
        }

       /* public static double Resgate_verdadeiro(double saldoAtraso,double jurosMora, double multa, double dc)
        {
            double saldoAtualizado = saldoAtraso + (multa + jurosMora);

            return saldoAtualizado;
        }*/
        public static string JSON_FGTS(string jsonEntrada)
        {
            Dictionary<string, Object> listJsonEntrada = RecieveJson.RecebeJson(jsonEntrada);

            string saldoStr = RecieveJson.valorTotalFinanciado(listJsonEntrada);

            //tranforma o saldo de string para double
            double saldo = Convert.ToDouble(saldoStr);

            //pega os valores dos dateTimePicker do dia de hoje e do dia do primeiro saque
            string dataHJstr = RecieveJson.valorDataCalculo(listJsonEntrada);
            DateTime dataHJ = Convert.ToDateTime(dataHJstr);
            //dataHJstr = dataHj.ToString("yyyy-MM-dd");

            string dataFutstr = RecieveJson.valorDataIniPagamento(listJsonEntrada);
            DateTime dataFut = Convert.ToDateTime(dataFutstr);

            string dataFutIni = dataFutstr;

            string taxaAMstr = RecieveJson.valorTaxaMensal(listJsonEntrada);

            //pega a taxa ao mês, converte em double e divíde por 100 para funcionar corretamente como porcentagem
            double taxaAM = Convert.ToDouble(taxaAMstr);
            taxaAM = RoundDown(taxaAM, 6);
            taxaAM = taxaAM / 100.0;

            //as funções calculam a taxa ao ano e a taxa ao dia
            double taxaAA = TaxaAA(taxaAM);
            taxaAA = RoundDown(taxaAA, 6);

            double taxaAD = TaxaAD(taxaAA);
            taxaAD = RoundDown(taxaAD, 6);

            //saldo que será reduzido pelo amortizado
            double saldoDevedor = saldo;

            string quantidadeParcelas_str = RecieveJson.valorQtdParcelas(listJsonEntrada);
            int quantidadeParcelas = Convert.ToInt32(quantidadeParcelas_str);

            //troca "}" no fim do json por ","
            jsonEntrada = jsonEntrada.Replace('}',',');

            string json = jsonEntrada;
            string jsonTabela = null;

            string iof_flatStr = RecieveJson.valorTaxaIofFlat(listJsonEntrada);
            double iof_flat = Convert.ToDouble(iof_flatStr);
            iof_flatStr = iof_flatStr.Replace(',', '.');

            string iof_diaStr = RecieveJson.valorTaxaIofDia(listJsonEntrada);
            double iof_dia = Convert.ToDouble(iof_diaStr);
            iof_diaStr = iof_diaStr.Replace(',', '.');

            string tacStr = RecieveJson.valorTAC(listJsonEntrada);
            double TAC = Convert.ToDouble(tacStr);

            string baseStr = RecieveJson.valorBase(listJsonEntrada);
            int Base = Convert.ToInt32(baseStr);
            //variável que recebe função que calcula o IOF baseado no valor inserido, para depois aplicar no main o valor em que o IOF não atrapalhará, podendo então sacar exatamente o valor desejado
            double saqueVdd = fgts.Saque_verdadeiro(saldo, saldoDevedor, dataHJ, dataFut, taxaAM, iof_dia, iof_flat, TAC, quantidadeParcelas);
            //mantem o valor incial do saldo verdadeiro para fazer alguns calculos dentro do for
            double saqueVddIni = saqueVdd;

            //enquanto o saldo verdadeiro for maior do que zero
            for (int i = 1; i <= quantidadeParcelas; i++)
            {

                //calcula o número de dias entre o primeiro saque e os próximos anos
                double dc = fgts.Dias(dataHJ, dataFut);

                //calcula o saque autorizado e depois incrementa para ter um total em uma label
                double saque = fgts.saque_calculo(saqueVdd);


                jsonTabela += "{\"DATAVENCPARCELA\":\"" + dataFut.ToString("yyyy-MM-dd") + "\", \"DC\":" + dc.ToString() + ", \"PARCELA_VALOR\":" + saque.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "}, \n";

                saqueVdd = fgts.Saldo_devedor(saqueVdd, saque);

                //aumenta a data em 1 ano
                dataFut = fgts.Data_fut_mais1A(dataFut);

            }
            int indexTab = jsonTabela.LastIndexOf(',');
            jsonTabela = jsonTabela.Remove(indexTab, 1);

            json += "\"DIVIDA_SALDODEVEDOR_VALOR\":" + saqueVddIni.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"TABELA_FLUXO_PARCELAS\":";
            json += "[ \n";

            json += jsonTabela;

            json += "]\n";
            json += "}\n";

            return json;
        }

        public static string FGTS_FLUXO(string jsonFGTS)
        {
            Dictionary<string, Object> listJsonEntrada = RecieveJson.RecebeJson(jsonFGTS);

            string[] tabelaArray = RecieveJson.CalculoFluxo(listJsonEntrada, "TABELA_FLUXO_PARCELAS");

            List<string> listDataParcelas = RecieveJson.ListaDataParcela(tabelaArray);
            string[] arrayDataParcelas = listDataParcelas.ToArray();

            List<string> listDc = RecieveJson.ListaDc(tabelaArray);
            string[] arrayDc = listDc.ToArray();

            //pega os valores e jogam em um array para, depois troca todas os pontos entre os números, por vírgula, para não dar erro na conversão para double
            List<string> listValor = RecieveJson.ListaValorParcela(tabelaArray);
            string[] arrayValor = listValor.ToArray();
            arrayValor = arrayValor.Select(s => s.Replace(".", ",")).ToArray();

            string saqueVddStr = RecieveJson.valorDividaSaldoDevedor(listJsonEntrada);
            double saqueVdd = Convert.ToDouble(saqueVddStr);

            string saldoStr = RecieveJson.valorTotalFinanciado(listJsonEntrada);

            //tranforma o saldo de string para double
            double saldo = Convert.ToDouble(saldoStr);

            string taxaAMstr = RecieveJson.valorTaxaMensal(listJsonEntrada);

            //pega a taxa ao mês, converte em double e divíde por 100 para funcionar corretamente como porcentagem
            double taxaAM = Convert.ToDouble(taxaAMstr);

            taxaAM = taxaAM / 100.0;

            //as funções calculam a taxa ao ano e a taxa ao dia
            double taxaAA = fgts.TaxaAA(taxaAM);


            double taxaAD = fgts.TaxaAD(taxaAA);


            //define as variáveis a serem incrementadas ao longo do código
            double totalSaque = 0, totalAmortizado = 0, vpBruto = 0, iofBas_total = 0, jurosTot = 0, iof_tot = 0, iofAdd_tot = 0;
            //saldo que será reduzido pelo amortizado
            double saldoDevedor = saldo;

            string quantidadeParcelas_str = RecieveJson.valorQtdParcelas(listJsonEntrada);
            int quantidadeParcelas = Convert.ToInt32(quantidadeParcelas_str);

            //remove a tabela fluxo do json
            jsonFGTS = RecieveJson.RemoveItem(jsonFGTS, "TABELA_FLUXO_PARCELAS");
            // substitui 0 último "}" por vírgula
            jsonFGTS = RecieveJson.SubsEndByCom(jsonFGTS);

            string json = jsonFGTS;
            string jsonTabela = null;
            string jsonParc = null;

            string iof_flatStr = RecieveJson.valorTaxaIofFlat(listJsonEntrada);
            double iof_flat = Convert.ToDouble(iof_flatStr);
            iof_flatStr = iof_flatStr.Replace(',', '.');

            string iof_diaStr = RecieveJson.valorTaxaIofDia(listJsonEntrada);
            double iof_dia = Convert.ToDouble(iof_diaStr);
            iof_diaStr = iof_diaStr.Replace(',', '.');

            string tacStr = RecieveJson.valorTAC(listJsonEntrada);
            double TAC = Convert.ToDouble(tacStr);

            string baseStr = RecieveJson.valorBase(listJsonEntrada);
            int Base = Convert.ToInt32(baseStr);


            for (int i = 1; i <= quantidadeParcelas; i++)
            {
                double saque = Convert.ToDouble(arrayValor[i - 1]);
                double dc = Convert.ToDouble(arrayDc[i - 1]);
                string dataFut = arrayDataParcelas[i - 1];

                //calcula o desagio/fator de desconto/ taxa do período
                double desagio = fgts.Desagio(taxaAA, dc);


                //calcula o valor presente
                double valorPresente = fgts.ValorPresente(saque, desagio);


                //calcula juros e incrementa os juros totais
                double juros = fgts.Juros(saque, valorPresente);


                jurosTot = fgts.Juros_total(juros, jurosTot);


                //calcula o amortizado baseado na diferença entre saque e o juros e depois incrementa para mostrar o total em uma label
                double amortizado = fgts.Amortizado(saque, juros);


                //calcula o IOF básico e depois aplica na função de incremento para o total
                double iofBas = fgts.IOF_basico(dc, valorPresente, iof_dia);


                iofBas_total = fgts.IOF_basico_total(iofBas, iofBas_total);


                //iof adicional à ser somado no final com IOF básico total. Recebe o valor verdadeiro.
                double iofAdd = fgts.IOF_adicional(valorPresente, iof_flat);


                iofAdd_tot = fgts.IOF_adicionalTotal(iofAdd, iofAdd_tot);

                //calcula o IOF total
                double iofVdd = fgts.IOF_verdadeiro(dc, valorPresente, iof_dia, iof_flat);

                iof_tot = fgts.IOF_verdadeiroTotal(iofVdd, iof_tot);

                //calcula o total do valor presente
                vpBruto = fgts.VpBruto(valorPresente, vpBruto);


                jsonParc += "\"PARCELA" + i + "_VALOR\" :" + saque.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",\n";

                jsonTabela += "{\"PARCELA\" :" + i + ", \"DATAVENCPARCELA\":" + dataFut + ", \"DC\":" + dc.ToString() + ", \"PARCELA_VALOR\":" + saque.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"JUROS_VALOR\":" + juros.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"AMORTIZADO_VALOR\":" + amortizado.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"IOFTOTALPARCELA_VALOR\":" + iofVdd.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"DIVIDA_SALDODEVEDORATUALIZADO_VALOR\":" + saqueVdd.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"IOF_BASICO\":" + iofBas.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"IOF_FLAT\":" + iofAdd.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"DESAGIO\":" + desagio.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture) + ", \"VALOR_PRESENTE\":" + valorPresente.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "}, \n";


                saqueVdd = fgts.Saldo_devedor(saqueVdd, saque);

                //incrementa nos valores de saque e amortizado para mostrar a soma total
                totalSaque = fgts.TotalSaque(saque, totalSaque);
                totalAmortizado = fgts.Amortizado_total(amortizado, totalAmortizado);

            }
            //tira a últma vírgula antes de fechar o array
            int index = jsonTabela.LastIndexOf(',');
            jsonTabela = jsonTabela.Remove(index, 1);

            //calculo do valor liquido
            double valorLiq = fgts.ValorLiq(vpBruto, iof_tot, TAC);

            json += "\"TAXA%_ANUAL\":" + taxaAA.ToString("0.0000000", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"TAXA%_DIA\":" + taxaAD.ToString("0.0000000", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"TJA_MENSAL\":" + (taxaAM * 100).ToString("0.0000000", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"TJA_ANUAL\":" + (taxaAA * 100).ToString("0.0000000", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"%TAXACET_ANUAL\": \"00.0000000\",\n";
            json += "\"%TAXACET_MENSAL\": \"00.00000000000\",\n";

            json += jsonParc;

            json += "\"IOF_VALORTOTAL\":" + iof_tot.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"%IOFTOTAL_CET\": \"0.0\",\n";
            json += "\"%TAC_CET\": \"0.0\",\n";
            json += "\"VPLIQUIDO_VALORPRINCIPAL\":" + valorLiq.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"%VPLIQUIDO_VALORPRINCIPAL_CET\": \"00.00\",\n";
            json += "\"VALORJUROS_TOTALEMPRÉSTIMO\":" + jurosTot.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"TABELA_FLUXO_PARCELAS\":";
            json += "[ \n";

            json += jsonTabela;

            json += "],\n";
            json += "\"VALOR_BRUTO\":" + vpBruto.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"AMORTIZADO_TOTAL\":" + totalAmortizado.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"SAQUE_TOTAL\":" + totalSaque.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"IOF_BASICO_TOTAL\":" + iofBas_total.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture) + ",\n";
            json += "\"IOF_FLAT_TOTAL\":" + iofAdd_tot.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture) + "\n";
            json += "}\n";

            return json;
        }

        public static string Resgate_verdadeiro(string jsonEntradaRes)
        {
            Dictionary<string, Object> listJsonEntradaRes = RecieveJson.RecebeJson(jsonEntradaRes);

            string juroMoraAMStr = RecieveJson.valorTaxaJurosMora(listJsonEntradaRes);
            double jurosMoraAM = Convert.ToDouble(juroMoraAMStr);
            jurosMoraAM = jurosMoraAM / 100;

            double jurosMoraAD = fgts.JurosMoraAD(jurosMoraAM);

            string taxaMultaStr = RecieveJson.valorMulta(listJsonEntradaRes);
            double taxaMulta = Convert.ToDouble(taxaMultaStr);
            taxaMulta = taxaMulta / 100;

            string quantidadeParcelas_str = RecieveJson.valorQtdParcelas(listJsonEntradaRes);
            int quantidadeParcelas = Convert.ToInt32(quantidadeParcelas_str);

            //Data do pagamento convertida
            string dataPagStr = RecieveJson.valorDataCalculo(listJsonEntradaRes);
            DateTime dataPag = Convert.ToDateTime(dataPagStr);

            string[] arrayParcelas = RecieveJson.CalculoFluxo(listJsonEntradaRes, "PARCELAS");
            Array.Sort(arrayParcelas);


            string[] tabelaArray = RecieveJson.CalculoFluxo(listJsonEntradaRes, "TABELA_FLUXO_PARCELAS");
            //tabelaArray = tabelaArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            //Apaga a tabela fluxo e troca "}" por "," para dar continuidade no json
            jsonEntradaRes = RecieveJson.RemoveItem(jsonEntradaRes, "TABELA_FLUXO_PARCELAS");
            jsonEntradaRes = RecieveJson.SubsEndByCom(jsonEntradaRes);

            List<string> parcelaList = RecieveJson.ListaParcela(tabelaArray);
            string[] arrayParcJson = parcelaList.ToArray();

            //Datas do json extraidas para fazer o novo dc
            List<string> dataParcelaList = RecieveJson.ListaDataParcela(tabelaArray);
            string[] arrayData = dataParcelaList.ToArray();
            //Remove as aspas envolvendo a data
            arrayData = arrayData.Select(s => s.Replace("\"", string.Empty)).ToArray();
            arrayData = arrayData.Select(s => s.Replace(" ", string.Empty)).ToArray();

            List<string> dcList = RecieveJson.ListaDc(tabelaArray);
            string[] arrayDc = dcList.ToArray();

            List<string> valorParcelaList = RecieveJson.ListaValorParcela(tabelaArray);
            string[] arrayValorParc = valorParcelaList.ToArray();

            List<string> jurosValorList = RecieveJson.ListaJurosValor(tabelaArray);
            string[] arrayJuros = jurosValorList.ToArray();

            List<string> amortizadoValorList = RecieveJson.ListaAmortizadoValor(tabelaArray);
            string[] arrayAmortizado = amortizadoValorList.ToArray();

            List<string> iofTotalValor = RecieveJson.ListaIofTotalValor(tabelaArray);
            string[] arrayIOF = iofTotalValor.ToArray();

            List<string> dividaSaldoDevedorList = RecieveJson.ListaDividaSaldoDevedor(tabelaArray);
            string[] arraySaqueVdd = dividaSaldoDevedorList.ToArray();

            List<string> iofBasicoList = RecieveJson.ListaIofBasico(tabelaArray);
            string[] arrayIofBas = iofBasicoList.ToArray();

            List<string> iofFlatList = RecieveJson.ListaIofFlat(tabelaArray);
            string[] arrayIofFlat = iofFlatList.ToArray();

            List<string> desagioList = RecieveJson.ListaDesagio(tabelaArray);
            string[] arrayDesagio = desagioList.ToArray();

            List<string> valorPresenteList = RecieveJson.ListaValorPresente(tabelaArray);
            string[] arrayValorPresente = valorPresenteList.ToArray();

            string json = jsonEntradaRes;
            string jsonTabela = null;

            string parc = arrayParcelas[0];
            double dc = 0;
            int cont = 1;
            for (int i = 0; i < quantidadeParcelas; i++)
            {
                if (arrayParcJson[i] == parc)
                {
                    if (cont < arrayParcelas.Length)
                    {
                        DateTime dataFut = Convert.ToDateTime(String.Concat(arrayData[i].Where(c => !Char.IsWhiteSpace(c))));
                        dc = fgts.Dias(dataPag, dataFut);

                        parc = arrayParcelas[cont];

                        cont++;
                    }
                    else
                    {
                        DateTime dataFut = Convert.ToDateTime(String.Concat(arrayData[i].Where(c => !Char.IsWhiteSpace(c))));
                        dc = fgts.Dias(dataPag, dataFut);
                    }

                    if (dc < 0)
                    {
                        double multa = fgts.Multa(arrayValorParc[i], taxaMulta);
                        double mora_dc = fgts.Mora_DC_porc(jurosMoraAD, dc);
                        double jurosMora = fgts.JurosMora(arraySaqueVdd[i], jurosMoraAD, dc);
                        //string trimmed = String.Concat(example.Where(c => !Char.IsWhiteSpace(c)));

                        jsonTabela += "{\"PARCELA\" :" + arrayParcJson[i] + ", \"DATAVENCPARCELA\":\"" + String.Concat(arrayData[i].Where(c => !Char.IsWhiteSpace(c))) + "\", \"DC\":" + dc.ToString() + ", \"PARCELA_VALOR\":" + arrayValorParc[i] + ", \"JUROS_VALOR\":" + arrayJuros[i] + ", \"AMORTIZADO_VALOR\":" + arrayAmortizado[i] + ", \"IOFTOTALPARCELA_VALOR\":" + arrayIOF[i] + ", \"DIVIDA_SALDODEVEDORATUALIZADO_VALOR\":" + arraySaqueVdd[i] + ", \"IOF_BASICO\":" + arrayIofBas[i] + ", \"IOF_FLAT\":" + arrayIofFlat[i] + ", \"DESAGIO\":" + arrayDesagio[i] + ", \"VALOR_PRESENTE\":" + arrayValorPresente[i] + ", \"MULTA\":" + multa.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"%MORA_DC\":" + mora_dc.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ", \"JUROS_MORA\":" + jurosMora.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "}, \n";
                    }

                    else
                    {
                        jsonTabela += "{\"PARCELA\" :" + arrayParcJson[i] + ", \"DATAVENCPARCELA\":\"" + String.Concat(arrayData[i].Where(c => !Char.IsWhiteSpace(c))) + "\", \"DC\":" + dc.ToString() + ", \"PARCELA_VALOR\":" + arrayValorParc[i] + ", \"JUROS_VALOR\":" + arrayJuros[i] + ", \"AMORTIZADO_VALOR\":" + arrayAmortizado[i] + ", \"IOFTOTALPARCELA_VALOR\":" + arrayIOF[i] + ", \"DIVIDA_SALDODEVEDORATUALIZADO_VALOR\":" + arraySaqueVdd[i] + ", \"IOF_BASICO\":" + arrayIofBas[i] + ", \"IOF_FLAT\":" + arrayIofFlat[i] + ", \"DESAGIO\":" + arrayDesagio[i] + ", \"VALOR_PRESENTE\":" + arrayValorPresente[i] + "}, \n";
                    }

                }
                else
                {
                    jsonTabela += "{\"PARCELA\" :" + arrayParcJson[i] + ", \"DATAVENCPARCELA\":\"" + String.Concat(arrayData[i].Where(c => !Char.IsWhiteSpace(c))) + "\", \"DC\":" + arrayDc[i] + ", \"PARCELA_VALOR\":" + arrayValorParc[i] + ", \"JUROS_VALOR\":" + arrayJuros[i] + ", \"AMORTIZADO_VALOR\":" + arrayAmortizado[i] + ", \"IOFTOTALPARCELA_VALOR\":" + arrayIOF[i] + ", \"DIVIDA_SALDODEVEDORATUALIZADO_VALOR\":" + arraySaqueVdd[i] + ", \"IOF_BASICO\":" + arrayIofBas[i] + ", \"IOF_FLAT\":" + arrayIofFlat[i] + ", \"DESAGIO\":" + arrayDesagio[i] + ", \"VALOR_PRESENTE\":" + arrayValorPresente[i] + "}, \n";
                }
            }

            //tira a últma vírgula antes de fechar o array
            int index = jsonTabela.LastIndexOf(',');
            jsonTabela = jsonTabela.Remove(index, 1);

            json += "\"TABELA_FLUXO_PARCELAS\":";
            json += "[ \n";

            json += jsonTabela;

            json += "]\n";
            json += "}\n";

            return json;
        }
    }
}
