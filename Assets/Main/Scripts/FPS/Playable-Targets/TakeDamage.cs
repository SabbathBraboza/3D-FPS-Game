using TPS.Player;
using UnityEngine;

public class TakeDamage : MonoBehaviour, IDamge
{

    [SerializeField] private int HP = 100;
    [SerializeField] private Animator anime;
    [SerializeField] private BoxCollider box;

 
    public void Damage(int damage)
    {
        HP -= damage;
        if (HP < damage)
        {
          anime.SetTrigger("Dead");
          box.enabled = false;

        }
        else anime.SetTrigger("Hurt");
    }
 
}
