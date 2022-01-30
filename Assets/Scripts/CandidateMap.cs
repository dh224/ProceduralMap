using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandidateMap
{
    public MapGrid mapGrid { get; }
    private int numberOfPieces = 0;
    private bool[] obstacleArray { get; set; } = null;
    private Vector3 startPoint,exitPoint;
    private List<KnightPiece> knightPiecesList; 
    public CandidateMap(MapGrid grid ,int numberOfPieces)
    {
        this.numberOfPieces = numberOfPieces;
        mapGrid = grid;
    }

    public void CreateMap(Vector3 startPosition, Vector3 exitPosition, bool autoRepair = false)
    {
        this.startPoint = startPosition;
        this.exitPoint = exitPosition;
        obstacleArray = new bool[mapGrid.Width * mapGrid.Height];
        knightPiecesList = new List<KnightPiece>();
        RandomlyPlaceKnightPieces(this.numberOfPieces);

        PlaceObstacles();
    }
    private bool CheckIfPositionCanBeObstacle(Vector3 position)
    {
        if (position == startPoint || position == exitPoint)
        {
            return false;
        }

        int index = mapGrid.CalculateIndexFromCoorinates(position.x, position.y);
        return obstacleArray[index] == false;
    }

    private void RandomlyPlaceKnightPieces(int numberOfPieces)
    {
        var count = numberOfPieces;
        var knightPlacementTrylimit = 100;
        while (count > 0 && knightPlacementTrylimit > 0)
        {
            Debug.Log(obstacleArray.Length);
            var randomIndex = Random.Range(0, obstacleArray.Length);
            if (obstacleArray[randomIndex] == false)
            {
                var coordinates = mapGrid.CalculateCoordinatesFromIndex(randomIndex);
                if (coordinates == startPoint || coordinates == exitPoint)
                {
                    knightPlacementTrylimit--;
                    continue;
                }
                obstacleArray[randomIndex] = true;
                KnightPiece temp = new KnightPiece(coordinates);
                knightPiecesList.Add(temp);
                count--;
            }
            knightPlacementTrylimit--;
        }
    }

    private void PlaceObstaclesForThisKnight(KnightPiece knightPiece)
    {
        foreach (var move in KnightPiece.listOfPossibleMoves)
        {
            var newPosition = knightPiece.Position + move;
            if (mapGrid.IsCellValid(newPosition.x,newPosition.z) && CheckIfPositionCanBeObstacle(newPosition))
            {
                obstacleArray[mapGrid.CalculateIndexFromCoorinates(newPosition.x, newPosition.z)] = true;
            }
        }
    }

    private void PlaceObstacles()
    {
        foreach (var knightPiece in knightPiecesList)
        {
            PlaceObstaclesForThisKnight(knightPiece);
        }
    }
    public MapData GetMapData()
    {
        return new MapData
        {
            obstacleArray = this.obstacleArray,
            knightPiecesList = knightPiecesList,
            startPosition = this.startPoint,
            exitPosition = exitPoint,
        };
    }
}
