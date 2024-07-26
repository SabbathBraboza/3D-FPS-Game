using UnityEngine;
using UnityEngine.Playables;

public class EntryRoomTimeline : MonoBehaviour
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
