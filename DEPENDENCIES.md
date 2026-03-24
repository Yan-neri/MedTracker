# Declaração de Dependências (Dependencies)

Este documento detalha as dependências e pacotes NuGet utilizados nesta solução C# (.NET 10.0), para fins de fácil visualização na raiz do repositório.

## 1. Projeto Principal (`MedTracker.CLI/MedTracker.CLI.csproj`)
O projeto de linha de comando foi construído utilizando os recursos nativos do framework, visando alta performance e zero dependências externas de terceiros.
* **Framework:** `.NET 10.0`
* **Pacotes NuGet:** Nenhum pacote externo exigido.

## 2. Projeto de Testes (`MedTracker.Tests/MedTracker.Tests.csproj`)
O projeto de testes automatizados contém as seguintes dependências instaladas via NuGet para garantir a qualidade do código principal:
* **xunit** (v2.9.3) - Framework central de testes.
* **xunit.runner.visualstudio** (v3.1.4) - Executor dos testes.
* **Microsoft.NET.Test.Sdk** (v17.14.1) - SDK base de testes da Microsoft.
* **coverlet.collector** (v6.0.4) - Ferramenta para cobertura de código.

> *Nota técnica: Conforme o padrão oficial da arquitetura .NET, as referências reais dos pacotes estão injetadas diretamente nos arquivos `.csproj` de cada respectiva pasta.*