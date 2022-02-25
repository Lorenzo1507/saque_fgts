using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saque_library
{
    public class fgts
    {
        public static double taxaAA(double taxaAM)
        {
            double taxaAA = Math.Pow((1 + taxaAM), (365.0 / 30.0)) - 1;

            return taxaAA;
        }

        public static double taxaAD(double taxaAA)
        {
            double taxaAD = Math.Pow((1 + taxaAA), (1.0 / 365.0)) - 1;

            return taxaAD;
        }
        public static double Dias(DateTime dataH, DateTime dataFut)
        {
            DateTime dataHJ = dataH;
            DateTime data_fut = dataFut;

            //calcula a diferença de dias
            double dc = (data_fut - dataHJ).Days;

            if(dc > 365)
            {
                dc = 365;

                return dc;
            }

            return dc;
        }


        public static double Desagio(double taxaAD, double dc)
        {
            double desagio = Math.Pow((1 + taxaAD), dc);

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
            DateTime data_fut = dataFut;

            data_fut = data_fut.AddYears(1);

            return data_fut;
        }

        public static double ValorLiq(double vpBruto, double IOF_tot)
        {
            double valorLiq = vpBruto - IOF_tot;

            return valorLiq;
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

        //função que faz o mesmo que o main, porém irá retornar o valor exato que o desejado, sem considerar o IOF daquele valor (se formos tirar um valor de 15000
        public static double Saque_verdadeiro(double saldo, DateTime dataHJ, DateTime dataFut, double taxaAM, double taxaAD, double saldoDevedor)
        {
            double totalSaque = 0, totalAmortizado = 0, vpBruto = 0, iofBas_total = 0, jurosTot = 0, iof_tot = 0;


            for (int i = 1; saldoDevedor > 0; i++)
            {
                double iofAdd = IOF_adicional(saldo);
                double juros = Juros(taxaAM, saldoDevedor);
                jurosTot += juros;


                double dc = fgts.Dias(dataHJ, dataFut);
                double desagio = fgts.Desagio(taxaAD, dc);


                double saque = fgts.saque_calculo(saldoDevedor);



                double amortizado = Amortizado(saque, juros);
                totalAmortizado += amortizado;

                if (saque == 0)
                {
                    saque = saldoDevedor;
                    totalSaque = fgts.TotalSaque(saque, totalSaque);

                    amortizado = saque;
                    totalAmortizado += amortizado;

                    saldoDevedor = Saldo_devedor(saldoDevedor, amortizado);

                }

                saldoDevedor = Saldo_devedor(saldoDevedor, amortizado);

                totalSaque = fgts.TotalSaque(saque, totalSaque);

                iof_tot = IOF_total(dc, amortizado, iofBas_total, saldo);


                double valorPresente = fgts.ValorPresente(saque, desagio);

                vpBruto = fgts.VpBruto(valorPresente, vpBruto);

                double iofBas = IOF_basico(dc, amortizado);
                iofBas_total = IOF_basico_total(iofBas, iofBas_total);



                dataFut = fgts.Data_fut_mais1A(dataFut);
            }

            return saldo + iof_tot;
        }

        public static double Juros(double taxaAM, double saldo)
        {
            double juros = taxaAM * saldo;
            //para não dar juros com valores de 30 casas decimais
            if (juros < 0)
            {
                juros = 0;
                return juros;
            }
            return juros;
        }

        public static double Amortizado(double saque, double juros)
        {
            double amortizado = saque - juros;
            return amortizado;
        }

        //Em vez de simplesmente subtrair o saldo, devemos utilizar o amortizado para aparecer na tabela saldo anterior
        public static double Saldo_devedor(double saldo, double amortizado)
        {
            double saldo_antes = saldo - amortizado;

            if(saldo_antes <= 0)
            {
                saldo_antes = 0;
                return saldo_antes;
            }

            return saldo_antes;
        }
        //calcula iof basico
        public static double IOF_basico(double dc, double amortizado)
        {
            double IOF_basico = dc * amortizado * 0.000082;
            return IOF_basico;
        }
        //faz o incremento para calcular o total do iof básico
        public static double IOF_basico_total(double iof_basico, double iofB_total)
        {
            iofB_total += iof_basico;
            return iofB_total;
        }
        //calcula o iof adicional 
        public static double IOF_adicional(double saldoInicial)
        {
            double iofAdd = saldoInicial * 0.0038;
            return iofAdd;
        }
        //calcula o IOF total
        public static double IOF_total(double dc, double amortizado, double iofB_total, double saldoInicial)
        {
            double iof_basico = IOF_basico(dc, amortizado);
            double iof_basico_tot = IOF_basico_total(iof_basico, iofB_total);

            double iof_adicional = IOF_adicional(saldoInicial);

            double iofTotal = iof_basico_tot + iof_adicional;
            return iofTotal;
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

    }
}
