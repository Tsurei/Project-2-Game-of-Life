using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGeneration : MonoBehaviour
{
    private GameOfLife gameOfLife;

    void Start()
    {
        // Find and assign the GameOfLife component from the GameObject with the "GameManager" tag
        gameOfLife = GameObject.FindWithTag("GameManager").GetComponent<GameOfLife>();
    }

    // Proceed to the next generation in the Game of Life simulation
    public void StepToNextGeneration()
    {
        gameOfLife.CalculateNextGeneration();
    }
}

