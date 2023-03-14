public class MultipleChoiceChallenge : BaseChallenge
{
	public MultipleChoiceChallenge()
	{
	}

	public string[] Answers { get; set; } = new string[0];
	public int CorrectAnswer { get; set; } = 0;
}