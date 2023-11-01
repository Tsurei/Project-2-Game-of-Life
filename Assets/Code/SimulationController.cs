using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
    private bool isPaused = false;
    private GameOfLife gameOfLife;

    void Start()
    {
        gameOfLife = GetComponent<GameOfLife>();
    }

    public void TogglePausePlay()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the simulation
            Time.timeScale = 0f; // Pause time in Unity to halt updates
        }
        else
        {
            // Resume the simulation
            Time.timeScale = 1f; // Resume time to normal speed
        }
    }
}
