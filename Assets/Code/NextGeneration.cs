using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGeneration : MonoBehaviour
{
    private GameOfLife gameOfLife;

    void Start()
    {
        gameOfLife = GameObject.FindWithTag("GameManager").GetComponent<GameOfLife>();
    }


    public void StepToNextGeneration()
    {
        gameOfLife.CalculateNextGeneration();
    }

}
