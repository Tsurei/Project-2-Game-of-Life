using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameOfLife))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameOfLife gameOfLife;
    [SerializeField] private int gameBoardLength;
    [SerializeField] private int gameBoardHeight;
    [SerializeField] private GameObject cellPrefab; 

    private Camera mainCamera;
    private float simulationInterval = 5f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // Get a reference to the camera

        // Calculate the cell size based on camera size and grid size
        float cellSizeX = mainCamera.orthographicSize * 2 / gameBoardLength;
        float cellSizeY = mainCamera.orthographicSize * 2 / gameBoardHeight;

        // Set game board dimensions
        gameOfLife.SetGameBoardLength(gameBoardLength);
        gameOfLife.SetGameBoardHeight(gameBoardHeight);

        // Initialize the game board
        gameOfLife.InitializeGameBoard();

        // Instantiate and populate the game board with cells
        gameOfLife.PopulateGameBoardWithCells(cellPrefab, cellSizeX, cellSizeY);
    }

    void Update()
    {
        // Check if it's time to run the simulation
        timer += Time.deltaTime;
        if (timer >= simulationInterval)
        {
            gameOfLife.CalculateNextGeneration();
            timer = 0f; // Reset the timer
        }
    }

}
