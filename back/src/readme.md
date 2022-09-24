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

Para gerar o banco de dados e as tabelas com base no script
 $ dotnet ef database update


Data Annotations
https://www.macoratti.net/13/12/c_vdda.htm


Clean Architecture
Por padrão, ao criarmos um projeto no vs, ocorre a organização por pastas, fazendo assim com que o projeto seja fortemente acoplado
As regras de negócios tendem a se espalhar pelo projeto, sendo assim difícil encontra-las

Para melhorar o programa, devem ser feitas algumas modificações na arquitetura do mesmo, e existem diversos modelos de arquitetura que atendem esse objetivo, sendo a clean architecture apenas uma delas 
Todas possuem em comum alguns fatores como:
    - Independência de Frameworks 
    - Testabilidade
    - Independência do Front-End
    - Independência de um banco de dados 
    - Independência de fatores externos

    - Regras de Dependência > As camadas internas não devem ter qualquer dependência das externas nem indiretas, como nomes de variáveis e funções 

    https://www.google.com/url?sa=i&url=https%3A%2F%2Fblog.cleancoder.com%2Funcle-bob%2F2012%2F08%2F13%2Fthe-clean-architecture.html&psig=AOvVaw2HzD7eXaz_tvFU_NYxuRlC&ust=1664137409132000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCOicl5WhrvoCFQAAAAAdAAAAABAD

    Nesse caso, serão usados 5 projetos diferentes 
        -.Domain            Modelo de domínio, interfaces, regras de negócio
        -.Application       Regras da aplicação, serviços, mapeamento, DTOs
        -.Infrastructure    Lógica de acesso a dados, contexto, configurações, ORM
        -.CrossCutting      IoC, Registro dos serviços e recursos, DI
        -.Api               Controladores, endpoints, filtros

        Os projetos serão criados com o tipo Class Library, exceto o projeto .API que será do tipo API .NET Core Web API