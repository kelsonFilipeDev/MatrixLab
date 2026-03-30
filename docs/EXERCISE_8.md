# Exercício 8 — Matriz de vendas 12×4

## Enunciado
Carregar uma matriz 12×4 com valores de vendas de uma loja.
Cada linha representa um mês do ano, cada coluna uma semana do mês.
Calcular e imprimir:
- Total vendido em cada mês
- Total vendido em cada semana durante todo o ano
- Total vendido no ano

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise8.cshtml` | Interface — tabela 12×4 de inputs e três secções de resultado |
| `Pages/Exercise8.cshtml.cs` | Lógica — cálculo de totais por mês, semana e ano |

---

## Fluxo de execução
```
GET /Exercise8
  → OnGet() chamado
  → Matrix 12×4 inicializada com GenerateRandom()

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → Matrix substituída por nova geração aleatória

POST (Executar)
  → OnPostExecute() chamado
  → Total por mês: soma de cada linha
  → Total por semana: soma de cada coluna
  → Total anual: soma de todos os totais mensais
  → Result exibido em três tabelas distintas
```

---

## Lógica principal

### Total por mês
```csharp
var monthTotals = Matrix.Select(row => row.Sum()).ToArray();
```
- Cada linha é um mês — `.Sum()` soma as 4 semanas

### Total por semana
```csharp
var weekTotals = Enumerable.Range(0, 4)
    .Select(j => Matrix.Sum(row => row[j]))
    .ToArray();
```
- Itera por coluna (semana) e soma todos os meses

### Total anual
```csharp
var yearTotal = monthTotals.Sum();
```
- Soma de todos os totais mensais

### Record auxiliar
```csharp
public record SalesResult(int[] MonthTotals, int[] WeekTotals, int YearTotal);
```
- Agrupa os três resultados num único objecto imutável

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| Tabela HTML em vez de grelha CSS | Dados tabulares com cabeçalhos — semântica correcta |
| Nomes dos meses em array fixo | KISS — sem lógica de formatação de datas desnecessária |
| `record SalesResult` | Agrupa resultados sem overhead de classe — YAGNI |
| Valores aleatórios entre 100 e 9999 | Simula valores realistas de vendas |
