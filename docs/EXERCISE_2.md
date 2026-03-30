# Exercício 2 — Matriz 3×3 multiplicada por 2

## Enunciado
Leia os elementos de uma matriz do tipo inteiro com tamanho 3×3 e imprima os elementos multiplicando por 2.

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise2.cshtml` | Interface — grelha 3×3 de inputs e resultado |
| `Pages/Exercise2.cshtml.cs` | Lógica — geração aleatória, binding e multiplicação |

---

## Fluxo de execução
```
GET /Exercise2
  → OnGet() chamado
  → Matrix 3×3 inicializada com GenerateRandom()

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → Matrix substituída por nova geração aleatória

POST (Executar)
  → OnPostExecute() chamado
  → Cada elemento multiplicado por 2 via LINQ
  → Result exibido na view
```

---

## Lógica principal

### Execução
```csharp
public void OnPostExecute()
{
    Result = Matrix.SelectMany(row => row.Select(val => val * 2)).ToList();
}
```
- `SelectMany` achata a matriz numa lista
- `Select(val => val * 2)` multiplica cada elemento por 2 inline

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| `Select(val => val * 2)` inline | KISS — sem variáveis desnecessárias |
| Mesma estrutura do Exercício 1 | Consistência e reutilização de padrão |
