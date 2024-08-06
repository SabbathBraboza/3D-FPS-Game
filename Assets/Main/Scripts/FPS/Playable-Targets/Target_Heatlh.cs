using TPS.Player;
using UnityEngine;

public class Target_Heatlh : MonoBehaviour,IDamge
{
    [SerializeField] private GameObject PopUpText;
    [SerializeField] private GameObject target;
    [SerializeField] private int HP;
    private Targets_Manager targets;
     [SerializeField] private int collisionDamage = 25;

      public void Damage(int damage)
    {
        HP -= damage;
         if(HP < damage)
         { 
              PopUp.instance.ShowPopUp(transform.position,collisionDamage.ToString());

              Destroy(target);
      
              if(targets != null) targets.EnableSpawning();
         }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damage(collisionDamage);
    }
}
