using TPS.Player;
using UnityEngine;

public class TakeDamage : MonoBehaviour, IDamge
{

    [SerializeField] private int HP = 100;
    [SerializeField] private Animator anime;
      private BoxCollider box;

    private void Reset()
    {
        anime = GetComponent<Animator>();
            box = GetComponent<BoxCollider>();
    }

    public void Damage(int damage)
    {
        HP -= damage;
            if (HP < damage)
            {
                  anime.SetTrigger("Dead");
                  box.enabled = false;

            }
            else anime.SetTrigger("Hurt");

        print(HP);
    }
}
