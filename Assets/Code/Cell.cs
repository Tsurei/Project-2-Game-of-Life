using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private SpriteRenderer sprite;
    public enum CellState
    {
        Alive,
        Dead
    }
    private CellState status;
    private CellState nextStatus;
    private Cell topLeft;
    private Cell top;
    private Cell topRight;
    private Cell left;
    private Cell right;
    private Cell bottomLeft;
    private Cell bottom;
    private Cell bottomRight;

    public Cell(Cell topLeft,
                Cell top, 
                Cell topRight, 
                Cell left, 
                Cell right, 
                Cell bottomLeft, 
                Cell bottom, 
                Cell bottomRight
                )
    {
        status = CellState.Dead;
        this.topLeft = topLeft;
        this.top = top;
        this.topRight = topRight;
        this.left = left;
        this.right = right;
        this.bottomLeft = bottomLeft;
        this.bottom = bottom;
        this.bottomRight = bottomRight;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(status == CellState.Alive)
        {
            //Make sprite alive sprite
        }else if(status == CellState.Dead)
        {
            //Make sprite dead sprite
        }
    }

    public CellState GetStatus()
    {
        return status;
    }

    public void SetStatus(CellState state)
    {
        status = state;
    }
}
