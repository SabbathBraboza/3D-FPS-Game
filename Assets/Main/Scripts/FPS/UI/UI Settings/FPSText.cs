using TMPro;
using UnityEngine;

public class FPSText : MonoBehaviour
{
    [SerializeField] private TMP_Text Counter;

    [SerializeField] private float UpdateRate = 0.1f;
    private float elapsed;

    private void Update()
    {
        if (elapsed < UpdateRate)
        {
            elapsed += Time.deltaTime;

        }
        else
        {
            Counter.text = $"{1f / Time.smoothDeltaTime:000} FPS";
            elapsed = 0;
        }
    }
}
