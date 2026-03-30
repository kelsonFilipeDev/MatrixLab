# Exercício 5 — Diferença de duas matrizes 3×3

## Enunciado
Ler valores para duas matrizes do tipo inteiro de ordem 3.
Gerar e imprimir a matriz DIFERENÇA.

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise5.cshtml` | Interface — duas grelhas 3×3 lado a lado e resultado |
| `Pages/Exercise5.cshtml.cs` | Lógica — binding de duas matrizes e cálculo da diferença |

---

## Fluxo de execução
```
GET /Exercise5
  → OnGet() chamado
  → MatrixA e MatrixB inicializadas com GenerateRandom()

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → MatrixA e MatrixB substituídas por novas gerações aleatórias

POST (Executar)
  → OnPostExecute() chamado
  → Iteração dupla sobre as duas matrizes
  → Diferença elemento a elemento: MatrixA[i][j] - MatrixB[i][j]
  → Result exibido como matriz DIFERENÇA
```

---

## Lógica principal

### Cálculo da diferença
```csharp
for (int i = 0; i < 3; i++)
for (int j = 0; j < 3; j++)
    Result.Add(MatrixA[i][j] - MatrixB[i][j]);
```
- Iteração sincronizada sobre as duas matrizes
- Subtração elemento a elemento na mesma posição [i][j]
- Resultado pode ser negativo — comportamento esperado e correcto

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| Estrutura idêntica ao Exercício 4 | Consistência e reutilização de padrão — KISS |
| Operador `−` no layout | Clareza visual da operação a ser executada |
| Sem restrição de valores negativos | YAGNI — o enunciado não impõe restrição |
