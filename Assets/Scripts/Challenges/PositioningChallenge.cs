using System.Collections.Generic;
using System;

[Serializable]
public class PositioningChallenge : BaseChallenge
{
	public Dictionary<int, object> Positions { get; set; } = new();
}