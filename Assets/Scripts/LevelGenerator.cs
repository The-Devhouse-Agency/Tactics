using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int gridSize;
    public Tile[] floorTilePrefabs;
    public GameObject gridHolder;

    public Tile[,] floorGridTiles { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        floorGridTiles = new Tile[gridSize, gridSize];
        GenerateWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateWorld();
        }
    }

    void GenerateWorld()
    {
        foreach (Transform child in gridHolder.transform)
            Destroy(child.gameObject);

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Tile newSquare2 = Instantiate(floorTilePrefabs[Random.RandomRange(0, 3)], new Vector3(i, 0, j), Quaternion.identity, gridHolder.transform);
                floorGridTiles[i, j] = newSquare2;
            }
        }
    }
}
