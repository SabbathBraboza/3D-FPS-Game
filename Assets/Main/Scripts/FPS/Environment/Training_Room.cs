using UnityEditor.Rendering;
using UnityEngine;


public class Training_Room : MonoBehaviour
{
    private Targets_Manager Targets_Manager;

    private void Start()
    {
        Targets_Manager = GetComponent<Targets_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Targets_Manager.enabled = true; 
    }


}
