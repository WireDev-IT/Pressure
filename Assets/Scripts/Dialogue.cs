using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
	public string ButtonText = "Weiter";

	public string Title = string.Empty;

	[TextArea(3, 4)]
	public string[] Messages = Array.Empty<string>();
}