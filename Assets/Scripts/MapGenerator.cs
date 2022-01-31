using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MapGenerator : MonoBehaviour
{
    public GridVisualizer gridVisualizer;

    [Range(3, 20)] public int width, height = 11;
    private MapGrid mapGrid;
    public Direction startEdge, exitEdge;
    public bool randomPlacement;
    private Vector3 startPosition, exitPosition;
    [Range(1,30)]
    public int numberOfPieces;
    [FormerlySerializedAs("MapVisualizer")] public MapVisualizer mapVisualizer;
    void Start()
    {
        GenerateNewMap();
        gridVisualizer.VisualizeGrid(width,height);
    }
    public void GenerateNewMap()
    {
        mapVisualizer.ClearMap();
        mapGrid = new MapGrid(width, height); 
        MapHelper.RandomlyChooseAndSetStartAndExit(mapGrid,ref startPosition,ref exitPosition, randomPlacement, startEdge,
            exitEdge);
        CandidateMap map = new CandidateMap(mapGrid, numberOfPieces);
        map.CreateMap(startPosition, exitPosition);
        mapVisualizer.VisualizeMap(mapGrid,map.GetMapData(),false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
