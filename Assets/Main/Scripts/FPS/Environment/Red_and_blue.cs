using UnityEngine;

public class Red_and_blue : MonoBehaviour
{
      [SerializeField] private Light redLight;
      [SerializeField] private Light blueLight;

      [SerializeField] private float rotationSpeed = 30f; // Degrees per second

      private Vector3 redLightRotation;
      private Vector3 blueLightRotation;

      private void Start()
      {
            // Initialize rotations
            redLightRotation = redLight.transform.eulerAngles;
            blueLightRotation = blueLight.transform.eulerAngles;
      }

      private void Update()
      {
            // Rotate red light clockwise
            redLightRotation.y += rotationSpeed * Time.deltaTime;
            redLight.transform.eulerAngles = redLightRotation;

            // Rotate blue light counterclockwise
            blueLightRotation.y -= rotationSpeed * Time.deltaTime;
            blueLight.transform.eulerAngles = blueLightRotation;
      }
}
