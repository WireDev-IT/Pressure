using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}