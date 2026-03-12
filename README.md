Playwright Evolution: From C# Integration to AI Agents 🚀

Este repositório demonstra a implementação de um ecossistema completo de cadastro de usuários, integrando Clean Code, DDD (Domain-Driven Design) e automação de testes de última geração. O projeto destaca a transição de testes de integração tradicionais para a utilização de Agentes de IA via MCP (Model Context Protocol).
🛠️ Tecnologias e Arquitetura
Back-End (C# / .NET 10)

Arquitetura robusta baseada em Clean Architecture:

    Domain: Entidades de negócio e regras fundamentais.

    Application: Orquestração de casos de uso e DTOs.

    Infrastructure: Persistência com EF Core, Migrations automatizadas e integração com a API do ViaCEP.

    API: Endpoints RESTful com suporte a CORS para integração com SPAs.

Front-End (React + Vite)

Interface moderna e responsiva:

    Consumo de API assíncrona com Axios.

    Busca dinâmica de endereço via CEP com estados de loading e error handling.

    Campos otimizados com seletores semânticos para facilitar a automação por IA.

Infraestrutura (Docker)

    SQL Server 2022: Ambiente de banco de dados conteinerizado, garantindo que o teste de integração seja fiel ao ambiente de produção.

🧪 Estratégia de Testes
1. Clássico (./tests-classic)

    Scripts determinísticos focados em estabilidade e regressão.

    Validação direta da persistência no banco de dados.

2. IA Agent Testing (./tests-mcp)

    Navegação Autônoma: O Agente de IA utiliza o servidor MCP para explorar o DOM e interagir com elementos em tempo real.

    Resiliência: Testes que se adaptam a mudanças de layout sem necessidade de refatoração imediata de código.

🏃 Como Rodar o Projeto
1. Infraestrutura e Banco
Bash

# Subir o banco de dados
docker compose up -d

# Aplicar migrações (na raiz do projeto)
dotnet ef database update --project CadastroUsuario.Infrastructure --startup-project CadastroUsuario.Api

2. Execução dos Serviços

Terminal 1 (Back-End):
Bash

cd CadastroUsuario.Api
dotnet run

Terminal 2 (Front-End):
Bash

cd frontend
npm install
npm run dev

3. Configuração do Agente (MCP)

Adicione o servidor ao seu ambiente de IA (Claude/Cursor):
JSON

"playwright": {
  "command": "npx",
  "args": ["@playwright/mcp@latest", "--extension"]
}

🤖 Prompt de Teste (Agente de IA)

Para validar o fluxo completo utilizando o Agente de IA, utilize o prompt abaixo no seu assistente configurado com MCP:

    "IA, ative o servidor Playwright MCP e execute este teste no meu ambiente local:

        Vá para a URL do Front-end (ex: http://localhost:5173).

        Preencha o formulário com dados de teste (Nome, Email e CEP).

        Clique no botão de busca (lupa) e aguarde a resposta da API C#.

        Verifique se o endereço foi preenchido corretamente.

        Clique em 'Salvar no Banco' e confirme o alerta de sucesso."