using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    public GameObject groundPrefab;

    public void VisualizeGrid(int width, int height)
    {
        Vector3 position = new Vector3(width / 2, 0, height / 2);
        Quaternion rotation = Quaternion.Euler(90,0,0);
        GameObject board = Instantiate(groundPrefab, position, rotation);
        board.transform.localScale = new Vector3(width, height, 1);
    }

}
