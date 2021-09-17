<h1 align="center">Your Dressing</h1>
<h4 align="center">Sistema de administração de uma loja online e fictícia, contendo operações CRUD para fixação de aprendizado.</h3>

<br/>
<h3>:computer: Tecnologias utilizadas:</h3>
<h4>
 <ul>
  <li>DotNET 5.0</li>
  <li>SQL Server</li>
  <li>Entity Framework Core</li>
  <li>Nuget Package: X.PagedList</li>
  </ul>
</h4>

<br/>
<h3>:wrench: Quer rodar o projeto? Siga os passos:</h3>
<h4>
 <ul><li>É necessário instalar o Visual Studio 2019 ou Visual Studio Code e SQL Server</li></ul>
 
 <br/>
 <ol>
  <li>Faça o download ou clone o projeto.</li>
  <li>Abra o arquivo de solução chamado YourDressing.sln</li>
  <li>No arquivo appsettings.json, altere o endereço de conexão em "Default" para sua conexão local. Queira utilizar:
   <blockquote>
    "ConnectionStrings": { 
     <p>"Default": "Server=NomeDoSeuServidor;DATABASE=MyDressStore;Trusted_Connection=True;MultipleActiveResultSets=True"</p>
    }
   </blockquote>
  </li>
  <li>Restaure os pacotes NuGet da solução:
   <ul>
    <p>Pelo CLI: <blockquote>dotnet restore</blockquote></p>
    <p>Pelo CLI do NuGet: <blockquote>nuget restore YourDressing.sln</blockquote></p>
   </ul>
  </li>
  
  <li>Abra o Console de Gerenciador de Pacotes do Nuget e execute o seguinte comando para criar e restaurar as tabelas do banco de dados:<blockquote>Update-Database</blockquote></li>
 </ol>
</h4>

<h3>O que aprendi neste projeto:</h3>
<h4>
 <ul>
  <li>Configurações básicas e utilização do Entity Framework Core (code first)</li>
  <li>Utilização de Partials Views e Components Views</li>
  <li>Introdução ao mundo front-end: princípios básicos de tags HTML</li>
  <li>Como é feita a comunicação no padrão MVC.</li>
 </ul>
</h4>

<br/>
<h3>Referências:</h3>
<ul>
 <li>Customização de CSS com Bootstrap: <a href="https://bootswatch.com/lux/?">Clique aqui.</a></li>
 <li>Obter descrição de elementos do tipo enumerados: <a href="https://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value">Clique aqui.</a></li>
 <li>Paginação e filtragem de dados com PagedList: 
  <a href="https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application">Link 1</a> | 
  <a href="https://stackoverflow.com/questions/41517359/pagedlist-core-mvc-pagedlistpager-html-extension-in-net-core-is-not-there">Link 2</a>
 </li>
 <li>Obter o nome de elementos do tipo enumerados e alocá-los em uma SelectList: <a href="https://stackoverflow.com/questions/18738804/display-name-of-enum-dropdownlist-in-razor">Clique aqui.</a></li>
 </ul>
 
 <br/>
<h4>É válido ressaltar que o autor deste projeto foca seu aprendizado em desenvolvimento back-end. Portanto, diversos elementos do sistema YourDressing que estejam atrelados ao desenvolvimento front-end podem estar desalinhados, mal formatados ou mal posicionados.
</h4>
