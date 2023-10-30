using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    private Cell[,] gameBoard;

    [SerializeField]private int gameBoardLength;
    [SerializeField]private int gameBoardHeight;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * []Set Starting gameboard length and height
         * []Divide camera section by length and height
         * to allow individual squares to propgate the
         * screen fully
         * []fill the array randomly with dead or alive cell
         * objects
         * 
         */
        gameBoard = new Cell[gameBoardLength, gameBoardHeight];

        //Create gameboard
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                Cell c = new Cell();
                gameBoard[i, j] = c;

                // Connect each cell to its neighbors
                c.SetTopLeft(GetNeighbor(i - 1, j - 1));
                c.SetTop(GetNeighbor(i, j - 1));
                c.SetTopRight(GetNeighbor(i + 1, j - 1));
                c.SetLeft(GetNeighbor(i - 1, j));
                c.SetRight(GetNeighbor(i + 1, j));
                c.SetBottomLeft(GetNeighbor(i - 1, j + 1));
                c.SetBottom(GetNeighbor(i, j + 1));
                c.SetBottomRight(GetNeighbor(i + 1, j + 1));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            // Handle edge cases by wrapping around (assuming a toroidal grid)
            x = (x + gameBoardLength) % gameBoardLength;
            y = (y + gameBoardHeight) % gameBoardHeight;
            return gameBoard[x, y];
        }
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
}
