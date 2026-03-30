# Exercício 3 — Matriz 5×5, posições par

## Enunciado
Armazenar dados inteiros em uma matriz de ordem 5 e imprimir todos os elementos
em posições cuja linha mais coluna formam um número par.

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise3.cshtml` | Interface — grelha 5×5 com highlight nas posições par |
| `Pages/Exercise3.cshtml.cs` | Lógica — filtragem por condição linha + coluna par |

---

## Fluxo de execução
```
GET /Exercise3
  → OnGet() chamado
  → Matrix 5×5 inicializada com GenerateRandom()
  → Células com (i+j) par destacadas visualmente

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → Matrix substituída por nova geração aleatória

POST (Executar)
  → OnPostExecute() chamado
  → Iteração dupla sobre a matriz
  → Elementos filtrados onde (i + j) % 2 == 0
  → Result exibido com posição e valor
```

---

## Lógica principal

### Filtragem
```csharp
for (int i = 0; i < 5; i++)
for (int j = 0; j < 5; j++)
{
    if ((i + j) % 2 == 0)
        Result.Add(new MatrixEntry(i, j, Matrix[i][j]));
}
```
- Condição `(i + j) % 2 == 0` determina se a soma é par
- `MatrixEntry` é um `record` que agrupa linha, coluna e valor

### Record auxiliar
```csharp
public record MatrixEntry(int Row, int Col, int Value);
```
- Estrutura imutável e simples — KISS
- Evita criar uma classe separada — YAGNI

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| `record MatrixEntry` | Estrutura leve para agrupar dados sem overhead de classe |
| Highlight visual no input | Feedback imediato ao utilizador de quais células serão filtradas |
| `result-tag` com posição `[i, j]` | Clareza no resultado — o utilizador sabe exactamente de onde vem cada valor |
