# API de Gerenciamento de Alunos

API RESTful desenvolvida com ASP.NET Core Web API utilizando .NET 10, C#, Entity Framework Core, SQL Server e autenticação JWT Bearer Token.

## Objetivo

O projeto tem como objetivo realizar o gerenciamento de alunos através de operações CRUD, permitindo:

- Cadastro de alunos
- Listagem de alunos
- Consulta por ID
- Atualização de dados
- Remoção de alunos
- Autenticação utilizando JWT

## Tecnologias Utilizadas

- .NET 10
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Bearer Authentication
- Swagger

## Estrutura do Projeto

```
AVALIACAO-B1/
│
├── Controllers/
│   ├── AlunosController.cs
│   ├── AuthController.cs
│   └── WeatherForecastController.cs
│
├── Models/
│   └── Aluno.cs
│
├── Data/
│   └── EscolaContext.cs
│
├── Properties/
│   ├── appsettings.Development.json
│   └── appsettings.json
│
├── Program.cs
├── WeatherForecast.cs
├── avaliacao-b1.csproj
└── README.md
```

## Banco de Dados

Banco utilizado: SQL Server

Nome do banco: `EscolaDB`

O projeto utiliza um banco local que pode ser criado durante a execução/migration do projeto.

Script de criação do banco e da tabela:

```sql
CREATE DATABASE EscolaDB;
GO

USE EscolaDB;

CREATE TABLE Alunos
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(150) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    Curso VARCHAR(100) NOT NULL,
    DataNascimento DATE NOT NULL
);
```

## Endpoints

### Endpoints de Alunos

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/alunos` | Lista todos os alunos |
| GET | `/api/alunos/{id}` | Busca aluno por ID |
| POST | `/api/alunos` | Cadastra aluno |
| PUT | `/api/alunos/{id}` | Atualiza aluno |
| DELETE | `/api/alunos/{id}` | Remove aluno |

## Autenticação JWT

Usuário padrão:

```json
{
  "username": "admin",
  "password": "123456"
}
```

Endpoint de Login:

```http
POST /api/auth/login
```

Exemplo de requisição:

```json
{
  "username": "admin",
  "password": "123456"
}
```

Exemplo de resposta:

```json
{
  "token": "TOKEN_JWT"
}
```

Todos os endpoints de alunos utilizam `[Authorize]`.

## Como Executar o Projeto

1. Clonar o repositório:

```bash
git clone https://github.com/claranuneslinhares/avaliacao-b1.git
```

2. Restaurar dependências:

```bash
dotnet restore
```

3. Configurar o banco de dados: editar a connection string no arquivo `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=EscolaDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

4. Executar migrations:

```bash
dotnet ef database update
```

5. Executar o projeto:

```bash
dotnet run
```

6. Acessar o Swagger:

```text
http://localhost:5135/swagger
```

> O endereço do Swagger pode variar conforme a porta usada pelo ASP.NET Core. Use o URL exibido no terminal.

## Testes da API

A API pode ser testada utilizando:

- **Swagger** (já integrado)
- **Postman**
- **Insomnia**
- **REST Client** (extensão do VS Code)

### Usando REST Client (VS Code)

A forma mais simples de testar os endpoints é utilizando a extensão **REST Client** do VS Code:

#### 1. Instalar a Extensão REST Client

- Abra o VS Code
- Vá para **Extensions** (Ctrl + Shift + X)
- Procure por **REST Client** (autor: Huachao Mao)
- Clique em **Install**

#### 2. Usar o arquivo de testes

O projeto contém um arquivo `avaliacao-b1.http` com todos os endpoints pré-configurados:

- Abra o arquivo `avaliacao-b1.http` no VS Code
- Clique no link **Send Request** que aparece acima de cada requisição
- Ou use o atalho de teclado: `Ctrl + Alt + R`

#### 3. Procedimento para Testar

1. **Execute o endpoint de Login primeiro** (POST `/api/auth/login`)
   - Isso retornará um token JWT
   
2. **Copie o token retornado** da resposta

3. **Cole o token** na variável `@token` no arquivo `avaliacao-b1.http`:
   ```http
   @token = seu_token_aqui
   ```

4. **Execute os demais endpoints** para testar as operações CRUD

#### 4. Exemplo de Fluxo de Testes

```
1. Login → Obtenha o token
2. Listar Alunos → GET (sem autenticação ou com token)
3. Criar Aluno → POST (com token)
4. Consultar por ID → GET (com token)
5. Atualizar Aluno → PUT (com token)
6. Remover Aluno → DELETE (com token)
```

## Conceitos Aplicados

- API REST
- CRUD
- Entity Framework Core
- JWT Authentication
- SQL Server
- Controllers
- Modelagem de dados

## Integrantes

- Heliel William Da Silva
- Maria Clara Nunes Linhares
- Raynara Gustavo da Costa
- Riane Ramaiane Delgado de Brito

## Licença

Projeto desenvolvido para fins acadêmicos.
