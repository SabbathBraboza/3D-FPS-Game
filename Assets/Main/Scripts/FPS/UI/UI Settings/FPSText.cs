using TMPro;
using UnityEngine;

public class FPSText : MonoBehaviour
{
    [SerializeField] private TMP_Text Counter;

    [SerializeField,Range(0f,0.1f)] private float UpdateInterval = 0.088f;
    private float TimeLeft;

    private void Start() => TimeLeft = UpdateInterval;

    private void LateUpdate()
    {
        if (TimeLeft < UpdateInterval)
        {
            TimeLeft += Time.deltaTime;
        }
        else
        {
            float Fps = 1f / Time.smoothDeltaTime;
            Counter.text = $"FPS:{Fps:F0}";
            if (Fps < 30)
            {
                Counter.color = Color.red;
            }
            else if (Fps >= 30 && Fps <= 60)
            {
                Counter.color = Color.yellow;
            }
            else if (Fps > 60)
            {
                Counter.color = Color.green;
            }
            TimeLeft = 0f;
        }
    }
}
