using UnityEngine;

public class UIbillBoarding : MonoBehaviour
{
      private Camera cam;
      private void Awake() =>cam = Camera.main;
      
     private void Update() =>  transform.position = cam.transform.forward;      
}
