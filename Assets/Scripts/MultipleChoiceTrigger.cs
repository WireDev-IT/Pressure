using UnityEngine;
using System.Collections;
using static System.TimeZoneInfo;

public class MultipleChoiceTrigger : MonoBehaviour
{
	public MultipleChoiceManager manager;

    public void TriggerDialogue()
	{
        manager.Show();
	}

    public void CloseDialogue()
    {
        manager.Hide();
    }
}