# Exercício 9 — Vendas por mês e produto

## Enunciado
Cada linha da matriz representa o total de produtos vendidos ao mês por uma loja
que trabalha com cinco tipos diferentes de produtos.
Calcular e apresentar:
- Total de produtos vendidos em cada mês
- Total de vendas por ano por produto

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise9.cshtml` | Interface — tabela 12×5 de inputs e dois blocos de resultado |
| `Pages/Exercise9.cshtml.cs` | Lógica — cálculo de totais por mês e por produto |

---

## Fluxo de execução
```
GET /Exercise9
  → OnGet() chamado
  → Matrix 12×5 inicializada com GenerateRandom()

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → Matrix substituída por nova geração aleatória

POST (Executar)
  → OnPostExecute() chamado
  → Total por mês: soma de cada linha (5 produtos)
  → Total por produto: soma de cada coluna (12 meses)
  → Result exibido em duas tabelas distintas
```

---

## Lógica principal

### Total por mês
```csharp
var monthTotals = Matrix.Select(row => row.Sum()).ToArray();
```
- Cada linha é um mês — `.Sum()` soma os 5 produtos

### Total anual por produto
```csharp
var productTotals = Enumerable.Range(0, 5)
    .Select(j => Matrix.Sum(row => row[j]))
    .ToArray();
```
- Itera por coluna (produto) e soma todos os 12 meses

### Record auxiliar
```csharp
public record SalesResult(int[] MonthTotals, int[] ProductTotals);
```
- Agrupa os dois resultados num único objecto imutável

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| Estrutura idêntica ao Exercício 8 | Consistência e reutilização de padrão — KISS |
| Cabeçalhos dinâmicos `Produto @(j+1)` | Evita array fixo desnecessário — YAGNI |
| Valores aleatórios entre 10 e 499 | Simula quantidades realistas de produtos vendidos |
