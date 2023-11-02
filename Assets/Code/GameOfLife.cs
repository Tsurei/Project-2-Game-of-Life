using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    // Variables
    private TextMeshPro text;
    private int currentGen = 1;
    public GameObject cellPrefab;
    private Cell[,] gameBoard;

    private bool manualCellSettingEnabled = false;
    private Camera mainCamera;
    private int gameBoardLength;
    private int gameBoardHeight;
    private Vector3 cameraCenter;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        // Calculate the center of the camera
        cameraCenter = mainCamera.transform.position;
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update any continuous game logic here
    }

    // Initialize the game board
    public void InitializeGameBoard()
    {
        gameBoard = new Cell[gameBoardLength, gameBoardHeight];
    }

    // Populate the game board with cells
    public void PopulateGameBoardWithCells(float cellSizeX, float cellSizeY)
    {
        Cell cellComponent;

        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                Vector3 cellPosition = new Vector3(
                    cameraCenter.x - (gameBoardLength - 1) * 0.5f * cellSizeX + i * cellSizeX,
                    cameraCenter.y - (gameBoardHeight - 1) * 0.5f * cellSizeY + j * cellSizeY,
                    cameraCenter.z
                );

                GameObject cellObject = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                cellComponent = cellObject.GetComponent<Cell>();

                gameBoard[i, j] = cellComponent;
            }
        }

        // Connect each cell to its neighbors
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                cellComponent = gameBoard[i, j];
                cellComponent.SetTopLeft(GetNeighbor(i - 1, j - 1));
                cellComponent.SetTop(GetNeighbor(i, j - 1));
                cellComponent.SetTopRight(GetNeighbor(i + 1, j - 1));
                cellComponent.SetLeft(GetNeighbor(i - 1, j));
                cellComponent.SetRight(GetNeighbor(i + 1, j));
                cellComponent.SetBottomLeft(GetNeighbor(i - 1, j + 1));
                cellComponent.SetBottom(GetNeighbor(i, j + 1));
                cellComponent.SetBottomRight(GetNeighbor(i + 1, j + 1));
            }
        }
    }

    // Get the neighboring cell, considering wrapping
    private Cell GetNeighbor(int x, int y)
    {
        // Calculate wrapped indices for out-of-bounds coordinates
        x = (x + gameBoardLength) % gameBoardLength;
        y = (y + gameBoardHeight) % gameBoardHeight;

        return gameBoard[x, y];
    }

    // Calculate the next generation
    public void CalculateNextGeneration()
    {
        // First, calculate the next state for each cell
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                Cell currentCell = gameBoard[i, j];
                currentCell.CalculateNeighbours(); // Calculate the number of live neighbors
                currentCell.SetNextStatus(); // Calculate the next status based on the number of live neighbors
            }
        }

        // Then, apply the next state to all cells
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                Cell currentCell = gameBoard[i, j];
                currentCell.UpdateStatus(); // Set the current status to the next status
            }
        }

        currentGen++;
        UpdateText();
    }

    // Clear the grid to an initial state
    public void ClearGrid()
    {
        // Iterate through the entire grid and set all cells to the "Dead" state.
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                Cell currentCell = gameBoard[i, j];
                currentCell.SetStatus(Cell.CellState.Dead);
            }
        }

        currentGen = 0;
        UpdateText();
    }

    // Enable manual cell setting
    public void EnableManualCellSetting()
    {
        manualCellSettingEnabled = true;
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                Cell currentCell = gameBoard[i, j];
                currentCell.SetManual(true);
            }
        }
    }

    // Disable manual cell setting
    public void DisableManualCellSetting()
    {
        manualCellSettingEnabled = false;
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                Cell currentCell = gameBoard[i, j];
                currentCell.SetManual(false);
            }
        }
    }

    // Check if manual cell setting is enabled
    public bool IsManualCellSettingEnabled()
    {
        return manualCellSettingEnabled;
    }

    // Toggle the state of a specific cell (used in manual cell setting)
    public void ToggleCellState(int x, int y)
    {
        if (manualCellSettingEnabled && IsWithinBounds(x, y))
        {
            Cell currentCell = gameBoard[x, y];
            if (currentCell.GetStatus() == Cell.CellState.Alive)
            {
                currentCell.SetStatus(Cell.CellState.Dead);
            }
            else
            {
                currentCell.SetStatus(Cell.CellState.Alive);
            }
        }
    }

    // Check if given coordinates are within bounds of the game board
    private bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < gameBoardLength && y >= 0 && y < gameBoardHeight;
    }

    // Set the length of the game board
    public void SetGameBoardLength(int length)
    {
        gameBoardLength = length;
    }

    // Get the length of the game board
    public int GetGameBoardLength()
    {
        return gameBoardLength;
    }

    // Set the height of the game board
    public void SetGameBoardHeight(int height)
    {
        gameBoardHeight = height;
    }

    // Get the height of the game board
    public int GetGameBoardHeight()
    {
        return gameBoardHeight;
    }

    // Get a specific cell by its coordinates
    public Cell GetCell(int x, int y)
    {
        return gameBoard[x, y];
    }

    // Update the text displaying the current generation number
    public void UpdateText()
    {
        text.text = "Current Gen: " + currentGen;
    }
}
