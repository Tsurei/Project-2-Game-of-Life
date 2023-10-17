using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{

    private int[][] gameBoard;
    private int gameBoardLength;
    private int gameBoardHeight;
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
         * 
         * 
         *
         * 
         */
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
