using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class TriggerInteraction : MonoBehaviour
{
    public Canvas MenuUI;
    private Menu menu;
    private bool onLevelTrigger = false;
    private string triggerName = string.Empty;

    private void Start()
    {
        menu = MenuUI.GetComponent<Menu>();
    }

    private void Update()
    {
        if (onLevelTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(menu.LoadLevel(triggerName));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DialogueTrigger>(out DialogueTrigger dialogue))
        {
            onLevelTrigger = true;
            triggerName = collision.gameObject.name;
            StartCoroutine(dialogue.TriggerDialogue());
        }
        else if (collision.gameObject.TryGetComponent<MultipleChoiceTrigger>(out MultipleChoiceTrigger trigger))
        {
            trigger.TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DialogueTrigger>(out DialogueTrigger dialogue))
        {
            onLevelTrigger = false;
            triggerName = string.Empty;
            dialogue.CloseDialogue();
        }
        else if (collision.gameObject.TryGetComponent<MultipleChoiceTrigger>(out MultipleChoiceTrigger trigger))
        {
            trigger.CloseDialogue();
        }
    }
}