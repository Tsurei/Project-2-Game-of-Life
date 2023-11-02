using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationController : MonoBehaviour
{
    private bool isPaused = true;
    private GameOfLife gameOfLife;
    private TextMeshProUGUI text;

    void Start()
    {
        // Find and reference the GameOfLife component
        gameOfLife = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameOfLife>();

        // Find and reference the TextMeshProUGUI component for displaying "Play" or "Pause"
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void TogglePausePlay()
    {
        // Toggle between pause and play states
        if (isPaused)
        {
            // Pause the simulation
            Time.timeScale = 0f; // Pause time in Unity to halt updates
            text.text = "Play";
        }
        else
        {
            // Resume the simulation
            Time.timeScale = 1f; // Resume time to normal speed
            text.text = "Pause";
        }
        isPaused = !isPaused; // Toggle the pause state
    }
}
