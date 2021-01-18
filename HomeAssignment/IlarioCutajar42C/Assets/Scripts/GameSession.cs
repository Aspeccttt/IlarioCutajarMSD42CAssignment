using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int finalHealth;
    int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int GameSessionOngoing = FindObjectsOfType<GameSession>().Length;

        if (GameSessionOngoing > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void AddToScore(int scoreValue) 
    {
        score += scoreValue;
    }

    public void AddToHealth(int healthValue)
    {
        finalHealth = healthValue;
    }

    public void SubtractToScore(int scoreSubtract)
    {
        score -= scoreSubtract;
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 100)
        {
            
            FindObjectOfType<Level>().LoadGameWon();

        }
    }
}
