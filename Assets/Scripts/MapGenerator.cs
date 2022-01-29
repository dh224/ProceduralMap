using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GridVisualizer gridVisualizer;

    [Range(3, 20)] public int width, height = 11;
    private MapGrid mapGrid;
    void Start()
    {
        mapGrid = new MapGrid(width, height);
        gridVisualizer.VisualizeGrid(width,height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
