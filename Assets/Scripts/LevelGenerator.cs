using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int gridSize;
    public GameObject[] floorTilePrefabs;
    public GameObject gridHolder;

    // Start is called before the first frame update
    void Start()
    {
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
            GameObject newSquare = Instantiate(floorTilePrefabs[Random.RandomRange(0, 3)], new Vector3(i,0,0), Quaternion.identity, gridHolder.transform);
            for (int j = 0; j < gridSize; j++)
            {
                GameObject newSquare2 = Instantiate(floorTilePrefabs[Random.RandomRange(0, 3)], new Vector3(i, 0, j), Quaternion.identity, gridHolder.transform);
            }
        }
    }
}
