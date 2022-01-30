using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform parent;
    public Color startColor, exitColor;

    private Dictionary<Vector3, GameObject> dictionaryOfObstacles;
    private void Awake()
    {
        parent = this.transform;
        dictionaryOfObstacles = new Dictionary<Vector3, GameObject>();
    }

    public void VisualizeMap(MapGrid grid, MapData mapData, bool visualizeUsingPrefabs)
    {
        if (visualizeUsingPrefabs)
        {
        }
        else
        {
            VisualizeUsingPrimitives(grid, mapData);
        }
    }

    private void VisualizeUsingPrimitives(MapGrid grid, MapData mapData)
    {
        PlaceStartAndExitPosition(mapData);
        for (int i = 0; i < mapData.obstacleArray.Length; i++)
        {
            if (mapData.obstacleArray[i])
            {
                var positionOnGrid = grid.CalculateCoordinatesFromIndex(i);
                if (positionOnGrid == mapData.startPosition || positionOnGrid == mapData.exitPosition)
                {
                    continue;
                }
                grid.SetCell(positionOnGrid.x,positionOnGrid.z,CellObjectType.Obstacle);
                bool t = PlaceKnightObstacle(mapData, positionOnGrid);
                if (t)
                {
                    continue;
                }

                if (!dictionaryOfObstacles.ContainsKey(positionOnGrid))
                {
                    CreateIndicator(positionOnGrid,Color.white,PrimitiveType.Cube);
                }
            }
        }
    }

    private bool PlaceKnightObstacle(MapData mapData, Vector3 positionOnGrid)
    {
        foreach (var knight in mapData.knightPiecesList)
        {
            if (knight.Position == positionOnGrid)
            {
                CreateIndicator(positionOnGrid,Color.red,PrimitiveType.Cube);
                return true;
            }
        }
        return false;
    }
    private void PlaceStartAndExitPosition(MapData mapData)
    {
        CreateIndicator(mapData.startPosition, startColor,PrimitiveType.Sphere);
        CreateIndicator(mapData.exitPosition,exitColor,PrimitiveType.Sphere);
    }

    private void CreateIndicator(Vector3 position, Color startColor,PrimitiveType sphere)
    {
        var element = GameObject.CreatePrimitive(sphere);
        element.transform.position = position + new Vector3(0.5f,0.5f,0.5f);
        element.transform.parent = this.parent;
        Renderer renderer = element.transform.GetComponent<Renderer>();
        Debug.Log("adadad");
        renderer.material.SetColor("_Color",startColor);
        dictionaryOfObstacles.Add(position,element);
    }

    public void ClearMap()
    {
        foreach (var obstacle in dictionaryOfObstacles.Values)
        {
            Destroy(obstacle);
        }
        dictionaryOfObstacles.Clear();
    }
}
