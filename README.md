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
|-- AutoMapper
|-- Controllers
|-- Docker
|-- Enums
|-- Extensions
|-- frontend
|   |-- header
|   |   `-- components
|   |-- landing
|   |   `-- components
|   |-- menu
|   |   `-- components
|   |-- modals
|   |   `-- components
|   `-- particles
|       `-- components
|-- Models
|-- Properties
|-- Repositories
|   `-- Interfaces
|-- Services
|   `-- Interfaces
|-- Settings
|-- SQL
|   `-- Poc
|       |-- Procedures
|       `-- Tables
|-- ViewModels
|-- Views
|   |-- Configuracao
|   |-- Home
|   |-- Login
|   |-- Poc
|   `-- Shared
`-- wwwroot
    |-- css
    |-- dist
    |-- img
    |   `-- logo
    `-- lib
        |-- bootstrap
        |   `-- dist
        |       |-- css
        |       `-- js
        |-- jquery
        |   `-- dist
        |-- jquery-validation
        |   `-- dist
        `-- jquery-validation-unobtrusive
            `-- dist

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
