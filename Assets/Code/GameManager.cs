using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameOfLife))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameOfLife gameOfLife;
    [Range(10, 50)]
    [SerializeField] private int gameBoardLength;
    [Range(10, 50)]
    [SerializeField] private int gameBoardHeight;
    [Range(0, 150)]
    [SerializeField] private int spawnCount;

    private Camera mainCamera;
    private float simulationInterval = 2f;
    private float timer = 0f;
    [SerializeField] private Slider slider;

    void Start()
    {
        mainCamera = Camera.main;

        float cellSizeX = mainCamera.orthographicSize * 2 / gameBoardLength;
        float cellSizeY = mainCamera.orthographicSize * 2 / gameBoardHeight;

        gameOfLife.SetGameBoardLength(gameBoardLength);
        gameOfLife.SetGameBoardHeight(gameBoardHeight);

        gameOfLife.InitializeGameBoard();
        gameOfLife.PopulateGameBoardWithCells(cellSizeX, cellSizeY); // Pass cellSizeX and cellSizeY to the method.

        GenerateRandomAliveCells(spawnCount);
    }

    void Update()
    {
        simulationInterval = slider.value;
        timer += Time.deltaTime;
        if (timer >= simulationInterval)
        {
            gameOfLife.CalculateNextGeneration();
            timer = 0f;
        }

        // Check for user input when manual cell setting is enabled
        if (gameOfLife.IsManualCellSettingEnabled() && Input.GetMouseButtonDown(0))
        {
            HandleCellClick();
        }
    }

    public void GenerateRandomAliveCells(int numCells)
    {
        for (int i = 0; i < numCells; i++)
        {
            int randomX = Random.Range(0, gameBoardLength);
            int randomY = Random.Range(0, gameBoardHeight);

            // Set the cell at randomX, randomY as alive
            gameOfLife.GetCell(randomX, randomY).SetStatus(Cell.CellState.Alive);
        }
    }

    void HandleCellClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Cell clickedCell = hit.collider.GetComponent<Cell>();
                if (clickedCell != null)
                {
                    clickedCell.ToggleCellStatus();
                }
            }
        }
    }

    public void SetTimerInterval(int timer)
    {
        simulationInterval = timer;
    }
}