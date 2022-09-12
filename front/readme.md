Para instalar o angular, devemos usar o comando:
  $ npm install --location=global @angular/cli
No Windows, devido a questões de política de segurança, é necessário rodar o seguinte comando:
  $ Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
Onde -ExecutionPolicy determina a política de execução e -Scope determina o escopo onde sera executada a ação (*obs: caso o computador não seja de uso público/coletivo, não é necessário executa-la no modo CurrentUser)

Para criar uma aplicação, devemos executar o comando: 
  $ ng new <nome da aplicação>

Para criar um novo componente:
  $ ng g c <componente>
g significa o parâmetro generate e c o parâmetro component

Comandos angular      Atalho npm
  $ ng                  $ npm ng
  $ ng serve            $ npm start
  $ ng build            $ npm build
  $ ng test             $ npm test
  $ ng lint             $ npm lint
  $ ng e2e              $ npm e2e

Instalando o Font Awesome (ferramenta para ícones)
  $ npm install --save @fortawesome/fontawesome-free

Instalando o ngx-bootstrap (ferramenta de integração entre o bootstrap e o angular)
  $ ng add ngx-bootstrap
  adicionar no head da página o link para o css do bootstrap

** OBS.: O ngx-bootstrap atualiza aos poucos a compatibilidade com as versões. No caso da versão usada no projeto não ser a versão corrente do ngx, é necessário adicionar os recursos manualmente **
É necessário realizar imports para o scss principal do projeto