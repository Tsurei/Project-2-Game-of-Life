using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    private Cell[,] gameBoard;

    private Camera mainCamera;
    private int gameBoardLength;
    private int gameBoardHeight;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeGameBoard()
    {
        gameBoard = new Cell[gameBoardLength, gameBoardHeight];
    }

    public void PopulateGameBoardWithCells(GameObject cellPrefab, float cellSizeX, float cellSizeY)
    {
        // Calculate the center of the camera
        Vector3 cameraCenter = mainCamera.transform.position;

        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                // Calculate the position relative to the camera center
                Vector3 cellPosition = new Vector3(
                    cameraCenter.x - (gameBoardLength - 1) * 0.5f * cellSizeX + i * cellSizeX,
                    cameraCenter.y - (gameBoardHeight - 1) * 0.5f * cellSizeY + j * cellSizeY,
                    cameraCenter.z
                );

                // Instantiate the cell prefab as a GameObject at the calculated position
                GameObject cellObject = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                Cell cellComponent = cellObject.GetComponent<Cell>();

                // Connect each cell to its neighbors
                cellComponent.SetTopLeft(GetNeighbor(i - 1, j - 1));
                cellComponent.SetTop(GetNeighbor(i, j - 1));
                cellComponent.SetTopRight(GetNeighbor(i + 1, j - 1));
                cellComponent.SetLeft(GetNeighbor(i - 1, j));
                cellComponent.SetRight(GetNeighbor(i + 1, j));
                cellComponent.SetBottomLeft(GetNeighbor(i - 1, j + 1));
                cellComponent.SetBottom(GetNeighbor(i, j + 1));
                cellComponent.SetBottomRight(GetNeighbor(i + 1, j + 1));

                // Store the cell component in the game board array
                gameBoard[i, j] = cellComponent;
            }
        }
    }


    private Cell GetNeighbor(int x, int y)
    {
        // Check for out-of-bounds coordinates
        if (x >= 0 && x < gameBoardLength && y >= 0 && y < gameBoardHeight)
        {
            return gameBoard[x, y];
        }
        else
        {
            // Handle edge cases by wrapping around
            x = (x + gameBoardLength) % gameBoardLength;
            y = (y + gameBoardHeight) % gameBoardHeight;
            return gameBoard[x, y];
        }
    }


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
    }

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
    }

    private bool manualCellSettingEnabled = false;

    public void EnableManualCellSetting()
    {
        manualCellSettingEnabled = true;
    }

    public void DisableManualCellSetting()
    {
        manualCellSettingEnabled = false;
    }

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

    private bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < gameBoardLength && y >= 0 && y < gameBoardHeight;
    }

    public void SetGameBoardLength(int length)
    {
        gameBoardLength = length;
    }

    public int GetGameBoardLength()
    {
        return gameBoardLength;
    }

    public void SetGameBoardHeight(int height)
    {
        gameBoardHeight = height;
    }

    public int GetGameBoardHeight()
    {
        return gameBoardHeight;
    }

    public Cell GetCell(int x, int y)
    {
        return gameBoard[x, y];
    }
}
