using MathMatch.Models;
namespace MathMatch;


public class CardSelection
{
    private SumCard? comparisonSum = null;
    private ProblemCard? comparisonProblem = null;
    public event Action OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
    public void selectSum(SumCard forFlip)
    {
        
        if (forFlip.flipped == false && comparisonSum == null && comparisonProblem == null )
        {
            comparisonSum = forFlip;
            forFlip.flipped = true;
        }
        else if(forFlip.flipped == false && comparisonSum == null && comparisonProblem != null)
        {
            comparisonSum = forFlip;
            forFlip.flipped = true;
            Compare();
        }
        else if (forFlip.flipped == true)
        {
            comparisonSum = null;
            forFlip.flipped = false;
        }
        else
        {
            forFlip.flipped = false;
        }
        
    }

    public void selectProblem(ProblemCard forFlip)
    {
        if (forFlip.flipped == false && comparisonSum == null && comparisonProblem == null )
        {
            comparisonProblem = forFlip;
            forFlip.flipped = true;
        }
        else if(forFlip.flipped == false && comparisonSum != null && comparisonProblem == null)
        {
            comparisonProblem = forFlip;
            forFlip.flipped = true;
            Compare();
        }
        else if (forFlip.flipped == true)
        {
            comparisonProblem = null;
            forFlip.flipped = false;
        }
        else
        {
            forFlip.flipped = false;
        }
    }
    public void Compare()
    {
        if (comparisonSum.mathProblem == comparisonProblem.mathProblem)
        {
            comparisonProblem.solved = true;
            comparisonSum.solved = true;
            comparisonProblem = null;
            comparisonSum = null;
            NotifyStateChanged();
        }
        else
        {
            
        }
    }
    

}