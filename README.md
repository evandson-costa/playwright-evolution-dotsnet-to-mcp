Playwright Evolution: From C# Integration to AI Agents 🚀

Este repositório demonstra a implementação de um ecossistema completo de cadastro de usuários, integrando Clean Code, DDD (Domain-Driven Design) e automação de testes moderna. O projeto evolui de testes de integração tradicionais em .NET para a utilização de Agentes de IA via MCP (Model Context Protocol).
🛠️ Tecnologias e Arquitetura
Back-End (C# / ASP.NET Core)

Construído seguindo os princípios de DDD e Clean Architecture:

    Domain: Entidades de negócio e interfaces de contrato.

    Application: Casos de uso e orquestração.

    Infrastructure: Implementação de repositórios com EF Core, integração com API externa (ViaCEP) e acesso ao SQL Server.

    API: Controllers documentadas e preparadas para consumo via Front-End.

Front-End (React + Vite)

Interface moderna para interação com o usuário:

    Busca automática de endereço via CEP (integração via Back-End).

    Formulário validado e preparado para automação.

Infraestrutura (Docker)

    Container SQL Server 2022 configurado para persistência de dados real.

🧪 Estratégia de Testes (Playwright)

O repositório está dividido em duas abordagens de automação:
1. ./tests-classic (Abordagem Profissional)

Testes escritos manualmente em C# / NUnit.

    Focado em CI/CD e estabilidade.

    Validação de ponta a ponta: do clique no React à persistência no SQL Server.

2. ./tests-mcp (AI Agent Testing)

Uso do Playwright MCP Server para permitir que LLMs (como Claude/Cursor) operem o navegador.

    Prompt Driven: Scripts baseados em arquivos Markdown para geração autônoma de testes.

    Dynamic Exploration: A IA utiliza as ferramentas do MCP para inspecionar o DOM em tempo real.

🏃 Como Rodar o Projeto
1. Banco de Dados (Docker)
Bash

docker compose up -d

Certifique-se de que a porta 1433 está livre no host.
2. Back-End
Bash

dotnet tool install --global dotnet-ef
dotnet ef database update --project CadastroUsuario.Infrastructure --startup-project CadastroUsuario.Api
dotnet run --project CadastroUsuario.Api

3. Front-End
Bash

cd frontend
npm install
npm run dev

4. Playwright (MCP)

Certifique-se de que o servidor MCP está configurado no seu ambiente de IA:
JSON

"playwright": {
  "command": "npx",
  "args": ["@playwright/mcp@latest", "--extension"]
}