using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
      public static PopUp instance;
      public GameObject PopUpPrefab;

      private void Awake()
      {
            instance = this;
      }

      public void ShowPopUp(Vector3 position,string text)
      {
            var popUp = Instantiate(PopUpPrefab,position,Quaternion.identity);
            var temp = popUp.transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
            if (temp != null)
            {
                  temp.text = text;
            }
            Destroy(popUp, 0.5f);  
      }
}
