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


Para criar um projeto com clean architecture, inicialmente criar um projeto em branco
logo após adicionar as class librarys para as camadas. Para a API, criar um projeto API
Nas classes criadas se deve usar onde será trabalhada (no caso web api) e também, apos criar, se faz necessário apenas o arquivo de dependências

O projeto Application não terá nenhuma dependência
O projeto Domain terá dependência do projeto Application
O projeto Infrastructure terá dependência do projeto Domain
O projeto CrossCuting terá dependência dos projetos Application, Domain e Infrastructure
A API terá dependência do projeto CrossCuting

