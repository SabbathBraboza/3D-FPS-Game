using UnityEngine;
using UnityEngine.AI;

public class Robot_Enemy : MonoBehaviour
{
      private NavMeshAgent agent;
      private StateMachine State;

      public NavMeshAgent Agent { get  => agent; }

      [SerializeField]
      private string currentStatic;

      public Path Path;
      private void Start()
      {
            State = GetComponent<StateMachine>();
            agent = GetComponent<NavMeshAgent>();
            State.Initialise();
      }
}
