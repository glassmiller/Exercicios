// Index.cshtml.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    [BindProperty]
    public decimal? CustoFinal { get; set; }

    public IActionResult OnPost(decimal custoFabrica)
    {
        // Constantes para porcentagens
        const decimal percentualDistribuidor = 0.28m;
        const decimal percentualImpostos = 0.45m;

        // Calcular o custo final
        decimal custoDistribuidor = custoFabrica * percentualDistribuidor;
        decimal custoImpostos = custoFabrica * percentualImpostos;
        CustoFinal = custoFabrica + custoDistribuidor + custoImpostos;

        return Page();
    }
}
