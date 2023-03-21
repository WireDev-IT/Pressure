using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoiceManager : MonoBehaviour
{
    public List<MultipleChoiceChallenge> challenges = new() { new() };
    public GameObject[] answers;
    public int currentQuestion;
    public TMP_Text QuestionTxt;
    public Canvas canvas;

    public void Show()
    {
        GenerateQuestion();
        canvas.gameObject.SetActive(true);
    }

    public void Hide()
    {
        canvas.gameObject.SetActive(false);
    }

    public void Correct()
    {
        if (challenges.Count > 0)
        {
            challenges.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
    }

    private void SetAnswers()
    {
        for (int i = 0; i < answers.Length; i++)
        {

            answers[i].GetComponent<MultipleChoiceAnswer>().IsCorrect = false;
            answers[i].transform.GetChild(0).GetComponent<TMP_Text>().text = challenges[currentQuestion].Answers[i];
            answers[i].GetComponent<Image>().color = Color.white;

            if (challenges[currentQuestion].CorrectAnswer == i)
            {
                answers[i].GetComponent<MultipleChoiceAnswer>().IsCorrect = true;
            }
        }
    }

    private void GenerateQuestion()
    {
        if (challenges.Count > 0)
        {
            currentQuestion = Random.Range(0, challenges.Count);
            QuestionTxt.text = challenges[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }
}