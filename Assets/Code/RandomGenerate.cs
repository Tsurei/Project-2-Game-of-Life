using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerate : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Find and assign the GameManager component from the GameObject with the "GameManager" tag
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Generate a random initial generation of alive cells
    public void RandomGeneration()
    {
        // Call the GameManager's GenerateRandomAliveCells method with a random count of cells (between 20 and 50)
        gameManager.GenerateRandomAliveCells(Random.Range(20, 50));
    }
}
