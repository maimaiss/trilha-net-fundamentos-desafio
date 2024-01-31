using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    //define uma classe
    public class Estacionamento
    {
        //elementos privados, somente a própria classe pode ter acesso
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();


        //construtor, método especial que é chamado quando um objeto da classe é criado
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            //Pedir para o usuário digitar uma placa e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar no formato XXX-0000:");
            string placa = Console.ReadLine();
            //Expressão regular para verificar se a placa está no formato correto.
            Regex regex = new Regex("^[A-Z]{3}-[0-9]{4}$");

            if (regex.IsMatch(placa))
            {
                if (veiculos.Contains(placa))
                {
                    Console.WriteLine("Já existe um veículo com essa placa. Confira se digitou a placa corretamente");
                    Console.WriteLine("----");
                    AdicionarVeiculo();
                }
                else
                {
                    veiculos.Add(placa);
                }
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente no formato correto.");
                Console.WriteLine("----");
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                //calculando o valor da estadia no estacionamento
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                //Removendo a placa digitada da lista de veículos
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                //listagem dos veiculos
                Console.WriteLine("Os veículos estacionados são:");
                int i = 0;
                foreach (string item in veiculos)
                {
                    Console.WriteLine($"{i + 1}. {item}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
