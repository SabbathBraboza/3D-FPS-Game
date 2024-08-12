using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float Interseity = 0f;
    [SerializeField] private Volume volume;

    public void TakeDamage(int damage)
      {
            StartCoroutine(BloodEffect());
            health -= damage;
            
            if(health < 0) Destroy(gameObject);
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
