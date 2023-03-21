using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoiceAnswer : MonoBehaviour
{
    public bool IsCorrect = false;
    public MultipleChoiceManager manager;

    public void Answer()
    {
        switch (IsCorrect)
        {
            case true:
                manager.Correct();
                break;
            case false:
                gameObject.GetComponent<Image>().color = Color.red;
                break;
        }
    }
}