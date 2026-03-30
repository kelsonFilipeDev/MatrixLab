# Exercício 6 — Soma de todos os elementos de uma matriz 4×5

## Enunciado
Ler uma matriz 4×5 de inteiros, calcular e imprimir a soma de todos os seus elementos.

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise6.cshtml` | Interface — grelha 4×5 de inputs e total |
| `Pages/Exercise6.cshtml.cs` | Lógica — binding, soma total via LINQ |

---

## Fluxo de execução
```
GET /Exercise6
  → OnGet() chamado
  → Matrix 4×5 inicializada com GenerateRandom()

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → Matrix substituída por nova geração aleatória

POST (Executar)
  → OnPostExecute() chamado
  → Todos os elementos achatados via SelectMany
  → Soma calculada via Sum()
  → Total exibido em destaque
```

---

## Lógica principal

### Cálculo da soma
```csharp
public void OnPostExecute()
{
    Total = Matrix.SelectMany(row => row).Sum();
}
```
- `SelectMany` achata a matriz numa sequência plana
- `.Sum()` soma todos os elementos em uma linha — KISS

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| `int? Total` nullable | Distingue estado inicial (sem resultado) de resultado zero |
| `.SelectMany().Sum()` | LINQ expressivo e sem loops manuais desnecessários |
| `total-display` em destaque | Resultado único merece destaque visual claro |
