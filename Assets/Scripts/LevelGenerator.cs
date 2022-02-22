using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int gridSize;
    public List<Tile> floorTilePrefabs;
    public GameObject gridHolder;

    public Tile[,] floorGridTiles { get; set; }

    private static LevelGenerator _instance;
    public static LevelGenerator Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

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
        floorGridTiles = new Tile[gridSize, gridSize];

        foreach (Transform child in gridHolder.transform)
            Destroy(child.gameObject);

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Tile newSquare2 = Instantiate(floorTilePrefabs[Random.RandomRange(0, floorTilePrefabs.Count)], new Vector3(i, 0, j), Quaternion.identity, gridHolder.transform);
                floorGridTiles[i, j] = newSquare2;
            }
        }
    }

    void SpawnCharacter()
    {

    }
}
