Criar web API - Ordem de ações:
  1 - Criar o projeto, com as opções para habilitar a OpenApi e usar Controllers
  2 - Criar o modelo de entidades 
  3 - Configurar o projeto para usar e incluir referências ao EF Core
  4 - Definir o banco de dados
  5 - Definir a classe de contexto 
  7 - Definir o mapeamento de entidades para as tabelas 
  8 - Definir a string de conexão, definir o provedor e obter a string de conexão 
  9 - Registrar o contexto como um serviço 
  10 - Aplicar o migrations e criar o banco de dados e as tabelas
  11 - Criar os controladores
  12 - Definir os endpoints para realizar operações CRUD



1 - Criar o projeto, com as opções para habilitar a OpenApi e usar Controllers

Para criar o json, podemos usar o comando 
  $ dotnet new globaljson --sdk-version <sdk>

Para criar a API:
  $ dotnet new webapi -n <nome da api>.api



3 - Configurar o projeto para usar e incluir referências ao EF Core

Para instalar o Entity Framework
  $ dotnet tool install dotnet-ef

Para usar bancos de dados, devemos instalar os pacotes pomelo entity framework core, entity framework core design e entity framework core tools de duas formas:
  1: através da ferramenta NuGet Gallery, onde selecionaremos os pacotes 
    Microsoft.EntityFrameworkCore.Design
    Microsoft.EntityFrameworkCore.Tools
    Pomelo.EntityFrameworkCore.MySql

  2: atraves da linha de comando 
    dotnet add package <nome do pacote>



10 - Aplicar o migrations e criar o banco de dados e as tabelas

Para criar uma migration:
  $ dotnet ef migrations add <nome da migração>

Para remover o script de migração criado:
  $ dotnet ef migrations remove <nome da migracao>

Para gerar o banco de dados e as tabelas com base no acript
 $ dotnet ef database update