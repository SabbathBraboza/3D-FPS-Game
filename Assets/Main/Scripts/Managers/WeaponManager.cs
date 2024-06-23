using UnityEngine;

public class WeaponManager : MonoBehaviour
{
      [SerializeField] private Primary primary;
      [SerializeField] private Secondary secondary;

      private void Update()
      {
            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                  primary.gameObject.SetActive(true);
                  primary.enabled = true;
            }
            else
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                  primary.enabled=false;
            }
      }
}
