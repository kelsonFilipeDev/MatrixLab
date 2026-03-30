# MatrixLab

Aplicação web desenvolvida em ASP.NET Core 10 com Razor Pages para demonstração de operações com matrizes em C#.

---

## Stack

- .NET 10 / ASP.NET Core — Razor Pages
- C# com LINQ
- HTML + CSS customizado
- Sem dependências externas de UI

---

## Funcionalidades

| Exercício | Descrição |
|---|---|
| 1 | Leitura e impressão de matriz 10×10 |
| 2 | Matriz 3×3 multiplicada por 2 |
| 3 | Elementos em posições com linha + coluna par |
| 4 | Soma de duas matrizes 2×2 |
| 5 | Diferença de duas matrizes 3×3 |
| 6 | Soma de todos os elementos de matriz 4×5 |
| 7 | Trocas de linhas, colunas e diagonais em matriz 5×5 |
| 8 | Vendas mensais — totais por mês, semana e ano |
| 9 | Vendas por produto — totais mensais e anuais |

---

## Como correr

### Pré-requisitos
- .NET 10 SDK instalado

### Instalação
```bash
git clone git@github.com:kelsonFilipeDev/MatrixLab.git
cd MatrixLab
dotnet run
```

Abre o browser em `http://localhost:5296`

---

## Estrutura do projecto
```
MatrixLab/
├── Pages/
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── Index.cshtml          # Dashboard
│   ├── Exercise1.cshtml      # Exercício 1
│   ├── ...
│   └── Exercise9.cshtml      # Exercício 9
├── wwwroot/
│   └── css/
│       └── site.css
├── docs/
│   ├── EXERCISE_1.md
│   ├── ...
│   └── EXERCISE_9.md
├── Program.cs
└── MatrixLab.csproj
```

---

## Padrões aplicados

- **KISS** — soluções simples e directas
- **YAGNI** — sem funcionalidades desnecessárias
- **SOLID** — separação clara de responsabilidades por página
- **Clean Code** — código legível e sem ruído
- **Documentação contínua** — cada exercício documentado em `docs/`
