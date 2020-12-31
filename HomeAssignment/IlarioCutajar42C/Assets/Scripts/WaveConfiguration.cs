using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Wave Configuration")]
public class WaveConfiguration : ScriptableObject
{
    //The Selection which will display the chosen prefab for said wave.
    [SerializeField] GameObject enemyPrefab;

    //The Selection which will play for the certain path.
    [SerializeField] GameObject path;

    //The Selection which will display the chosen amount of enemy prefabs.
    [SerializeField] int numberOfCars = 3;

    //The Selection which will give speed to the enemy prefab at said wave.
    [SerializeField] float enemyPrefabSpeed = 2f;

    [SerializeField] float timebetweenspawns = 10f;

    public GameObject FetchEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> FetchWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in path.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }

    public float FetchEnemyPrefabSpeed()
    {
        return enemyPrefabSpeed;
    }

    public int FetchNumberOfCarsPerWave()
    {
        return numberOfCars;
    }

    public float FetchTimeBetweenSpawns()
    {
        return timebetweenspawns;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
