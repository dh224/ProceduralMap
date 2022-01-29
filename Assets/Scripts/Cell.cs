using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum CellObjectType
{
    Empty,
    Road,
    Obstacle,
    Start,
    Exit,
}

public class Cell
{
    private int x, z;
    private bool isTaken;
    private CellObjectType objectType;


    public Cell(int x, int z)
    {
        this.x = x;
        this.z = z;
        objectType = CellObjectType.Empty;
        isTaken = false;
    }
    
    public int X{get=>x;}
    public int Z{get=>z;}
    public bool IsTaken
    {
        get => isTaken;
        set => isTaken = value;
    }
    public CellObjectType ObjectType
    {
        get => objectType;
        set => objectType = value;
    }
}
