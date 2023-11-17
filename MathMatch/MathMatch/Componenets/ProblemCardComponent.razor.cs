using MathMatch.Models;
using Microsoft.AspNetCore.Components;

namespace MathMatch.Componenets;

public class ProblemCard_razor: ComponentBase
{
    [Inject] public CardSelection cardSelection { get; set; }
    [Parameter] public ProblemCard CardValue { get; set; }

    public async void selectCard()
    {
        if (CardValue.solved == true)
        {
            return;
        }
        cardSelection.OnChange += OnChangeHandler;
        cardSelection.selectProblem(CardValue);
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