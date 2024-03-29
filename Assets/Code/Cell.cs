using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cell : MonoBehaviour
{
    public SpriteRenderer sprite;
    private Color aliveColor = Color.black;
    private Color deadColor = Color.white;
    private bool manualSet = false;
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

    // Constructor for Cell class
    public Cell()
    {
        status = CellState.Dead;
        nextStatus = CellState.Dead;
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the cell's appearance based on its status (Alive/Dead)
        if (status == CellState.Alive)
        {
            sprite.color = aliveColor;
        }
        else if (status == CellState.Dead)
        {
            sprite.color = deadColor;
        }
    }

    private void OnMouseOver()
    {
        // Check if manual setting is enabled and allow toggling cell status on mouse click
        if (manualSet)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ToggleCellStatus();
            }
        }
    }

    public CellState GetStatus()
    {
        return status;
    }

    public void SetNextStatus()
    {
        // Calculate the next cell status based on the number of live neighbors
        if (status == CellState.Alive)
        {
            if (neighbourAlive < 2 || neighbourAlive > 3)
            {
                nextStatus = CellState.Dead;
            }
            else if ((neighbourAlive >= 2 && neighbourAlive <= 3) || (status == CellState.Dead && neighbourAlive == 3))
            {
                nextStatus = CellState.Alive;
            }
        }
        else
        {
            if (neighbourAlive == 3)
            {
                nextStatus = CellState.Alive;
            }
            else
            {
                nextStatus = CellState.Dead;
            }
        }
    }

    public void UpdateStatus()
    {
        // Update the current status based on the next status
        status = nextStatus;
    }

    public void CalculateNeighbours()
    {
        neighbourAlive = 0; // Reset the count

        // Check if neighbors exist before accessing their status
        if (topLeft != null && topLeft.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (top != null && top.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (topRight != null && topRight.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (left != null && left.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (right != null && right.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (bottomLeft != null && bottomLeft.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (bottom != null && bottom.GetStatus() == CellState.Alive)
        {
            neighbourAlive++;
        }
        if (bottomRight != null && bottomRight.GetStatus() == CellState.Alive)
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

    // Set Method for Status
    public void SetStatus(CellState state)
    {
        status = state;
    }

    // Toggle the cell status between Alive and Dead
    public void ToggleCellStatus()
    {
        if (GetStatus() == CellState.Alive)
        {
            SetStatus(CellState.Dead);
        }
        else
        {
            SetStatus(CellState.Alive);
        }
    }

    public void SetManual(bool state)
    {
        manualSet = state;
    }
}
