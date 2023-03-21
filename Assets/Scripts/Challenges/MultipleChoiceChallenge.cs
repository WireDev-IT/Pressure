using System;

[Serializable]
public class MultipleChoiceChallenge : BaseChallenge
{
    public string[] Answers = new string[3];
	public int CorrectAnswer = 0;
}