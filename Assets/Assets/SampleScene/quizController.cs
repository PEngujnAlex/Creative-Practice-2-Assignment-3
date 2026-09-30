using UnityEngine;
using UnityEngine.InputSystem;

public class quizController : MonoBehaviour
{
    public GameObject TopicUI;
    public GameObject QuizUI;
    public GameObject SlidingGameBoard;
    public GameObject SlidingGameManager;

    public int GameMode = 1; // 1 - Topic Select , 2 - Quiz, 3 - Sliding Game

    void Update()
    {
        if (GameMode == 1)
        {
            selectTopic();
        }

        if (GameMode == 2)
        {
            doQuiz();
        }

        if (GameMode == 3)
        {
            doSlidingGame();
        }
    }

    void selectTopic()
    {
        TopicUI.SetActive(true);
        QuizUI.SetActive(false);
        SlidingGameBoard.SetActive(false);
        SlidingGameManager.SetActive(false);
    }

    void doQuiz()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Mouse.current.position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50))
            {
                if (hit.transform.tag == "ducky")
                {
                    TopicUI.SetActive(false);
                    QuizUI.SetActive(true);
                }
            }
        }
    }

    void doSlidingGame()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Mouse.current.position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50))
            {
                if (hit.transform.tag == "notTrain")
                {
                    TopicUI.SetActive(false);
                    SlidingGameBoard.SetActive(true); //this might work, this might not who knows
                    SlidingGameManager.SetActive(true);
                }
            }
        }
    }
}
