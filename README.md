# Playwright Evolution: Professional Testing & AI Agents

Este repositório foi criado como parte do meu aprendizado no **MBA em Engenharia de IA Aplicada**. O objetivo é demonstrar a evolução das ferramentas de automação de testes, comparando a abordagem clássica de desenvolvimento com a automação moderna impulsionada por Agentes de IA via **MCP (Model Context Protocol)**.

## 🚀 Estrutura do Projeto

O repositório está dividido em dois ecossistemas principais:

### 1. `./playwright-dotnet` (Abordagem Tradicional)
Focado em um ambiente de desenvolvimento robusto utilizando **C# e NUnit**. 
- **Tecnologias:** .NET Core, Playwright for .NET, NUnit.
- **Destaque:** Implementação de testes resilientes utilizando `Locators` (como `GetByRole`) e automação de fluxos críticos de negócio.
- **Ideal para:** Pipelines de CI/CD e garantia de qualidade (QA) em larga escala.

### 2. `./playwright-mcp-ai` (Agentes de IA)
Explora o uso do Playwright como uma ferramenta para modelos de linguagem (LLMs).
- **Tecnologias:** Node.js, Playwright MCP Server, Claude/Cursor.
- **Destaque:** Uso do **Model Context Protocol** para permitir que a IA interaja diretamente com o navegador para gerar scripts de teste dinamicamente.
- **Diferencial:** Inclui prompts estruturados para geração de testes idempotentes e configuração de CI com GitHub Actions específica para Chromium.

---

## 🧠 O que é MCP (Model Context Protocol)?

Nesta seção, explorei como o Playwright deixa de ser apenas uma biblioteca e passa a ser um "braço" para a IA. O servidor MCP permite:
- Que a IA execute ações em tempo real no navegador local.
- Inspeção dinâmica do DOM para evitar seletores frágeis.
- Geração autônoma de suítes de teste baseadas em cenários de negócio descritos em Markdown.

---

## 🛠️ Como rodar

### .NET
1. `cd playwright-dotnet`
2. `dotnet build`
3. `dotnet test`

### AI/MCP Setup
1. Instale o MCP Server: `npx @playwright/mcp@latest --extension`
2. Configure seu `example.mcp.json` na sua ferramenta de IA (Cursor/Claude).
3. Utilize os prompts contidos em `generate_test.prompt.md` para criar novos cenários.

---

**Desenvolvido por um Full Stack Developer apaixonado por C# e agora moldando o futuro com IA.**
