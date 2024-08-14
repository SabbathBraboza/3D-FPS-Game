using UnityEngine;

public class Red_and_blue : MonoBehaviour
{
      [SerializeField] private Light RedLight;
      [SerializeField] private Light BlueLight;

      private Vector3 RedTemp;
      private Vector3 BlueTemp;

      [SerializeField] private int Speed;

      private void Update()
      {
            RedTemp.y += Speed + Time.deltaTime;
            BlueTemp.y += Speed + Time.deltaTime;

            RedLight.transform.eulerAngles = RedTemp;
            BlueLight.transform.eulerAngles = BlueTemp;
      }
}
