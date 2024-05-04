using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] CameraMovement cameraMovement;
    [SerializeField] int enemyCount;
    [SerializeField] Transform map;
    //private Point startSpawn, endSpawn;
    //[SerializeField] private GameObject StartPortal;
    //[SerializeField] private GameObject EndPortal;
    public Dictionary<Point,TileScript> Tiles { get; set; }
    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();  
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++) 
        {
            GameObject e= Instantiate(tilePrefabs[2]);
            e.SetActive(true);
            e.GetComponent<EnemyMover>().health = i * 5;
            yield return new WaitForSeconds(3f);
        }

    }
    private void CreateLevel()
    {
        Tiles= new Dictionary<Point,TileScript>();

        string[] mapData = ReadLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();
            for(int x = 0; x < mapX; x++)
            {
                PlaceTiles(newTiles[x].ToString(),x, y,worldStart);
            }
        }
        maxTile = Tiles[new Point(mapX-1,mapY-1)].transform.position;
        cameraMovement.SetLimits(new Vector3(maxTile.x +TileSize,maxTile.y -TileSize));

        //SpawnPortal();
    }

    private void PlaceTiles(string tileType, int x, int y,Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);

        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponentInChildren<TileScript>();
        newTile.SetUp(new Point(x,y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0),map);
    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty);
        return data.Split('-');
    }
    //private void SpawnPortal()
    //{
    //    startSpawn=new Point(0,0);
    //    Instantiate(StartPortal, Tiles[startSpawn].transform.position,Quaternion.identity);

    //    endSpawn = new Point(11, 6);
    //    Instantiate(EndPortal, Tiles[endSpawn].transform.position, Quaternion.identity);
    //}
}
