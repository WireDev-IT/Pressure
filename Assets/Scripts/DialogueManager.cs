using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public TMP_Text title;
    public TMP_Text message;
    public TMP_Text buttonText;
    public Queue<string> sentences = new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        title.text = dialogue.Title;
        buttonText.text = dialogue.ButtonText;

        sentences.Clear();

        foreach (string sentence in dialogue.Messages)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return new WaitForFixedUpdate();
        }
    }


    public void EndDialog()
    {
        animator.SetBool("IsOpen", false);
    }
}