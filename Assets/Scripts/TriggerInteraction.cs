using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class TriggerInteraction : MonoBehaviour
{
    public Canvas MenuUI;
    private Menu menu;
    private DialogueTrigger dialogue;
    private bool onTrigger = false;
    private string triggerName = string.Empty;

    private void Start()
    {
        menu = MenuUI.GetComponent<Menu>();
    }

    private void Update()
    {
        if (onTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(menu.LoadLevel(triggerName));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DialogueTrigger>(out dialogue))
        {
            onTrigger = true;
            triggerName = collision.gameObject.name;
            StartCoroutine(dialogue.TriggerDialogue());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DialogueTrigger>(out dialogue))
        {
            onTrigger = false;
            triggerName = string.Empty;
            dialogue.CloseDialogue();
        }
    }
}