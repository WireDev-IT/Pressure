using System.Collections.Generic;

public class PositioningChallenge : BaseChallenge
{
	public PositioningChallenge()
	{
	}

	public Dictionary<int, object> Positions { get; set; } = new();
}