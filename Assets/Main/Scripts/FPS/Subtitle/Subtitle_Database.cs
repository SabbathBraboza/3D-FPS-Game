using System;
using UnityEngine;

public class Subtitle_Database : MonoBehaviour
{
    [Serializable]
    private struct Dialogue
    {
       [TextArea(0,5)] public string Text;
        public AudioClip clip;
    }
  
    [SerializeField] private Subtitle subtitle;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Dialogue[] dialogue;

    public void BeginDialogue(int index)
    {
        if (dialogue.Length == 0) return;

        var context = dialogue[index];
        subtitle.ShowAnimates(context.Text,context.clip.length);

        audioSource.PlayOneShot(context.clip);
    }

}
