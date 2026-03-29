using UnityEngine;

public class UIManager_back : MonoBehaviour
{
    public GameObject quizPanel;
    public GameObject gameUI;

    public void Back()
    {
        quizPanel.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}