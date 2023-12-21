using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

public class IndexModel : PageModel
{
    // Exercício 1: Calculadora de Custo de Vehículo
    [BindProperty]
    public decimal? CustoFinalCarro { get; set; }

    // Exercício 2: Calculadora de Salário
    [BindProperty]
    public int HorasTrabalhadas { get; set; }

    [BindProperty]
    public double SalarioPorHora { get; set; }

    [BindProperty]
    public double? SalarioTotal { get; set; }

    public IActionResult OnPostCalcularCustoCarro(decimal custoFabrica)
    {
        // Constantes para porcentagens
        const decimal percentualDistribuidor = 0.28m;
        const decimal percentualImpostos = 0.45m;

        // Calcular o custo final do carro
        decimal custoDistribuidor = custoFabrica * percentualDistribuidor;
        decimal custoImpostos = custoFabrica * percentualImpostos;
        CustoFinalCarro = custoFabrica + custoDistribuidor + custoImpostos;

        return Page();
    }

    public IActionResult OnPostCalcularSalario()
    {
        // Definir a jornada de trabalho semanal e o número de semanas em um mês
        int jornadaSemanal = 40;
        int semanasPorMes = 4;

        // Verificar se há horas extras
        int horasNormais = jornadaSemanal * semanasPorMes;
        int horasExtras = Math.Max(HorasTrabalhadas - horasNormais, 0);

        // Calcular o salário total, incluindo horas extras com um acréscimo de 50%
        SalarioTotal = horasNormais * SalarioPorHora + horasExtras * (SalarioPorHora * 1.5);

        return Page();
    }

    // (Seções dos exercícios anteriores mantidas para referência)

    // Exercício 3: Calculadora de Saldo
    [BindProperty]
    public string NumeroConta { get; set; }

    [BindProperty]
    public decimal Saldo { get; set; }

    [BindProperty]
    public decimal Debito { get; set; }

    [BindProperty]
    public decimal Credito { get; set; }

    [BindProperty]
    public decimal? SaldoAtual { get; set; }

    [BindProperty]
    public string MensagemSaldo { get; set; }

    public IActionResult OnPostCalcularSaldo()
    {
        // Correção: Atribuir um valor padrão para evitar erro CS8618
        MensagemSaldo = string.Empty;

        // Correção: Verificar se o saldo é nulo antes de calcular
        if (SaldoAtual == null)
        {
            SaldoAtual = Saldo - Debito + Credito;

            // Verificar se o saldo atual é maior ou igual a zero
            MensagemSaldo = SaldoAtual >= 0 ? "Saldo Positivo" : "Saldo Negativo";
        }

        return Page();
    }

    
    // Exercício 4: Calcular Maçãs
    [BindProperty]
    public int QuantidadeMacas { get; set; }

    [BindProperty]
    public decimal? CustoTotalMacas { get; set; }

    public IActionResult OnPostCalcularCustoMacas()
    {
        // Verificar o preço por unidade com base na quantidade comprada
        decimal precoUnitario = QuantidadeMacas < 12 ? 1.30m : 1.00m;

        // Calcular o custo total das maçãs
        CustoTotalMacas = QuantidadeMacas * precoUnitario;

        return Page();
    }
}




