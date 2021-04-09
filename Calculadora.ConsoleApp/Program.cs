using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.ConsoleApp
{
    class Program
    {



        static void Main(string[] args)
        {

            string[] operacaoesRealizadas = new string[100];
            string opcao = "";
            int contadorOperacoesRealizadas = 0;
            while (true)
            {

                MostrarMenu();

                opcao = Console.ReadLine();


                if (ChecarOpcaoInvalida(opcao))
                {


                    ApresentarMensagem("Opção Invalida, tente novamente!");

                    continue;
                }

                if (EhOpcaoSair(opcao))
                {
                    break;
                }

                if (ChecarOperacoesRealizadas(opcao))
                {
                    Console.WriteLine();

                    if (contadorOperacoesRealizadas == 0)
                    
                        ApresentarMensagem("Nenhuma operação foi realizada, tente novamente!");
                    
                    else
                    
                        MostrarOperacoesRealizadas(operacaoesRealizadas);

                        Console.ReadLine();

                        Console.WriteLine();

                        Console.Clear();

                        continue;

                    
                }

                double primeiroNumero, segundoNumero;



                primeiroNumero = ObterNumero("primeiro");


                do
                {

                    segundoNumero = ObterNumero("segundo");

                    if (SegundoNumeroInvalido(opcao, segundoNumero))
                    {
                        ApresentarMensagem("Segundo numero inválido, tente novamente");
                    }
                } while (SegundoNumeroInvalido(opcao,segundoNumero));

                double resultado = CalcularResultado(opcao,primeiroNumero,segundoNumero);
                string simboloOperacao = ObterSimbolo(opcao);


                string operacaoRealizada = $"{ primeiroNumero }  {simboloOperacao}  {segundoNumero} = {resultado}";

                operacaoesRealizadas[contadorOperacoesRealizadas] = operacaoRealizada;

                contadorOperacoesRealizadas++;


                Console.WriteLine(resultado);

                Console.ReadLine();

                Console.Clear();

            }

        }

        private static string ObterSimbolo(string opcao)
        {
            string simboloOperacao = "";
            switch (opcao)
            {
                case "1":
                    simboloOperacao = "+";   
                    break;

                case "2":
                    simboloOperacao = "-";
                    break;

                case "3":
                    simboloOperacao = "*";
                    break;

                case "4":
                    simboloOperacao = "/";
                    break;

                default:
                    break;
            }

            return simboloOperacao;
        }


        private static double CalcularResultado(string opcao,double primeiroNumero, double segundoNumero)
        {
            double resultado = 0;
            switch (opcao)
            {
                case "1":
                    resultado = primeiroNumero + segundoNumero;
                    break;

                case "2":
                    resultado = primeiroNumero - segundoNumero;
                    break;

                case "3":
                    resultado = primeiroNumero * segundoNumero;
                    break;

                case "4":
                    resultado = primeiroNumero / segundoNumero;
                    break;

                default:
                    break;
            }

            return resultado;
        }


        private static bool SegundoNumeroInvalido(string opcao, double segundoNumero)
        {
            return opcao == "4" && segundoNumero == 0;
        }

        private static double ObterNumero(string ordem)
        {
            Console.Write($"Digite a {ordem} do número : ");

            double numero =  Convert.ToDouble(Console.ReadLine());

            return numero;
        }

        private static bool EhOpcaoSair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }

        private static void MostrarOperacoesRealizadas(string[] operacaoesRealizadas)
        {
            for (int i = 0; i < operacaoesRealizadas.Length; i++)
            {
                if (operacaoesRealizadas[i] != null)
                {
                    Console.WriteLine(operacaoesRealizadas[i]);

                }

            }
        }

        private static bool ChecarOperacoesRealizadas(string opcao)
        {
            return opcao == "5";
        }

        private static void ApresentarMensagem(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();

            Console.Clear();
        }

        private static bool ChecarOpcaoInvalida(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S" && opcao != "s" && opcao != "5";
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("Calculadora 1.7.1");


            Console.WriteLine(" Pressione 1 para somar ");

            Console.WriteLine(" Pressione 2 para subtrair");

            Console.WriteLine(" Pressione 3 para multiplicação");

            Console.WriteLine(" Pressione 4 para divisão");

            Console.WriteLine(" Pressione 5 para visualizar as operações realizadas");

            Console.WriteLine(" Pressione S para sair ");
        }
    }
}
