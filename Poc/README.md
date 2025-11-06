# 🌐 Poc

Um projeto **ASP.NET Core MVC** desenvolvido para servir como **portfólio pessoal**, com integração a um **banco de dados SQL Server** em container Docker.  
O objetivo é demonstrar habilidades em desenvolvimento web utilizando **.NET 8+, Entity Framework Core** e boas práticas de arquitetura MVC.

---

## 🚀 Tecnologias Utilizadas
🖥️ Back-end

- **.NET 8.0 — framework principal da aplicação**
- **ASP.NET Core MVC — arquitetura Model-View-Controller**
- **Entity Framework Core — ORM para acesso e persistência de dados**
- **SQL Server (Docker) — banco de dados containerizado para ambiente local**
- **Dependency Injection (DI) — para gerenciamento de dependências**
- **LINQ — consultas fortemente tipadas e integração com EF Core**

🎨 Front-end

- **Bootstrap 5 — estilização responsiva e componentes prontos**
- **jQuery — manipulação de DOM e suporte a plugins**
- **jQuery Validation / Unobtrusive Validation — validações client-side integradas às Views**
- **Razor (CSHTML) — renderização dinâmica de páginas**

---

## 🏗️ Estrutura do Projeto

<!-- BEGIN STRUCTURE -->
```
.
|-- appsettings.Development.json
|-- appsettings.json
|-- AutoMapper
|   `-- PocProfile.cs
|-- Controllers
|   |-- BaseController.cs
|   |-- HomeController.cs
|   `-- LoginController.cs
|-- Docker
|-- Enums
|   `-- Messages.cs
|-- Extensions
|   |-- ServiceCollectionExtensions.cs
|   |-- WebApplicationBuilderExtensions.cs
|   `-- WebApplicattionExtensions.cs
|-- LICENSE
|-- Models
|   |-- AcessoModel.cs
|   |-- ClienteModel.cs
|   |-- ErrorViewModel.cs
|   |-- UsuarioModel.cs
|   `-- ValidacaoModel.cs
|-- Poc.csproj
|-- Program.cs
|-- Properties
|   `-- launchSettings.json
|-- Repositories
|   |-- AcessoRepository.cs
|   |-- BaseRepository.cs
|   |-- ClienteRepository.cs
|   |-- Interfaces
|   |   |-- IAcessoRepository.cs
|   |   |-- IBaseRepository.cs
|   |   |-- IClienteRepository.cs
|   |   `-- IUsuarioRepository.cs
|   `-- UsuarioRepository.cs
|-- Services
|   |-- AcessoService.cs
|   |-- BaseService.cs
|   |-- ClienteService.cs
|   |-- Interfaces
|   |   |-- IAcessoService.cs
|   |   |-- IBaseService.cs
|   |   |-- IClienteService.cs
|   |   |-- IUsuarioService.cs
|   |   `-- IValidacaoService.cs
|   |-- UsuarioService.cs
|   `-- ValidacaoService.cs
|-- Settings
|   `-- AppSettings.cs
|-- SQL
|   |-- docker-compose.yml
|   |-- Poc
|   |   |-- Procedures
|   |   `-- Tables
|   |       |-- Acesso.sql
|   |       |-- Cliente.sql
|   |       `-- Usuario.sql
|   `-- Poc.bak
|-- update-readme.sh
|-- Views
|   |-- Home
|   |   |-- Index.cshtml
|   |   `-- Privacy.cshtml
|   |-- Login
|   |   |-- Index.cshtml
|   |   `-- Registrar.cshtml
|   |-- Shared
|   |   |-- Error.cshtml
|   |   |-- _FeedbackModal.cshtml
|   |   |-- _Layout.cshtml
|   |   `-- _ValidationScriptsPartial.cshtml
|   |-- _ViewImports.cshtml
|   `-- _ViewStart.cshtml
`-- wwwroot
    |-- css
    |   `-- styles.css
    |-- favicon.ico
    |-- js
    |   |-- functions.js
    |   |-- index.js
    |   `-- Vue
    |       `-- feedback.js
    `-- lib
        |-- bootstrap
        |   |-- dist
        |   |   |-- css
        |   |   |   |-- bootstrap.css
        |   |   |   |-- bootstrap.css.map
        |   |   |   |-- bootstrap-grid.css
        |   |   |   |-- bootstrap-grid.css.map
        |   |   |   |-- bootstrap-grid.min.css
        |   |   |   |-- bootstrap-grid.min.css.map
        |   |   |   |-- bootstrap-grid.rtl.css
        |   |   |   |-- bootstrap-grid.rtl.css.map
        |   |   |   |-- bootstrap-grid.rtl.min.css
        |   |   |   |-- bootstrap-grid.rtl.min.css.map
        |   |   |   |-- bootstrap.min.css
        |   |   |   |-- bootstrap.min.css.map
        |   |   |   |-- bootstrap-reboot.css
        |   |   |   |-- bootstrap-reboot.css.map
        |   |   |   |-- bootstrap-reboot.min.css
        |   |   |   |-- bootstrap-reboot.min.css.map
        |   |   |   |-- bootstrap-reboot.rtl.css
        |   |   |   |-- bootstrap-reboot.rtl.css.map
        |   |   |   |-- bootstrap-reboot.rtl.min.css
        |   |   |   |-- bootstrap-reboot.rtl.min.css.map
        |   |   |   |-- bootstrap.rtl.css
        |   |   |   |-- bootstrap.rtl.css.map
        |   |   |   |-- bootstrap.rtl.min.css
        |   |   |   |-- bootstrap.rtl.min.css.map
        |   |   |   |-- bootstrap-utilities.css
        |   |   |   |-- bootstrap-utilities.css.map
        |   |   |   |-- bootstrap-utilities.min.css
        |   |   |   |-- bootstrap-utilities.min.css.map
        |   |   |   |-- bootstrap-utilities.rtl.css
        |   |   |   |-- bootstrap-utilities.rtl.css.map
        |   |   |   |-- bootstrap-utilities.rtl.min.css
        |   |   |   `-- bootstrap-utilities.rtl.min.css.map
        |   |   `-- js
        |   |       |-- bootstrap.bundle.js
        |   |       |-- bootstrap.bundle.js.map
        |   |       |-- bootstrap.bundle.min.js
        |   |       |-- bootstrap.bundle.min.js.map
        |   |       |-- bootstrap.esm.js
        |   |       |-- bootstrap.esm.js.map
        |   |       |-- bootstrap.esm.min.js
        |   |       |-- bootstrap.esm.min.js.map
        |   |       |-- bootstrap.js
        |   |       |-- bootstrap.js.map
        |   |       |-- bootstrap.min.js
        |   |       `-- bootstrap.min.js.map
        |   `-- LICENSE
        |-- jquery
        |   |-- dist
        |   |   |-- jquery.js
        |   |   |-- jquery.min.js
        |   |   |-- jquery.min.map
        |   |   |-- jquery.slim.js
        |   |   |-- jquery.slim.min.js
        |   |   `-- jquery.slim.min.map
        |   `-- LICENSE.txt
        |-- jquery-validation
        |   |-- dist
        |   |   |-- additional-methods.js
        |   |   |-- additional-methods.min.js
        |   |   |-- jquery.validate.js
        |   |   `-- jquery.validate.min.js
        |   `-- LICENSE.md
        `-- jquery-validation-unobtrusive
            |-- dist
            |   |-- jquery.validate.unobtrusive.js
            |   `-- jquery.validate.unobtrusive.min.js
            `-- LICENSE.txt

36 directories, 119 files
```
<!-- END STRUCTURE -->
---

