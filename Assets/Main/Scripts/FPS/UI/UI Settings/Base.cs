using UnityEngine;

public abstract class Base<T> : MonoBehaviour where T : struct
{
   [SerializeField] private Main Main;
     protected Settings Settings => Main.settings; 

    protected virtual void Reset() => Main = GetComponent<Main>();

   
    protected virtual void OnEnable() => Main.OnInitialize.AddListener(Initialize);
    protected virtual void OnDisable() => Main.OnInitialize.RemoveListener(Initialize);

    public abstract void OnvalueChange(T Value);
    protected abstract void Initialize();
}

