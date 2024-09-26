using UnityEngine;
using UnityEngine.SceneManagement;


public class PausedUI : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           PausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }  
    }

    public void ClosePause()
    {
      PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void Home()
    {
      Time.timeScale = 0f;
      SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
      Application.Quit();
      Debug.Log("Quiting");
    }
}
