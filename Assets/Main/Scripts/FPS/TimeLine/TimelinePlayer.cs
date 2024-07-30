using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    [SerializeField] private PlayableDirector Director; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Director.Play();
        }
    }
}
