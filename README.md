# 🌍 Analisador de planetas
Projeto desenvolvido em .NET (Console App) com foco em **Programação Orientada a Objetos (POO)**, arquitetura em camadas e boas práticas de desenvolvimento.

O sistema permite que o usuário insira dados de um planeta fictício e receba uma análise de habitabilidade com base em parâmetros científicos simplificados, além de comparação com planetas reais.

---

## 🎯 Objetivo

O objetivo do projeto é:

- Aplicar conceitos de **POO**
- Estruturar um sistema em **camadas**
- Implementar:
  - Herança
  - Polimorfismo
  - Interfaces
  - Abstração
  - Injeção de Dependência
- Trabalhar com validação de dados e tratamento de exceções
- Simular análise de condições planetárias

---

## ⚙️ Tecnologias Utilizadas

- C# (.NET Console Application)
- .NET com suporte à Injeção de Dependência (`Microsoft.Extensions.DependencyInjection`)
- Programação Orientada a Objetos

---

## 🏗️ Arquitetura do Projeto

O projeto segue uma arquitetura em camadas:
```
├── Program.cs

├── Presentation/
│   ├── Views/
│   │   ├── IConsoleView.cs
│   │   └── ConsoleView.cs
│   │
│   ├── Controllers/
│   │   └── AnaliseController.cs
│
├── Application/
│   ├── Services/
│   │   ├── AnaliseHabitabilidadeService.cs
│   │   ├── ComparadorPlanetarioService.cs
│   │
│   ├── DTOs/
│   │   └── PlanetaInputDto.cs
│   │
│   ├── Interfaces/
│   │   ├── IAnaliseHabitabilidade.cs
│   │   ├── IComparadorPlanetario.cs
│
├── Domain/
│   ├── Entities/
│   │   ├── Planeta.cs
│   │   ├── PlanetaTerrestre.cs
│   │   ├── PlanetaGasoso.cs
│   │
│   ├── ValueObjects/
│   │   ├── Atmosfera.cs
│   │   ├── CondicoesFisicas.cs
│   │
│   ├── Enums/
│   │   ├── TipoPlaneta.cs
│   │   └── ClassificacaoHabitabilidade.cs
│   │
│   ├── Interfaces/
│   │   └── ICalculavelHabitabilidade.cs
│   │
│   ├── Structs/
│   │   └── Coordenadas.cs
│   │
│   ├── Historico/
│   │   └── HistoricoAnalise.cs
│
├── Infrastructure/
│   ├── Repositories/
│   │   └── PlanetaBaseRepository.cs
│
└── Shared/
├── Exceptions/
│   └── InputInvalidoException.cs
│
├── Helpers/
│   └── DateTimeHelper.cs
```

---

## Modelagem do Domínio

### Entidade Principal

- `Planeta` (classe abstrata)
  - Nome
  - Tipo (Terrestre ou Gasoso)
  - Condições físicas
  - Atmosfera
  - Coordenadas

### Herança

- `PlanetaTerrestre`
- `PlanetaGasoso`

### Polimorfismo

Cada tipo de planeta implementa:

```csharp
CalcularScoreHabitabilidade()
```

## Integrantes do grupo
- Bruno
- Guilherme
- Leonardo
- Luiz
- Marcello
