using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGrid : MonoBehaviour
{
    private GameOfLife gameOfLife; // Reference to your GameOfLife component

    void Start()
    {
        gameOfLife = GetComponent<GameOfLife>();
    }

    public void Clear()
    {
        gameOfLife.ClearGrid(); // Add a method in your GameOfLife script to clear the grid.
    }
}

