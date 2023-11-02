using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGrid : MonoBehaviour
{
    private GameOfLife gameOfLife;

    void Start()
    {
        // Find and assign the GameOfLife component from the GameObject with the "GameManager" tag
        gameOfLife = GameObject.FindWithTag("GameManager").GetComponent<GameOfLife>();
    }

    // Clears the entire grid, setting all cells to a "Dead" state
    public void Clear()
    {
        gameOfLife.ClearGrid();
    }
}
