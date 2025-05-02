
using EFex1.Data;
using EFex1.Models;
using EFex1.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;


namespace EFex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new RFex1DbContext();

            var menu = new Menu(); // Instancia a classe Menu

            int opcao;
            do
            {
                // Exibe o menu principal
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Listar Produtos");
                Console.WriteLine("2. Criar Produto");
                Console.WriteLine("3. Atualizar Produto");
                Console.WriteLine("4. Deletar Produto");
                Console.WriteLine("5. Listar Categorias");
                Console.WriteLine("6. Criar Categoria");
                Console.WriteLine("7. Atualizar Categoria");
                Console.WriteLine("8. Deletar Categoria");
                Console.WriteLine("9. Sair");
                Console.WriteLine("===================================");

                // Valida a entrada do usuário
                
                var consoleHelper = new ConsoleHelper(); // Instancia a classe ConsoleHelper
                opcao = consoleHelper.LerValor<int>("Opção: ");

                // Executa a operação correspondente
                switch (opcao)
                {
                    case 1:
                        menu.ListProduct(context);
                        break;
                    case 2:
                        menu.CreateProduct(context);
                        break;
                    case 3:
                        menu.UpdateProduct(context);
                        break;
                    case 4:
                        menu.DeleteProduct(context);
                        break;
                    case 5:
                        menu.ListCategory(context);
                        break;
                    case 6:
                        menu.CreateCategory(context);
                        break;
                    case 7:
                        menu.UpdateCategory(context);
                        break;
                    case 8:
                        menu.DeleteCategory(context);
                        break;
                    case 9:
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 9);     // Continua até o usuário escolher "Sair"


            
            
        }
    }
}

