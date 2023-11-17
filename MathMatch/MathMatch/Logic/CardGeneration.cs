using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;
using MathMatch.Models;
namespace MathMatch.Logic;

public class CardGeneration
{
    Random randomNum = new Random();

    public event Action OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
    
    public void MathGenerator()
    {
        MathProblemGenerator(8);
        SumRandomize();
        
    }
    public List<ProblemCard> MathProblems = new List<ProblemCard>();
    public List<SumCard> MathSums = new List<SumCard>();
    public List<SumCard> RandomSums = new List<SumCard>();
    public void MathProblemGenerator(int numberOfProblems)
    {
        MathProblems = new List<ProblemCard>();
        MathSums = new List<SumCard>();
        for (int i = 0; i < numberOfProblems; i++)
        {
            int addend1 = randomNum.Next(0, 99);
            int addend2 = randomNum.Next(0, 99);
            SumGenerator(addend1, addend2);
            ProblemCard newProblemCard = new ProblemCard();
            newProblemCard.mathProblem = $"{addend1} + {addend2}";
            newProblemCard.flipped = false;
            newProblemCard.solved = false;
            MathProblems.Add(newProblemCard);
        }
        NotifyStateChanged();
    }

    public void SumGenerator(int addend1, int addend2)
    {
        
        SumCard newSumCard = new SumCard();
        newSumCard.mathProblem = $"{addend1} + {addend2}";
        newSumCard.sum = addend1 + addend2;
        newSumCard.solved = false;
        newSumCard.flipped = false;
        MathSums.Add(newSumCard);
    }

    public void SumRandomize()
    {
        RandomSums = new List<SumCard>();
        while (MathSums.Count() > 0)
        {
            int index = randomNum.Next(0, (MathSums.Count() -1));
            SumCard sumCardFromMathSum = new SumCard();
            sumCardFromMathSum = MathSums.ElementAt(index);
            RandomSums.Add(sumCardFromMathSum);
            MathSums.RemoveAt(index);
            
        }
        NotifyStateChanged();
    }
    
}