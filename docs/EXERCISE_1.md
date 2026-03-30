# Exercício 1 — Matriz 10×10

## Enunciado
Leia os elementos de uma matriz do tipo inteiro com tamanho 10×10. Ao final, imprima todos os elementos.

---

## Stack utilizada
- ASP.NET Core 10 — Razor Pages
- C# com LINQ
- HTML + CSS customizado (White Smoke, Dodger Blue, Navy Blue)

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise1.cshtml` | Interface — grelha de inputs e resultado |
| `Pages/Exercise1.cshtml.cs` | Lógica — geração aleatória, binding e execução |
| `wwwroot/css/site.css` | Estilos globais da exercise page |

---

## Fluxo de execução
```
GET /Exercise1
  → OnGet() chamado
  → Matrix inicializada com GenerateRandom()
  → View renderiza 100 inputs preenchidos

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → Matrix substituída por nova geração aleatória

POST (Executar)
  → OnPostExecute() chamado
  → Result preenchido via SelectMany
  → View exibe resultado
```

---

## Lógica principal

### Geração aleatória
```csharp
private static int[][] GenerateRandom()
{
    var rng = new Random();
    return Enumerable.Range(0, 10)
        .Select(_ => Enumerable.Range(0, 10)
            .Select(_ => rng.Next(1, 100)).ToArray())
        .ToArray();
}
```

### Model Binding
```csharp
[BindProperty]
public int[][] Matrix { get; set; }
```

### Execução
```csharp
public void OnPostExecute()
{
    Result = Matrix.SelectMany(row => row).ToList();
}
```

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| `int[][]` em vez de `int[,]` | Razor Pages faz binding via `name="Matrix[i][j]"` |
| `SelectMany` para imprimir | LINQ simples — KISS |
| Dados random editáveis | Requisito: misto random + edição manual |
| Uma página por exercício | SRP — separação clara de responsabilidades |
