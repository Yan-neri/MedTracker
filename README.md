# 💊 MedTracker CLI

![Version](https://img.shields.io/badge/version-1.0.0-blue.svg)
![Build Status](https://github.com/Yan-neri/MedTracker/actions/workflows/ci.yml/badge.svg)

> Uma aplicação simples de linha de comando (CLI) para auxiliar no controle e validade de medicamentos, garantindo mais segurança para pacientes e cuidadores.

---

## 🎯 O Problema (A Dor Real)

O controle inadequado de medicamentos é um problema grave na rotina de idosos, pessoas com doenças crônicas e seus cuidadores. A desorganização pode levar ao uso de remédios vencidos ou ao esquecimento de horários, o que compromete tratamentos e gera riscos reais à saúde. Muitas ferramentas atuais são complexas ou cheias de distrações visuais, dificultando o uso rápido e objetivo no dia a dia de quem tem pouco tempo.

## 💡 A Solução e Público-Alvo

O **MedTracker** é uma solução CLI (Command Line Interface) minimalista focada em resolver essa dor de forma direta e sem distrações. O público-alvo são **cuidadores familiares e pacientes com autonomia** que precisam de um registro rápido e confiável do seu estoque de remédios. 

A aplicação permite cadastrar os medicamentos e alerta automaticamente se algum deles estiver vencido ou próximo do vencimento (prazo de 7 dias), evitando o consumo acidental de itens fora da validade.

---

## ⚙️ Funcionalidades Principais

* **Cadastro de medicamentos** com validação estrita de regras de negócio (impede cadastro de itens já vencidos ou sem nome).
* **Listagem completa** do estoque atual de remédios de forma legível.
* **Sistema de alerta automático** inteligente para medicamentos vencendo nos próximos 7 dias.

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C# (.NET 10.0)
* **Interface:** CLI (Command Line Interface)
* **Testes Automatizados:** xUnit
* **CI/CD:** GitHub Actions (Validação contínua de Lint e Testes)

---

## 🚀 Como Executar o Projeto

Para rodar este projeto na sua máquina, você precisará do [.NET SDK 10.0](https://dotnet.microsoft.com/download) instalado.

**1. Clone o repositório e acesse a pasta:**
```bash
git clone [https://github.com/SEU_USUARIO_DO_GITHUB/MedTracker.git](https://github.com/SEU_USUARIO_DO_GITHUB/MedTracker.git)
cd MedTracker