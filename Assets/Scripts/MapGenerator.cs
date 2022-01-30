using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GridVisualizer gridVisualizer;

    [Range(3, 20)] public int width, height = 11;
    private MapGrid mapGrid;
    public Direction startEdge, exitEdge;
    public bool randomPlacement;
    private Vector3 startPosition, exitPosition;
    [Range(1,10)]
    public int numberOfPieces;

    public MapVisualizer MapVisualizer;
    void Start()
    {
        mapGrid = new MapGrid(width, height);
        gridVisualizer.VisualizeGrid(width,height);
        MapHelper.RandomlyChooseAndSetStartAndExit(mapGrid,ref startPosition,ref exitPosition, randomPlacement, startEdge,
            exitEdge);
        CandidateMap map = new CandidateMap(mapGrid, numberOfPieces);
        map.CreateMap(startPosition, exitPosition);
        MapVisualizer.VisualizeMap(mapGrid,map.GetMapData(),false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
