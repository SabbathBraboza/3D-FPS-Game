using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float rayDistance = 4f;
    [SerializeField] private LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
      {
        if(other.TryGetComponent(out Player_Health id))
           id.TakeDamage(20);  
    }

    public void AttackZombie()
    {
        Vector3 rayDirection = AttackPoint.forward;
        if (Physics.Raycast(AttackPoint.position, rayDirection, out RaycastHit info, rayDistance, layerMask))
        {
            if (info.collider != null && info.collider.TryGetComponent(out Player_Health id))
            {
                        print("Damage");
                id.TakeDamage(20);
            }
            // If the raycast hits something, process the hit information
            Debug.DrawRay(AttackPoint.position, rayDirection * rayDistance, Color.red, 2.0f);       
        }
    }
}
