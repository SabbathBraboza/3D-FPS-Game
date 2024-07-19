using TPS.Player;
using UnityEngine;

public class TakeDamage : MonoBehaviour, IDamge
{

    [SerializeField] private int HP = 100;
    [SerializeField] private Animator anime;

    private void Reset()
    {
        anime = GetComponent<Animator>();
    }

    public void Damage(int damage)
    {
        HP -= damage;
        if (HP < damage) anime.SetTrigger("Dead");

        else anime.SetTrigger("Hurt");

        print(HP);
    }
}
