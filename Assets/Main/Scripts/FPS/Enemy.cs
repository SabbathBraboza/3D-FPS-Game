using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Values:")]
    [SerializeField] private float StartWaitTime = 4f;
    [SerializeField] private float TimeToRotate = 3f;
    [SerializeField] private float Speedwalk = 6f;
    [SerializeField] private float SpeedRun = 9f;

    [Header("Enemy View:")]
    [SerializeField] private float ViewRadius = 15;
    [SerializeField] private float ViewAngle = 90;
    [SerializeField] private float MeshResolution = 1f;
    [SerializeField] private int EdgeIterations = 4;
    [SerializeField] private float EdgeDistance = 0.5f;

    [Header("References")]
    [SerializeField] private LayerMask PlayerMask;
    [SerializeField] private LayerMask ObstacleMask;
    private NavMeshAgent agent;

    [Header("Waypoints")]
    [SerializeField] private Transform[] Waypoints;

    int m_CurrentWayPointIndex;
    Vector3 PlayerLastPosition = Vector3.zero;
    Vector3 m_PlayerPosition;

    // Bool
    float WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRage;
    bool m_PlayerNear;
    bool IsPatrol;
    bool CaughtPlayer;

    private void Start()
    {
        
    }

}
