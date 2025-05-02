# EFEx1
Este é um projeto de console em **C# com Entity Framework Core**, desenvolvido com o objetivo de praticar e demonstrar o uso de **CRUD**, **Code First**, **mapeamento de entidades** e **estrutura organizada de aplicação backend**, mesmo fora de um ambiente web.

## 🚀 Funcionalidades

- ✅ Cadastro, listagem, edição e exclusão de **Produtos**
- ✅ Cadastro, listagem, edição e exclusão de **Categorias**
- ✅ Relacionamento entre produtos e categorias (FK)
- ✅ Interface de menu interativo no terminal

## 📦 Tecnologias e ferramentas

- [.NET 8.0](https://dotnet.microsoft.com)
- C#
- Entity Framework Core (Code First)
- LINQ
- SQL Server LocalDB ou outro provedor configurado

## 🗂️ Estrutura do projeto

- **Controllers/**: Auxiliares para entrada do usuário e lógica de menu
- **Data/**: Classe de contexto (`DbContext`) e integração com EF Core
- **Models/**: Entidades do domínio (Produto, Categoria)
- **Migrations/**: Arquivos gerados automaticamente via EF Core para versionar o banco

## ⚙️ Como executar o projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/SEU_USUARIO/EFEX1.git
   cd EFEX1
2. Restaure os pacotes e compile:
   ```bash
   dotnet restore
   dotnet build 
3. Aplique as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update
   
4. Execute o Projeto
   ```bash
   dotnet run

💡 Aprendizados:
- Uso do Entity Framework Code First
- Aplicação da separação por camadas mesmo em console apps
- Manipulação de dados com LINQ e persistência no banco
- Criação de migrações e versionamento de estrutura de banco
