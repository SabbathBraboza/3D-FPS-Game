using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{

    public void play()
    {
        SceneManager.LoadScene("NewMap");
    }
}
