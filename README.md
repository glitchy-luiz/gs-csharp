# 🌍 Analisador de planetas
Projeto desenvolvido em .NET (Console App) com foco em **Programação Orientada a Objetos (POO)**, arquitetura em camadas e boas práticas de desenvolvimento.

O sistema permite que o usuário insira dados de um planeta fictício e receba uma análise de habitabilidade com base em parâmetros científicos simplificados, além de comparação com planetas reais.

---

## Objetivo

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

## Tecnologias Utilizadas

- C# (.NET Console Application)
- .NET com suporte à Injeção de Dependência (`Microsoft.Extensions.DependencyInjection`)
- Programação Orientada a Objetos

---

## Arquitetura do Projeto

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

### Diagrama
<img width="2815" height="2268" alt="Mermaid-preview" src="https://github.com/user-attachments/assets/b7c97e17-a2b1-487a-a15a-79f6b969490d" />


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

---

## Funcionalidades
O sistema permite:

### Criar planeta

Entrada de dados via console:

- Tipo
- Temperatura
- Gravidade
- Pressão atmosférica
- Presença de oxigênio


### Criação de planeta com seleção de tipo
O usuário pode escolher o tipo do planeta:

- Terrestre
- Gasoso

Cada tipo possui comportamento próprio na análise de habitabilidade.

### Análise de habitabilidade

- Cálculo de score (0–100)
- Classificação:
  - Inabitável
  - Baixa
  - Moderada
  - Alta
- Explicação detalhada baseada em:
  - Temperatura
  - Gravidade
  - Atmosfera

### Comparação com planetas reais

O sistema compara o planeta criado com planetas pré-definidos:

- 🌍 Terrestres:
  - Terra
  - Marte
  - Vênus

- 🌪 Gasosos:
  - Júpiter
  - Saturno

A comparação é feita apenas entre planetas do mesmo tipo.

### Histórico de análises

Registro com:
Nome do planeta
Score
Classificação
Data (DateTime)

### Menu interativo
```
1 - Criar planeta
2 - Ver histórico
3 - Ver planetas base
0 - Sair
```

---

## Evidências e Exemplo de uso

### Menu
<img width="201" height="125" alt="image" src="https://github.com/user-attachments/assets/eec481e1-b94b-43fd-a740-249cad59d3b6" />

### Criar Planeta
<img width="544" height="571" alt="image" src="https://github.com/user-attachments/assets/61dab025-1035-4695-8f2a-a35da8b97e78" />

### Histórico
<img width="304" height="346" alt="image" src="https://github.com/user-attachments/assets/9caedde5-d225-475f-97bc-bdffc2d24b90" />

### Planetas Base
<img width="262" height="630" alt="image" src="https://github.com/user-attachments/assets/64f02afd-26d1-42ce-9a02-69d6eda6cf4b" />


---

## Integrantes do grupo
- Guilherme Flores Pereira de Almeida RM554948
- Luiz Fernando de Aragão Souza RM555561
- Bruno Otavio Silva De Oliveira RM556196
- Marcello de Freitas Moreira RM557531
- Leonardo Gonçalves Novaes RM554807