## ⚙️ Configuração do Ambiente
---
### 1️⃣ Pré-requisitos
Antes de iniciar, garanta que você tenha instalado:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms)

### 2️⃣ Clonar o Repositório
```
git clone https://github.com/Big2109/Poc.git
cd Poc
```

-- TODO (3️⃣ Subir o Banco de Dados com Docker)
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123!" \
   -p 1433:1433 --name sqlserver \
   -d mcr.microsoft.com/mssql/server:2022-latest

### 4️⃣ Configurar o appsettings.json
Ajuste a connection string conforme necessário:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=PortfolioDB;User Id=sa;Password=YourPassword123!;TrustServerCertificate=True;"
}
```
### 5️⃣ Aplicar as Migrations
```
dotnet ef database update
```
### 6️⃣ Executar o Projeto
```
dotnet run
```
A aplicação estará disponível em:
👉 https://localhost:5001
---
🧩 Funcionalidades
Página inicial com apresentação pessoal

Listagem dinâmica de projetos

Área administrativa para CRUD de projetos

Formulário de contato com persistência no banco

Design responsivo e moderno
---
🧠 Conceitos Aplicados
Padrão MVC (Model-View-Controller)

Injeção de dependências

Mapeamento objeto-relacional com Entity Framework Core

Migrations e Seed Data

Consumo de banco SQL via Docker

Boas práticas de organização e separação de camadas
---
🧰 Comandos Úteis
Ação	Comando
Criar migration	dotnet ef migrations add NomeDaMigration
Atualizar banco	dotnet ef database update
Executar projeto	dotnet run
Restaurar pacotes	dotnet restore
Publicar build	dotnet publish -c Release

👨‍💻 Autor
Eric Marques Bighi
[LinkedIn](https://www.linkedin.com/in/eric-bighi/) • [GitHub](https://github.com/Big2109)

