using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Targets_Manager : MonoBehaviour
{
    [Header("Value:")]
    [SerializeField] private int TargetsPerWave = 3;
    [SerializeField] private float TimeBetweenWaves = 5f;
    [SerializeField] private int TotalWavesToSpawn;

    [Header("UI")]
    [SerializeField] private Text WaveText;
    [SerializeField] private Text RemainingTargetText;

    [Header("Gameobject:")]
    [SerializeField] private GameObject TargetPerfab;
    [SerializeField] private Transform[] SpawnPoints;
    private List<GameObject> spawnList = new List<GameObject>();

    private Targets targets;
    private int WaveNumber = 0;
    private bool IsSpawning = false;

    private void Start()
    {
        UpdateWaveUI();
        UpdateRemainingTargetUI();
        StartCoroutine(SpawnWave());
    }
    private void Update()
    {
        if (!IsSpawning && AllTargetDestroyed())
            StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (WaveNumber < TotalWavesToSpawn)
        {
            IsSpawning = true;

            WaveNumber++;
            UpdateWaveUI();
            Debug.Log("Wave" + WaveNumber);

            for (int i = 0; i < TargetsPerWave; i++)
            {
                SpawnTarget();
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(TimeBetweenWaves);
            IsSpawning = false;
        }
        Debug.Log("All Waves Have Ended GG");

        WaveText.gameObject.SetActive(false);
        RemainingTargetText.gameObject.SetActive(false);
    }

    private void SpawnTarget()
    {
        int SpawnIndex = Random.Range(0, SpawnPoints.Length);
        Transform SpawnPoint = SpawnPoints[SpawnIndex];

        GameObject newtarget = Instantiate(TargetPerfab, SpawnPoint.position, SpawnPoint.rotation);
        spawnList.Add(newtarget);

        UpdateRemainingTargetUI();
    }

    private bool AllTargetDestroyed()
    {
        spawnList.RemoveAll(targets => targets == null);
        UpdateRemainingTargetUI();
        return spawnList.Count == 0;
    }

    public void EnableSpawning()
    {
        targets.enabled = true;
        StartCoroutine(SpawnWave());
    }

    private void UpdateWaveUI()
    {
        if(WaveText != null)
          WaveText.text = "Wave: " + WaveNumber;
    }

    private void UpdateRemainingTargetUI()
    {
        if(RemainingTargetText != null)
           RemainingTargetText.text = "Target Spawned: " + spawnList.Count;
    }

}
