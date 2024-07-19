using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour
{
    [SerializeField] private KeyCode Key;
    [SerializeField] private Image Image;


    private void Reset()
    {
        Image = GetComponent<Image>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(Key))
           Image.color = Color.green;

        if(Input.GetKeyUp(Key))
            Image.color = Color.white;    
    }
}
