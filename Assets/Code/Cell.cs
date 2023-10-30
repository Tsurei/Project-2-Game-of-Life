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
    private int neighbourAlive = 0;

    public Cell()
    {
        /*
                Cell topLeft,
                Cell top, 
                Cell topRight, 
                Cell left, 
                Cell right, 
                Cell bottomLeft, 
                Cell bottom, 
                Cell bottomRight
        */
        status = CellState.Dead;
        /*
                this.topLeft = topLeft;
                this.top = top;
                this.topRight = topRight;
                this.left = left;
                this.right = right;
                this.bottomLeft = bottomLeft;
                this.bottom = bottom;
                this.bottomRight = bottomRight;
        */
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

    public void SetNextStatus()
    {
        if(neighbourAlive < 2 || neighbourAlive > 3)
        {
            nextStatus = CellState.Dead;
        }else if( (neighbourAlive >= 2 && neighbourAlive <= 3) || (status == CellState.Dead && neighbourAlive == 3) ){
            nextStatus = CellState.Alive;
        }
    }

    public void SetStatus()
    {
        status = nextStatus;
    }

    public void CalculateNeighbours()
    {
        if(topLeft.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (top.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (topRight.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (left.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (right.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (bottomLeft.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (bottom.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (bottomRight.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
    }

    // Accessor methods for neighboring cells
    public Cell GetTopLeft()
    {
        return topLeft;
    }

    public void SetTopLeft(Cell cell)
    {
        topLeft = cell;
    }

    public Cell GetTop()
    {
        return top;
    }

    public void SetTop(Cell cell)
    {
        top = cell;
    }

    public Cell GetTopRight()
    {
        return topRight;
    }

    public void SetTopRight(Cell cell)
    {
        topRight = cell;
    }

    public Cell GetLeft()
    {
        return left;
    }

    public void SetLeft(Cell cell)
    {
        left = cell;
    }

    public Cell GetRight()
    {
        return right;
    }

    public void SetRight(Cell cell)
    {
        right = cell;
    }

    public Cell GetBottomLeft()
    {
        return bottomLeft;
    }

    public void SetBottomLeft(Cell cell)
    {
        bottomLeft = cell;
    }

    public Cell GetBottom()
    {
        return bottom;
    }

    public void SetBottom(Cell cell)
    {
        bottom = cell;
    }

    public Cell GetBottomRight()
    {
        return bottomRight;
    }

    public void SetBottomRight(Cell cell)
    {
        bottomRight = cell;
    }

    // Accessor methods for neighbor count
    public int GetNeighbourAliveCount()
    {
        return neighbourAlive;
    }

    public void SetNeighbourAliveCount(int count)
    {
        neighbourAlive = count;
    }
}
