<h1>Configurando um Projeto C# com .NET e MySQL usando Dapper</h1>

<h2>Introdução</h2>
<p>Este guia descreve os passos necessários para criar um projeto C# usando o .NET Framework, MySQL e a biblioteca Dapper. O projeto aborda operações CRUD para um modelo de usuário. Ele é baseado em aulas da FIAP e da Alura.</p>

<h2>Pré-requisitos</h2>
<ul>
  <li>Visual Studio ou Visual Studio Code instalado.</li>
  <li>Conhecimento básico de C#.</li>
</ul>

<h2>Passo 1: Configuração do Projeto</h2>
<ol>
  <li>Crie um novo projeto no Visual Studio.</li>
  <li>Escolha o tipo de projeto "Aplicação Web ASP.NET Core".</li>
  <li>Selecione "API" como o tipo de aplicação.</li>
</ol>

<h2>Passo 2: Configuração do Banco de Dados</h2>
<ol>
  <li>Instale o MySQL Server em seu sistema ou use um serviço de banco de dados MySQL.</li>
  <li>Crie um banco de dados para o projeto.</li>
</ol>

<h2>Passo 3: Instalação do Dapper e MySQLConnector</h2>
<ol>
  <li>No Visual Studio, abra o arquivo do projeto (.csproj) e adicione as seguintes dependências:</li>
</ol>

```html
<ItemGroup>
  <PackageReference Include="Dapper" Version="2.0.78" />
  <PackageReference Include="MySqlConnector" Version="1.3.7" />
</ItemGroup>
```

<h2>Passo 4: Configuração da Conexão com o Banco de Dados</h2>
<p>No arquivo appsettings.json, adicione a configuração do banco de dados:</p>

```html
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=NomeDoSeuBanco;User=SeuUsuario;Password=SuaSenha;"
}

```
