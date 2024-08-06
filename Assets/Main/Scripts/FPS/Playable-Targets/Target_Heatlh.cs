using TPS.Player;
using UnityEngine;

public class Target_Heatlh : MonoBehaviour,IDamge
{
    [SerializeField] private GameObject PopUpText;
    [SerializeField] private GameObject target;
    [SerializeField] private int HP;
    private Targets_Manager targets;

    public void Damage(int damage)
    {
        HP -= damage;
        if(HP < damage)
        { 
          Destroy(target);
           
          if(targets != null) targets.EnableSpawning();
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        int collisionDamage = 25;
        Damage(collisionDamage);
        ShowPopUp();
    }

    private void ShowPopUp()
    {
        Instantiate(PopUpText, transform.position, Quaternion.identity);
    }
}
