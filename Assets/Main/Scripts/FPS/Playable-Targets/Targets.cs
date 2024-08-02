using Emp37.Utility;
using Emp37.Utility.Tween;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] private Transform target, a,b;

    [Space(10f)]
    [SerializeField] private bool ShouldMove;
    [SerializeField] private bool ShouldLoop;
    private bool IsReversing;

    [SerializeField] private float Delay;

    [SerializeField, Readonly] private float elapsed;
    [EnableWhen(nameof(ShouldMove))] public float Duration = 1f;
    [EnableWhen(nameof(ShouldLoop))] public Ease.Type TweenCurve;
    public float Scale = 15f;

    public bool IsActive;

    private void OnEnable() => IsActive = true;
    
    private void Update()
    {
        if(!ShouldMove) return;

        if(Delay > 0f)
        {
            Delay -= Time.deltaTime;
        }
        else
            if(elapsed < 1f)
        {
            elapsed += Time.deltaTime / Duration;
        }
        else if(elapsed >= 1f)
        {
            if(!ShouldLoop) enabled = false;

            elapsed =  0f;
            IsReversing = !IsReversing;
        }

        float t = Ease.EasedRatio(elapsed, TweenCurve);
        target.position = Vector3.LerpUnclamped(a.position,b.position,IsReversing ?1f -t:t);
    }
}
