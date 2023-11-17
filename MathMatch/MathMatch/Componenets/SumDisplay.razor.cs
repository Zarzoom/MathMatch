using MathMatch.Componenets;
using MathMatch.Logic;
using Microsoft.AspNetCore.Components;

namespace MathMatch.Componenets;
public class SumDisplay_razor : ComponentBase
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