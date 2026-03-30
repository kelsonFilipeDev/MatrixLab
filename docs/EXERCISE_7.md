# Exercício 7 — Trocas em matriz 5×5

## Enunciado
Ler e armazenar os elementos de uma matriz inteira 5×5 e imprimi-la.
Trocar:
- A 2ª linha pela 5ª
- A 3ª coluna pela 5ª
- A diagonal principal pela diagonal secundária

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Exercise7.cshtml` | Interface — grelha 5×5 de inputs e resultado |
| `Pages/Exercise7.cshtml.cs` | Lógica — três operações de troca sobre a matriz |

---

## Fluxo de execução
```
GET /Exercise7
  → OnGet() chamado
  → Matrix 5×5 inicializada com GenerateRandom()

POST (Gerar Aleatório)
  → OnPostGenerate() chamado
  → Matrix substituída por nova geração aleatória

POST (Executar)
  → OnPostExecute() chamado
  → Cópia profunda da matriz original
  → Operação 1: troca de linhas
  → Operação 2: troca de colunas
  → Operação 3: troca de diagonais
  → Result exibido como matriz resultante
```

---

## Lógica principal

### Cópia profunda
```csharp
int[][] m = Matrix.Select(row => row.ToArray()).ToArray();
```
- Evita mutação do original durante as operações
- `ToArray()` por linha garante cópia real e não referência

### Troca de linhas
```csharp
(m[1], m[4]) = (m[4], m[1]);
```
- Tuple deconstruction do C# — swap sem variável temporária

### Troca de colunas
```csharp
for (int i = 0; i < 5; i++)
    (m[i][2], m[i][4]) = (m[i][4], m[i][2]);
```
- Percorre cada linha e troca os elementos nas colunas 2 e 4

### Troca de diagonais
```csharp
for (int i = 0; i < 5; i++)
    (m[i][i], m[i][4 - i]) = (m[i][4 - i], m[i][i]);
```
- Diagonal principal: `m[i][i]`
- Diagonal secundária: `m[i][4 - i]`
- Troca simultânea via tuple deconstruction

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| Cópia profunda antes das operações | Evita efeitos colaterais entre as três trocas |
| Tuple deconstruction para swap | C# moderno, sem variável temporária — Clean Code |
| Operações sequenciais e independentes | Cada troca é isolada e legível — SRP |
