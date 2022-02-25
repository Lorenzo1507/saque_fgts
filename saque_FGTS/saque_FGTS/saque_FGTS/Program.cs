using System;

namespace saque_FGTS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escreva seu saldo de hoje do FGTS:");
            
            string saldoStr = Console.ReadLine();
            double saldo = Convert.ToDouble(saldoStr);

            Console.WriteLine("Escreva o dia de hoje, no formato exatamente assim AAAA-MM-DD:");
            string dataHJ = Console.ReadLine();

            Console.WriteLine("Escreva a taxa ao mês (ex: 1,99): ");
            string taxaAMstr = Console.ReadLine();
            double taxaAM = Convert.ToDouble(taxaAMstr);
            taxaAM = taxaAM / 100;

            valor_presente(saldo, taxaAM, dataHJ);

            for (int i = 1; i <= 5; i++)
            {
                double saque = saque_calculo(saldo);
                saldo = saldo - saque;
                Console.WriteLine("O saldo atual é " + Math.Round((saldo + saque), 2, MidpointRounding.ToEven) + ", e o saque autorizado " + i + " tem o valor de " + Math.Round(saque, 2, MidpointRounding.ToEven));
            }

            
        }

      

        public static void valor_presente(double saldo, double taxaAM, string dataH)
        {
            DateTime dataHJ = Convert.ToDateTime(dataH);

            double taxaAA = Math.Pow((1 + taxaAM), (365.0 / 30.0)) - 1;

            double taxaAD = Math.Pow((1 + taxaAA), (1.0 / 365.0)) - 1;

            double IOF = 0, IOF_tot = 0;
            

            //cria data do ano futuro
            var dataFut = new DateTime(2022, 04, 01);

            for (int i = 1; i <= 5; i++)
            {
                //pega os valores do saque
                double saque_aut = saque_calculo(saldo);
                //atualiza os valores do saque
                saldo = saldo - saque_aut;

                //calcula a diferença de dias
                double dc = (dataFut - dataHJ).Days;

                //eleva (1+taxaAM) por dc
                double desagio = Math.Pow((1 + taxaAD), dc);

                double valorPresente = (saque_aut) / (desagio);

                if(dc < 365)
                {
                    IOF = dc * valorPresente * 0.000082;
                    IOF_tot += IOF;
                }
                else
                {
                    IOF = 0.03 * valorPresente;
                    IOF_tot += IOF;
                }

                Console.WriteLine("IOF: " + IOF);
                Console.WriteLine("IOF total: " + IOF_tot);
                Console.WriteLine("dias: " + dc);
                Console.WriteLine("O saque " + i + " com a data " + dataFut.ToShortDateString() + ", tem o deságio: " + desagio + " e o valor presente: " + Math.Round(valorPresente, 2, MidpointRounding.ToEven)+"\n");

                dataFut = dataFut.AddYears(1);
            }            
            
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
    }
}
