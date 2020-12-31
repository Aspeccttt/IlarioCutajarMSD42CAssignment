using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfiguration> waveConfigurationList;

    [SerializeField] bool looping = false;

    int defaultWave = 0;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(WavesStartSpawn());
        }
        while (looping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WavesStartSpawn()
    {
        foreach (WaveConfiguration currentWave in waveConfigurationList)
        {
            yield return StartCoroutine(EnemiesInWave(currentWave));
        }
    }

    private IEnumerator EnemiesInWave(WaveConfiguration waveSpawn)
    {
        var spawnEnemy = Instantiate(
                       waveSpawn.FetchEnemyPrefab(),
                       waveSpawn.FetchWaypoints()[0].transform.position,
                       Quaternion.identity);
        spawnEnemy.GetComponent<EnemyPathing>().WaveConfigSet(waveSpawn);
        yield return new WaitForSeconds(waveSpawn.FetchTimeBetweenSpawns());
    }
}
 