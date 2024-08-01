using TMPro;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    [SerializeField] private GameObject text;

    private void OnTriggerEnter(Collider other)
    {
         text.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
         text.SetActive(false);
    }
}
