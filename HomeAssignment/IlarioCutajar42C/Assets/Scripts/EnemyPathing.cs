using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    int scoreValue = 5;

    [SerializeField] List<Transform> waypoints;

    [SerializeField] WaveConfiguration waveConfig;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

        waypoints = waveConfig.FetchWaypoints();

        transform.position = waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var positionTarget = waypoints[waypointIndex].transform.position;
            positionTarget.z = 0f;

            var enemyMoveSpeed = waveConfig.FetchEnemyPrefabSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, positionTarget, enemyMoveSpeed);

            if (transform.position == positionTarget)
            {
                waypointIndex++;
            }
        }
            else
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            Destroy(gameObject);
        }
    }

    public void WaveConfigSet(WaveConfiguration waveConfigSet)
    {
        waveConfig = waveConfigSet;
    }

}
