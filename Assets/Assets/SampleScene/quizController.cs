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

        if (!TryGetPointerDownPosition(out Vector2 pointerPosition))
        {
            return;
        }

        Camera arCamera = Camera.main;
        if (arCamera == null)
        {
            Debug.LogError("No MainCamera is available to select an AR topic.");
            return;
        }

        Ray ray = arCamera.ScreenPointToRay(pointerPosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, 50f))
        {
            return;
        }

        if (hit.transform.CompareTag("ducky"))
        {
            GameMode = 2;
        }
        else if (hit.transform.CompareTag("notTrain"))
        {
            GameMode = 3;
        }
    }

    void doQuiz()
    {
        TopicUI.SetActive(false);
        QuizUI.SetActive(true);
        SlidingGameBoard.SetActive(false);
        SlidingGameManager.SetActive(false);
    }

    void doSlidingGame()
    {
        TopicUI.SetActive(false);
        QuizUI.SetActive(false);
        SlidingGameBoard.SetActive(true);
        SlidingGameManager.SetActive(true);
    }

    bool TryGetPointerDownPosition(out Vector2 position)
    {
        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            position = Touchscreen.current.primaryTouch.position.ReadValue();
            return true;
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            position = Mouse.current.position.ReadValue();
            return true;
        }

        position = default;
        return false;
    }
}
