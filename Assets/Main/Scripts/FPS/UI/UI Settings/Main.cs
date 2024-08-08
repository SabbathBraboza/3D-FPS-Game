using UnityEngine;
using UnityEngine.Events;

public class Main : MonoBehaviour
{
    public Settings settings;

    public UnityEvent OnInitialize;

    private void OnEnable()
    {
        OnInitialize.Invoke();
    }

    private void Start()
    {
          
    }
}
