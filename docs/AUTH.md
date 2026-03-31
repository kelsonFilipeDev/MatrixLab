# Autenticação — Login e Sessão

## Abordagem
Login simples com credenciais fixas no código e sessão HTTP.
Sem base de dados, sem registo, sem roles — KISS.

---

## Ficheiros criados

| Ficheiro | Responsabilidade |
|---|---|
| `Pages/Login.cshtml` | Interface — formulário de login |
| `Pages/Login.cshtml.cs` | Lógica — validação de credenciais e início de sessão |
| `Pages/Logout.cshtml.cs` | Lógica — limpeza de sessão e redireccionamento |
| `Pages/BasePage.cs` | Classe base — protecção de páginas autenticadas |

---

## Fluxo de autenticação
```
GET /Login
  → Se sessão activa → redireciona para /Index
  → Caso contrário → renderiza formulário

POST /Login
  → Valida username e password contra constantes
  → Se válido → Session["auth"] = "true" → redireciona para /Index
  → Se inválido → Error = true → mostra mensagem de erro

GET /Logout
  → Session.Clear()
  → Redireciona para /Login

Qualquer página protegida
  → OnGet() chama CheckAuth()
  → Se Session["auth"] != "true" → redireciona para /Login
```

---

## Protecção de páginas
```csharp
// BasePage.cs
public IActionResult CheckAuth()
{
    if (HttpContext.Session.GetString("auth") != "true")
        return RedirectToPage("/Login");

    return Page();
}

// Cada página protegida herda BasePage
public class IndexModel : BasePage
{
    public IActionResult OnGet() => CheckAuth();
}
```

---

## Credenciais

| Campo | Valor |
|---|---|
| Username | `admin` |
| Password | `admin123` |

---

## Decisões técnicas

| Decisão | Justificação |
|---|---|
| Credenciais fixas em constantes | KISS — sem base de dados desnecessária |
| `Session` do ASP.NET Core | Nativo, sem dependências externas |
| `BasePage` como classe base | DRY — lógica de autenticação num só lugar |
| `Session.Clear()` no logout | Garante limpeza total da sessão |
| Timeout de 30 minutos | Segurança mínima sem prejudicar UX |
