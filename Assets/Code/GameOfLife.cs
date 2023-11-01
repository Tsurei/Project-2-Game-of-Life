using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeGameBoard()
    {
        gameBoard = new Cell[gameBoardLength, gameBoardHeight];
    }

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
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                // Connect each cell to its neighbors
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


    private Cell GetNeighbor(int x, int y)
    {
        // Calculate wrapped indices for out-of-bounds coordinates
        x = (x + gameBoardLength) % gameBoardLength;
        y = (y + gameBoardHeight) % gameBoardHeight;

        return gameBoard[x, y];
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
    public bool IsManualCellSettingEnabled()
    {
        return manualCellSettingEnabled;
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
