namespace DesafioFundamentos.Models
{
    public class Estacionamento: Veiculo
    {

        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public decimal Desconto { get; set; }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Informe o seu nome");

            string nome = Console.ReadLine();


            Console.WriteLine("Selecione o tipo do seu veículo:");
            Console.WriteLine("[1] - Carro");
            Console.WriteLine("[2] - Moto");
            Console.WriteLine("[3] - Caminhão");
            Console.WriteLine("[4] - Outro");


            switch (Console.ReadLine())
            {
                case "1":
                    TipoDoVeiculo = "Carro";
                    break;

                case "2":
                    TipoDoVeiculo = "Moto";
                    break;

                case "3":
                    TipoDoVeiculo = "Caminhão";
                    break;

                case "4":
                    TipoDoVeiculo = "Outro";
                    break;

            default:
            Console.WriteLine("Opção inválida");
            break;
            }

            Console.Write("Placa: ");

            Placa = Console.ReadLine();

            veiculos.Add(Placa);

            Console.Write("Informe o Modelo do veículo: ");

            Modelo = Console.ReadLine();

            Console.Write("Informe o Ano do veículo: ");

            Ano = int.Parse(Console.ReadLine());

            Console.Write("Informe a cor do veículo: ");

            Cor = Console.ReadLine();

            Console.WriteLine("Já utilizou os nossos serviços mais de 5 vezes no mês?");
            Console.WriteLine("[1] - Sim");
            Console.WriteLine("[2] - Não");

            Desconto = int.Parse(Console.ReadLine());

            Console.Write("Agora crie um código de segurança:  ");
            Console.Write("Atenção! Você só poderá remover o veículo com esse código de segurança!: ");

            CodigoSeguranca = int.Parse(Console.ReadLine());

            Console.WriteLine("Veículo cadastrado com sucesso! Deseja visualizar as informações do cadastro? ");
            Console.WriteLine("[1] - Sim");
            Console.WriteLine("[2] - Não");
    
            int resumo = int.Parse(Console.ReadLine());

            if (resumo == 1)
            {
                Console.Write("Informações do Cadastro: \n");
               
                Console.WriteLine($"Nome: {nome} \n");
                Console.WriteLine($"Veículo: {TipoDoVeiculo} \n");
                Console.WriteLine($"Modelo: {Modelo} \n");
                Console.WriteLine($"Ano: {Ano} \n");
                Console.WriteLine($"Cor: {Cor} \n");
                Console.WriteLine($"Placa: {Placa} \n");
            }
            else if (resumo == 2)
            {
                Console.WriteLine("Saindo do Cadastro...");
            }


        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            Placa = Console.ReadLine();

            Console.WriteLine("Informe o seu código de segurança: ");
            int codigoSeguranca = int.Parse(Console.ReadLine());

            if (veiculos.Any(x => x.ToUpper() == Placa.ToUpper()) && codigoSeguranca == CodigoSeguranca)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

               
                

                int horas = Convert.ToInt32(Console.ReadLine());
                
                decimal valorTotal = (precoInicial + precoPorHora * horas);

                veiculos.Remove(Placa);
                
                if (Desconto == 1)
                {
                    Desconto = ((precoInicial + precoPorHora * horas) * 10) / 100;
                    valorTotal -= Desconto;
                }
                
                

                Console.WriteLine($"O veículo {Placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui ou o código" +
                " de segurança está inválido. Confira se digitou os dados corretamente.");
            }
        }

        public void ListarVeiculos()
        {

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                for (int count = 0; count < veiculos.Count; count++ )
                {
                    int exibicao = count + 1;
                    string busca = $"{veiculos[count]}";
                    Console.WriteLine(busca);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
