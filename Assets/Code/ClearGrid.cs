using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGrid : MonoBehaviour
{
    private GameOfLife gameOfLife;

    void Start()
    {
        gameOfLife = GameObject.FindWithTag("GameManager").GetComponent<GameOfLife>();
    }

    public void Clear()
    {
        gameOfLife.ClearGrid();
    }
}

