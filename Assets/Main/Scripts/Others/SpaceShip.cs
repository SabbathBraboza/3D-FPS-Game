using System.Collections;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
     [SerializeField] private Animator anime;

    [Space(5f)]
    [Header("Values")]
    [SerializeField] private float landing;
    [SerializeField] private float Flying;
      private void Reset() =>  anime = GetComponent<Animator>();

      private void Start()
      {
        StartCoroutine(PlayLandingLoop());
      }

      private IEnumerator PlayLandingLoop()
      {
            while (true)
            {
                  anime.SetBool("Landing", false);

               yield return new WaitForSeconds(landing);

                  anime.SetBool("Landing", true);

                  yield return new WaitForSeconds(Flying); // Adjust delay as needed
            };
      }
}
