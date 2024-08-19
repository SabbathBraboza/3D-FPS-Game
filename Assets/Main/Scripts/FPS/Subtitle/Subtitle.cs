using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class Subtitle : Syc
{
    [SerializeField] private TMP_Text subtitle;

    public void show()
    {
        subtitle.text = string.Empty;
    }

    public void show(string text)
    {
        subtitle.text = text;
    }

    public void ShowAnimates(string text, float duration) => StartCoroutine(AppendSubtitle(text,duration));

    private IEnumerator AppendSubtitle(string text, float duration)
    {
        StringBuilder builder = new();
        int lenght = text.Length;

        for (int i = 0; i < lenght; i ++)
        {
            builder.Append(text[i]);
            subtitle.text = builder.ToString();

            yield return new WaitForSeconds(duration / lenght);
        }
    }
}
