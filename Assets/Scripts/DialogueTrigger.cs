using UnityEngine;
using System.Collections;
using static System.TimeZoneInfo;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
    public bool AutoStart = false;
    public float Delay = 0;

    private void Start()
    {
        if (AutoStart)
        {
            StartCoroutine(TriggerDialogue());
        }
    }

    public IEnumerator TriggerDialogue()
	{
        yield return new WaitForSeconds(Delay);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}