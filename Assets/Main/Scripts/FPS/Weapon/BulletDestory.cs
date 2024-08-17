using UnityEngine;

public class BulletDestory : MonoBehaviour
{
    [SerializeField] private float destroy;
      private void Update()
      {
            Destroy(gameObject,destroy);
      }
}
