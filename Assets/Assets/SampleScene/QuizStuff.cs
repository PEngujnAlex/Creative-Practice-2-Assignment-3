using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizStuff : MonoBehaviour
{
    public TMP_Text question;
    public TMP_Text[] buttonText;
    public Button nextButton;

    public Button aButton;
    public Button bButton;
    public Button cButton;
    public Button dButton;

    public List<quizQuestions> questions = new List<quizQuestions>();

    int currentQuestion = 0;
    int score = 0;

    void Start()
    {
        updateQuestion();
        nextButton.interactable = false;
    }

    public void answerClick(string answer)
    {
        if (answer[0] == questions[currentQuestion].answer)
        {
            score += 10;
            buttonText[4].text = "CORRECT: " + score.ToString() + " Points";
        }
        else
        {
            buttonText[4].text = "That is Incorrect: " + score.ToString() + " Points";
        }

        currentQuestion++;
        nextButton.interactable = true;
    }

    public void nextClick()
    {
        updateQuestion();
        nextButton.interactable = false;
    }

    public void endClick()
    {
        //change the display? to show the total score, maybe a button to go back through the questions? or a restart button??
        nextButton.interactable = false;
        aButton.interactable = false;
        bButton.interactable = false;
        cButton.interactable = false;
        dButton.interactable = false;
    }

    void updateQuestion()
    {
        if (currentQuestion < questions.Count)
        {
            question.text = questions[currentQuestion].Q;

            buttonText[0].text = questions[currentQuestion].A;
            buttonText[1].text = questions[currentQuestion].B;
            buttonText[2].text = questions[currentQuestion].C;
            buttonText[3].text = questions[currentQuestion].D;
        }
        else
        {
            endClick(); 
        }
    }
}

// end of quiz class


[System.Serializable]
public class quizQuestions
{
    public string Q;
    public string A;
    public string B;
    public string C;
    public string D;
    public char answer;
}