using MathMatch.Logic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
namespace MathMatch.Componenets;


public class Restart_razor: ComponentBase
{

        public int thisValue = 8;
        public List<int> numOfCardsList = new List<int>();
        [Inject] public CardGeneration CardGen { get; set; }


        protected void UpdatePage(MouseEventArgs obj)
        {
            CardGen.MathProblemGenerator(thisValue);
            CardGen.SumRandomize();
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            numOfCardsList.Add(8);
            numOfCardsList.Add(16);
            numOfCardsList.Add(24);
            numOfCardsList.Add(32);
        }
}