using Microsoft.AspNetCore.Components;
using MathMatch.Logic;
namespace MathMatch.Componenets;

public class ProblemDisplay_razor: ComponentBase
{
    [Inject] public CardGeneration CardGen { get; set; }
    
    protected override void OnInitialized()
    {
        CardGen.OnChange += OnChangeHandler;
    }

    private async void OnChangeHandler()
    {
        await InvokeAsync(StateHasChanged);
    }
}