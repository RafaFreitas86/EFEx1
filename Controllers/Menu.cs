using EFex1.Data;
using EFex1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFex1.Controllers

{
    public class Menu
    {
        private readonly ConsoleHelper consoleHelper = new ConsoleHelper();
        
        //______________________________________PRODUCT_____________________________________________


        public void ListProduct(RFex1DbContext context) //*********************Read**************************
        {
            var produtos = context.Produtos
                .Include(p => p.Categoria)
                .AsNoTracking()
                .ToList();

            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id}");                       // Imprime o Id do produto
                Console.WriteLine($"Nome: {produto.Nome}");                   // Imprime o nome
                Console.WriteLine($"Descrição: {produto.Descricao}");         // Imprime a descrição
                Console.WriteLine($"Preço: {produto.Preco:C}");               // Imprime o preço formatado como moeda
                Console.WriteLine($"Categoria: {produto.Categoria?.Nome}");   // Imprime o nome da categoria (se existir)
                Console.WriteLine(new string('-', 40));                       // Linha separadora para melhor visualização
            }
        }

        public void CreateProduct(RFex1DbContext context) //*******************Create****************************
        {
           
            Console.WriteLine("Digite nome do Produto:");
            string? nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome)) // Verifica se o nome é nulo ou vazio
            {
                Console.WriteLine("O nome não pode ser vazio.");
                return;
            }

            Console.WriteLine("Descreva o Produto:");
            string? descricao = Console.ReadLine();

            decimal preco = consoleHelper.LerValor<decimal>("Valor do Produto:"); // Testa entrada de valor decimal

            int qtn = consoleHelper.LerValor<int>("Quantidade em estoque:");

            Console.WriteLine("Categorias disponíveis:"); // Listar categorias disponíveis
            ListCategory(context); // Chama o método ListCategory para listar as categorias

            while (true)
            {
                int categoriaIdInt = consoleHelper.LerValor<int>("Id da Categoria:"); // Testa se o valor digitado é válido
                var categoriaSelecionada = context.Categorias.FirstOrDefault(c => c.Id == categoriaIdInt); // Verifica se a categoria existe

                if (categoriaSelecionada != null)
                {
                    var novoProduto = new Produto
                    {
                        Nome = nome,
                        Descricao = descricao,
                        Preco = preco,
                        QtnEstoque = qtn,
                        CategoriaId = categoriaIdInt
                    };
                    context.Add(novoProduto); // Adiciona o novo produto ao contexto
                    context.SaveChanges();
                    Console.WriteLine("Produto criado com sucesso!");
                    break;
                }
                else                // Se a categoria não existir, exibe uma mensagem de erro e lista as categorias disponíveis
                {
                    Console.WriteLine("Id da Categoria inválido. Digite um valor válido");
                }
            }
        }

        public void UpdateProduct(RFex1DbContext context) //*******************Update*********************
        {
           
            while (true)
            {
                ListProduct(context); // Lista os produtos disponíveis
                Console.WriteLine("Digite o Id do Produto a ser atualizado:");
                int productIdInt = consoleHelper.LerValor<int>(""); // Testa se o valor digitado é válido
                var produtoSelecionado = context.Produtos.FirstOrDefault(p => p.Id == productIdInt); // Verifica se o produto existe

                if (produtoSelecionado != null)
                {
                    Console.WriteLine("Digite nome do Produto:");
                    string? nome = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nome)) // Verifica se o nome é nulo ou vazio
                    {
                        Console.WriteLine("Nome não pode ser vazio.");
                        return;
                    }
                    Console.WriteLine("Descreva o Produto:");
                    string? descricao = Console.ReadLine();

                    decimal preco = consoleHelper.LerValor<decimal>("Valor do Produto:");
                    int qtn = consoleHelper.LerValor<int>("Quantidade em estoque:");

                    produtoSelecionado.Nome = nome; // Atualiza o nome do produto   
                    produtoSelecionado.Descricao = descricao; // Atualiza a descrição do produto    
                    produtoSelecionado.Preco = preco; // Atualiza o preço do produto
                    produtoSelecionado.QtnEstoque = qtn; // Atualiza a quantidade em estoque do produto

                    Console.WriteLine(new string('-', 40)); // Linha separadora para melhor visualização    

                    ListCategory(context); // Chama o método ListCategory para listar as categorias
                    Console.WriteLine("Id da Categoria:");

                    while (true)
                    {
                        int categoriaIdInt = consoleHelper.LerValor<int>(""); // Testa se o valor digitado é válido
                        var categoriaSelecionada = context.Categorias.FirstOrDefault(c => c.Id == categoriaIdInt); // Verifica se a categoria existe
                        if (categoriaSelecionada != null)
                        {
                            produtoSelecionado.CategoriaId = categoriaIdInt; // Atualiza a categoria do produto
                            context.SaveChanges();
                            Console.WriteLine("Produto atualizado com sucesso!");
                            break;
                        }
                        Console.WriteLine("Id da Categoria inválido.");
                    }
                    break; // Sai do loop se o produto for atualizado com sucesso
                }
                else
                {
                    Console.WriteLine("Produto não encontrado!");
                }
            }
        }

        public void DeleteProduct(RFex1DbContext context) //*******************Delete*********************
        {
      
            while (true)
            {
                int productIdInt = consoleHelper.LerValor<int>("Digite o Id do Produto a ser deletado:");
                var produtoSelecionado = context.Produtos.FirstOrDefault(p => p.Id == productIdInt); // Verifica se o produto existe
                if (produtoSelecionado != null)
                {
                    context.Produtos.Remove(produtoSelecionado);
                    context.SaveChanges();
                    Console.WriteLine("Produto deletado com sucesso!");
                    break; // Sai do loop se o produto for deletado com sucesso
                }
                Console.WriteLine("Produto não encontrado!");
            }
        }

        //______________________________________CATEGORY_____________________________________________//

        public void ListCategory(RFex1DbContext context) //************************Read**************************
        {
            var categoria = context.Categorias
                .AsNoTracking()
                .ToList();
            foreach (var cat in categoria)
            {
                Console.WriteLine($"ID: {cat.Id}");                       // Imprime o Id da categoria
                Console.WriteLine($"Nome: {cat.Nome}");                   // Imprime o nome da categoria
                Console.WriteLine($"Slug: {cat.Slug}");                   // Imprime o slug da categoria
                Console.WriteLine(new string('-', 40));                   // Linha separadora para melhor visualização
            }
        }
        public void CreateCategory(RFex1DbContext context) //*******************Create****************************
        {
            Console.WriteLine("Qual nome da Categoria:");
            string? nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome)) // Verifica se o nome é nulo ou vazio
            {
                Console.WriteLine("O nome da Categoria não pode ser vazio.");
                return;
            }
            Console.WriteLine("Slug da Categoria:");
            string? slug = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(slug)) // Verifica se o nome é nulo ou vazio
            {
                Console.WriteLine("O slug da Categoria não pode ser vazio.");
                return;
            }

            var novaCategoria = new Categoria
            {
                Nome = nome,
                Slug = slug
            };
            context.Add(novaCategoria);
            context.SaveChanges();
            Console.WriteLine("Categoria criada com sucesso!");
        }
        public void UpdateCategory(RFex1DbContext context) //*******************Update*********************
        {
            while (true)
            {
                ListCategory(context); // Lista as categorias disponíveis
                int categoryId = consoleHelper.LerValor<int>("Digite o Id da Categoria a ser atualizada:"); // testa se o valor digitado é válido
                var categoriaSelecionada = context.Categorias.FirstOrDefault(c => c.Id == categoryId); // Verifica a categoria existe
                if (categoriaSelecionada != null)
                {
                    Console.WriteLine("Digite nome da Categoria:");
                    string? nome = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nome)) // Verifica se o nome é nulo ou vazio
                    {
                        Console.WriteLine("Nome da Categoria não pode ser vazio.");
                        return;
                    }
                    Console.WriteLine("Slug da Categoria:");
                    string? slug = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(slug)) // Verifica se o nome é nulo ou vazio
                    {
                        Console.WriteLine("slug da Categoria não pode ser vazio.");
                        return;
                    }
                    categoriaSelecionada.Nome = nome;
                    categoriaSelecionada.Slug = slug;
                    context.SaveChanges();
                    Console.WriteLine("Categoria atualizada com sucesso!");
                    break; // Sai do loop se a categoria for atualizada com sucesso
                }
                Console.WriteLine("Categoria não encontrada!");
            }
        }

        public void DeleteCategory(RFex1DbContext context) //*******************Delete*********************
        {
        
            ListCategory(context); // Lista as categorias disponíveis

            while (true)
            {
                int categoriaId = consoleHelper.LerValor<int>("Digite o Id da categoria a ser deletado:");
                var categoriaSelecionada = context.Categorias.FirstOrDefault(c => c.Id == categoriaId); // Verifica se o produto existe
                if (categoriaSelecionada != null)
                {
                    context.Remove(categoriaSelecionada); // Remove a categoria do contexto   
                    context.SaveChanges();
                    Console.WriteLine("Categoria deletada com sucesso!");
                    break; // Sai do loop se a categoria for deletada com sucesso
                }
                Console.WriteLine("Categoria não encontrada!"); // Mensagem de erro se a categoria não for encontrada
            }
        }
    }
}