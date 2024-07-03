using System.Collections;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
     [SerializeField] private Animator anime;

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

               yield return new WaitForSeconds(12f);

                  anime.SetBool("Landing", true);

                  yield return new WaitForSeconds(20f); // Adjust delay as needed
            };
      }
}
