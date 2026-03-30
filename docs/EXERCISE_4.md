# Exercício 4 — Soma de duas matrizes 2×2

## Enunciado
Ler valores inteiros em uma matriz A[2][2] e em uma matriz B[2][2].
Gerar e imprimir a matriz SOMA[2][2].

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise4.cshtml` | Interface — duas grelhas 2×2 lado a lado e resultado |
| `Pages/Exercise4.cshtml.cs` | Lógica — binding de duas matrizes e cálculo da soma |

---

## Fluxo de execução
```
GET /Exercise4
  → OnGet() chamado
  → MatrixA e MatrixB inicializadas com GenerateRandom()

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → MatrixA e MatrixB substituídas por novas gerações aleatórias

POST (Executar)
  → OnPostExecute() chamado
  → Iteração dupla sobre as duas matrizes
  → Soma elemento a elemento: MatrixA[i][j] + MatrixB[i][j]
  → Result exibido como matriz SOMA
```

---

## Lógica principal

### Cálculo da soma
```csharp
for (int i = 0; i < 2; i++)
for (int j = 0; j < 2; j++)
    Result.Add(MatrixA[i][j] + MatrixB[i][j]);
```
- Iteração sincronizada sobre as duas matrizes
- Soma elemento a elemento na mesma posição [i][j]

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| Dois `[BindProperty]` separados | Binding independente de cada matriz via `name="MatrixA[i][j]"` e `name="MatrixB[i][j]"` |
| Layout lado a lado com operador `+` | Clareza visual — o utilizador percebe imediatamente a operação |
| `GenerateRandom()` estático partilhado | KISS — mesma lógica, sem duplicação |
