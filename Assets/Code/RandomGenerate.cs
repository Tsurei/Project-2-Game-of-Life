using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerate : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public void RandomGeneration()
    {
        gameManager.GenerateRandomAliveCells(Random.Range(20, 50));
    }
}
