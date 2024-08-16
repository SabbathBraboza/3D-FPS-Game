using Emp37.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    [Header("Value:")]
    [SerializeField] private int MaxHp;
    [SerializeField] private float Interseity = 0f;

    [Header("Refeneces:")]
    [SerializeField] private Volume volume;
    [SerializeField] private Slider HealthBar;

    [Header("ReadOnly:")]
    [SerializeField, Readonly] private int CurrentHp; 

    public UnityEvent OnDead;

    private void Start()
    {
        CurrentHp = MaxHp;
        HealthBar.value = CurrentHp;
    }

    public void TakeDamage(int damage)
      {
          damage =Mathf.Max(damage,0);
          HealthBar.value = CurrentHp;
          StartCoroutine(BloodEffect());
          CurrentHp -= damage;

        if (CurrentHp < 0) OnDead.Invoke();
    } 

    private IEnumerator BloodEffect()
    {
        float remaining = Interseity;
        while (remaining > 0f)
        {
            remaining -= Time.deltaTime;
            volume.weight = 0.5f;
            yield return null;
        }
        volume.weight = 0f;
        yield break;
    }
}
