using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{

    public void play()
    {
        SceneManager.LoadScene("NewMap");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Qutting");
    }
}
