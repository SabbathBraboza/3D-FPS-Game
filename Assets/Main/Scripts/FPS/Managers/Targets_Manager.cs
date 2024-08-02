using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets_Manager : MonoBehaviour
{
    [SerializeField] private GameObject TargetPerfab;
    [SerializeField] private int TargetsPerWave = 3;
    [SerializeField] private float TimeBetweenWaves = 5f;
    [SerializeField] private Transform[] SpawnPoints;
    private Targets targets;

    private int WaveNumber = 0;
    private bool IsSpawning = false; 
    private List<GameObject> spawnList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }
    private void Update()
    {
        if(!IsSpawning && AllTargetDestroyed()) 
            StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        IsSpawning = true;

        WaveNumber++;
        Debug.Log("Wave" + WaveNumber);

        for(int i = 0; i < TargetsPerWave; i++)
        {
            SpawnTarget();
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(TimeBetweenWaves);
         IsSpawning =false;
    }

     private void SpawnTarget()
    {
        int SpawnIndex = Random.Range(0, SpawnPoints.Length);
        Transform SpawnPoint = SpawnPoints[SpawnIndex];
        
       GameObject newtarget = Instantiate(TargetPerfab, SpawnPoint.position, SpawnPoint.rotation);
        spawnList.Add(newtarget);
    }

    private bool AllTargetDestroyed()
    {
        spawnList.RemoveAll(targets => targets == null);

        return spawnList.Count == 0;
    }

    public void EnableSpawning()
    {
        targets.enabled=true;
        StartCoroutine (SpawnWave());
    }
}
