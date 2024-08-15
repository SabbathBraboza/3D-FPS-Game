using Emp37.Utility;
using TPS.Player;
using UnityEngine;
using UnityEngine.AI;

public class TakeDamage : MonoBehaviour, IDamge
{
    [Header("Value:")]
    [SerializeField] private int MaxHp = 100;

    [Header("References:")]
    [SerializeField] private Animator anime;
    [SerializeField] private BoxCollider box;
    [SerializeField] private ZombieController zombieController;
    [SerializeField] private NavMeshAgent Agent;

    [Header("ReadOnly")]
    [SerializeField,Readonly] private int CurrentHp;

    private void Start() => CurrentHp = MaxHp;
    

    public void Damage(int damage)
    {
        damage = Mathf.Max(damage, 0);

        CurrentHp -= damage;

        if (CurrentHp < 0)
            Die();

        else
            Hurt();

    }

    private void Hurt()
    {
        if(anime != null) anime.SetTrigger("Hurt");
    }

    private void Die()
    {
        if (anime != null) anime.SetTrigger("Dead");

        if(box !=null) box.enabled = false;

        if(zombieController != null) zombieController.enabled = false;

        if(Agent != null) Agent.speed = 0;

        Destroy(gameObject, 2f);
    }
}
