using System;
using System.Threading.Tasks;
using Refit;
using RefitCepExample;

namespace RefitCepSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe o seu CEP: ");

                string meuCep = Console.ReadLine().ToString();
                Console.WriteLine("Consultando dados do Cep: " + meuCep);

                var address = await cepClient.GetAddressAsync(meuCep);

                Console.Write($"\nLogradouro:{address.Logradouro}\nBairro:{address.Bairro}" +
                    $"\nCidade:{address.Localidade}\nEstado:{address.Uf}\nCódigo Ibge:{address.Ibge}");
                Console.ReadKey();
            } catch (Exception e) {
                Console.WriteLine("Erro ao consultar CEP: " + e.Message);
            }
        }
    }
}
