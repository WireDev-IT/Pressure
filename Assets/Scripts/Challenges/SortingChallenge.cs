using System;

public class SortingChallenge : BaseChallenge
{
	public SortingChallenge()
	{
	}

	public string[] AnswersInOrder { get; set; } = new string[0];

	public string[] GetShuffledAnswers()
	{
        Random rng = new();
        string[] shuffled = AnswersInOrder;
        int n = shuffled.Length;
        string temp;

        while (n > 1)
        {
            int k = rng.Next(n--);
            temp = shuffled[n];
            shuffled[n] = shuffled[k];
            shuffled[k] = temp;
        }

        return shuffled;
    }
}