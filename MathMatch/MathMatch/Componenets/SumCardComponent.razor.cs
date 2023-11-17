using MathMatch.Componenets;
using MathMatch.Logic;
using MathMatch.Models;
using Microsoft.AspNetCore.Components;

namespace MathMatch.Componenets;

public class SumCard_razor : ComponentBase
{
[Inject] public CardSelection cardSelection { get; set; }
[Parameter] public SumCard CardValue { get; set; }
[Parameter] public string classValue { get; set; }

public void selectCard()
{
    if (CardValue.solved == true)
    {
        return;
    }
    cardSelection.OnChange += OnChangeHandler;
    cardSelection.selectSum(CardValue);
    
}
public string ClassValue()
{
    if (CardValue.solved == true)
    {
        return "solvedCard";
    }
    else if (CardValue.flipped)
    {
        return "selectedCard"; 
    }
    else
    {
        return "unselectedCard";
    }
}
private async void OnChangeHandler()
{
    await InvokeAsync(StateHasChanged);
    cardSelection.OnChange -= OnChangeHandler;
}
}