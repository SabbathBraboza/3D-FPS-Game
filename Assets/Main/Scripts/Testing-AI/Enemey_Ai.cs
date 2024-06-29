using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemey_Ai : MonoBehaviour
{
      public Transform Player;
      public float Speed = 0.2f;

      [SerializeField] private Animator anime;
      private NavMeshAgent agent;

      private void Reset() => anime = GetComponent<Animator>();

      private void Awake()
      {
            agent = GetComponent<NavMeshAgent>();
      }

      private void Update()
      {
            anime.SetBool("Moving", agent.velocity.magnitude > 0f);
      }
      private void Start() => StartCoroutine(FollowAgent());

      private IEnumerator FollowAgent()
      {
            WaitForSeconds wait = new WaitForSeconds(Speed);
            while (enabled)
            {
                  agent.SetDestination(Player.transform.position);
                  yield return wait;
            }
      }
}

