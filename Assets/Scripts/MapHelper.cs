using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapHelper
{
    static MapHelper()
    {
    }

    public static void RandomlyChooseAndSetStartAndExit(MapGrid grid, ref Vector3 startPosition, ref Vector3
            exitPosition, bool randomPlacement, Direction startPositionEdge = Direction.Left,
        Direction exitPositionEdge = Direction.Right)
    {
        if (randomPlacement)
        {
            startPosition = RandomlyChooseAndSetStartAndExit(grid, startPosition);
            exitPosition =RandomlyChooseAndSetStartAndExit(grid, startPosition); 
        }
        else
        {
            startPosition = RandomlyChooseAndSetStartAndExit(grid, startPosition,startPositionEdge);
            exitPosition =RandomlyChooseAndSetStartAndExit(grid, startPosition,exitPositionEdge);  
        }
        grid.SetCell(startPosition.x,startPosition.z,CellObjectType.Start);
        grid.SetCell(exitPosition.x,exitPosition.z,CellObjectType.Exit);
    }

    public static Vector3 RandomlyChooseAndSetStartAndExit(MapGrid grid, Vector3 startPosition,Direction direction = Direction.None)
    {
        if (direction == Direction.None)
        {
            direction = (Direction)Random.Range(1, 5);
        }

        Vector3 position = Vector3.zero;
        switch (direction)
        {
            case Direction.None :
                break;
            case Direction.Left:
                do
                {
                    position = new Vector3(0, 0, Random.Range(0, grid.Height));
                } while (Vector3.Distance(position,startPosition) <= 1);
                break;
            case Direction.Right:
                do
                {
                    position = new Vector3(grid.Width - 1, 0, Random.Range(0, grid.Height));
                } while (Vector3.Distance(position,startPosition) <= 1);
                break;
            case Direction.Down:
                do
                {
                    position = new Vector3(Random.Range(0, grid.Width), 0, grid.Height - 1);
                } while (Vector3.Distance(position,startPosition) <= 1);
                break;
            case Direction.Up:
                do
                {
                    position = new Vector3(Random.Range(0, grid.Width), 0, 0);
                } while (Vector3.Distance(position,startPosition) <= 1);
                break;
        }

        return position;
    }
}
