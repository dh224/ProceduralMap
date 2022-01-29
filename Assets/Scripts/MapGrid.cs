using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MapGrid
{
    private int width, height;
    private Cell[,] cellGrid;
    
    
    public int Width
    {
        get => width;
    }
    
    public int Height 
    {
        get => height;
    }

    public MapGrid(int width,int height)
    {
        this.width = width;
        this.height = height;
        CreateGrid();
    }

    private void CreateGrid()
    {
        cellGrid = new Cell[height,width];
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                cellGrid[row, col] = new Cell(col, row);
            }
        }
    }

    public void SetCell(int x, int z, CellObjectType cellObjectType, bool isTaken = false)
    {
            cellGrid[z,x].ObjectType = cellObjectType;
            cellGrid[z,x].IsTaken = isTaken;
    }

    public void SetCell(float x, float z, CellObjectType cellObjectType, bool isTaken = false)
    {
        SetCell(Mathf.RoundToInt(z),Mathf.RoundToInt(x),cellObjectType);
    }

    public bool IsCellTaken(int x, int z)
    {
        return cellGrid[z,x].IsTaken;
    }
    
    public bool IsCellTaken(float x, float z)
    {
        return IsCellTaken(Mathf.RoundToInt(x), Mathf.RoundToInt(z));
    }

    public bool IsCellValid(float x, float z)
    {
        if (x >= width || x < 0 || z >= height || z < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public Cell GetCell(int x, int z)
    {
        if (IsCellValid(x, z))
        {
            return cellGrid[z, x];
        }
        else
        {
            return null;
        }
    }
    
    public Cell GetCell(float x, float z)
    {
        return GetCell(Mathf.RoundToInt(x), Mathf.RoundToInt(z));
    }

    public int CalculateIndexFromCoorinates(int x, int z)
    {
        return z * width + x;
    }
    
    public int CalculateIndexFromCoorinates(float x, float z)
    {
        return Mathf.RoundToInt(z) * width + Mathf.RoundToInt(x);
    }

    public void CheckCoorinates()
    {
        for (int i = 0;  i< cellGrid.GetLength(0); i++)
        {
            StringBuilder b = new StringBuilder();
            for (int j = 0; j < cellGrid.GetLength(1); j++)
            {
                b.Append(j + ","  +i + " ");
            }
            Debug.Log(b.ToString());
        }
    }
}