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
        for(int i = 0; i < gameBoardLength; i++)
        {
            for(int j = 0; j < gameBoardHeight; j++)
            {
                Cell c = new Cell();
                gameBoard[i, j] = c;
            }
        }
        for (int i = 0; i < gameBoardLength; i++)
        {
            for (int j = 0; j < gameBoardHeight; j++)
            {
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
