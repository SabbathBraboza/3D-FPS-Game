using UnityEngine;

public class Player_Health : MonoBehaviour
{
      [SerializeField] private int health;
    
      public void TakeDamage(int damage)
      {
            health -= damage;
            
            if(health < 0)
            {
                  Die();
            }
      }

      public void Die()
      {
            Destroy(gameObject);
      }
}
