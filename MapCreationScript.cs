using Pathfinding.Util;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapCreationScript : MonoBehaviour
{
    public Tile highlightTile;
    public Tilemap highlightMap;
    public Tile highlightTileW;
    public Tilemap highlightMapW;
    public GameObject spawner;
    public GameObject player;
    public GameObject weaponSpawner;
    public int weaponNumber = 0;
    public List<Vector3Int> spawnTile = new List<Vector3Int>();


    int y = 0;
    int x;
    public int tilesToSpawn; 
    int w;
    int spawnerNumber=0;
    int counter = 0;
    int counterSpawn = 0;
    Vector3Int currentCell;
    Vector3Int randomCell;
    Vector3Int plusX;
    Vector3Int minusX;
    Vector3Int plusY;
    Vector3Int minusY;
    Vector3Int randomRange;
    GameObject path;
    AstarPath aPath;
    float rangeBetween=0;

    void Start()
    {
        x = Random.Range(-40, 40);
        y = Random.Range(-40, 40);

        Vector3Int currentCell = highlightMap.WorldToCell(new Vector2(x, y));
        randomCell=highlightMap.WorldToCell(new Vector2(x, y));
        tilesToSpawn=Random.Range(2000, 3000);

        plusX = highlightMap.WorldToCell(new Vector2(1, 0));
        minusX = highlightMap.WorldToCell(new Vector2(-1, 0));
        plusY = highlightMap.WorldToCell(new Vector2(0, 1));
        minusY = highlightMap.WorldToCell(new Vector2(0, -1));

        path = GameObject.FindGameObjectWithTag("PathFinder");
        aPath = path.GetComponent<AstarPath>();

        spawnerNumber = Random.Range(2, 6);
        weaponNumber = Random.Range(2, 20);
    }


    private void Update()
    {
        MapCreation();
        if (counterSpawn==1)
        {
            Spawn();
            counterSpawn=2;
        }
    }


    public void MapCreation()
    {
        randomCell = highlightMap.WorldToCell(new Vector2(Random.Range(-40, 40), Random.Range(-40, 40)));
        if (w < tilesToSpawn)
        {
            if (highlightMap.HasTile(currentCell) == false)
            {
                highlightMap.SetTile(currentCell, highlightTile);
            }
            if (highlightMap.HasTile(currentCell + plusX) == false)
            {
                highlightMap.SetTile(currentCell + plusX, highlightTile);
            }
            if (highlightMap.HasTile(currentCell + minusX) == false)
            {
                highlightMap.SetTile(currentCell + minusX, highlightTile);
            }
            if (highlightMap.HasTile(currentCell + plusY) == false)
            {
                highlightMap.SetTile(currentCell + plusY, highlightTile);
            }
            if (highlightMap.HasTile(currentCell + minusY) == false)
            {
                highlightMap.SetTile(currentCell + minusY, highlightTile);
            }
            currentCell = randomCell;
            w++;
        }

        if (w == tilesToSpawn)
        {
            for (int i = 0; i < 84; i++)
            {
                for (int p = 0; p < 84; p++)
                {
                    Vector3Int currentSecondCell = highlightMap.WorldToCell(new Vector2(-42 + p, -42 + i));
                    if (highlightMap.HasTile(currentSecondCell) == false)
                    {
                        highlightMapW.SetTile(currentSecondCell, highlightTileW);
                        if (i == 83 && p==83 && counter<=1)
                        {
                            aPath.Scan();
                            counter++;
                            counterSpawn++;
                        }
                    }
                }
            }
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < 84; i++)
        {
            for (int p = 0; p < 84; p++)
            {
                Vector3Int currentSpawnCell = highlightMap.WorldToCell(new Vector2(-42 + p, -42 + i));
                if (highlightMap.HasTile(currentSpawnCell) == true && highlightMapW.HasTile(currentSpawnCell + plusX) == false && 
                    highlightMapW.HasTile(currentSpawnCell + plusY) == false && highlightMapW.HasTile(currentSpawnCell + minusX) == false && 
                    highlightMapW.HasTile(currentSpawnCell + minusY) == false && highlightMapW.HasTile(currentSpawnCell + plusX + plusY) == false && 
                    highlightMapW.HasTile(currentSpawnCell + plusY + minusX) == false && highlightMapW.HasTile(currentSpawnCell + minusX + minusY) == false && 
                    highlightMapW.HasTile(currentSpawnCell + plusX + minusY) == false && highlightMap.HasTile(currentSpawnCell + plusX) && 
                    highlightMap.HasTile(currentSpawnCell + plusY) && highlightMap.HasTile(currentSpawnCell + minusX) && highlightMap.HasTile(currentSpawnCell + minusY))
                {
                        spawnTile.Add(currentSpawnCell);
                }
            }
        }


        List<Vector3Int> tilesToRemove = new List<Vector3Int>();
        for (int i = 0; i < weaponNumber; i++)
        {
            randomRange = spawnTile[Random.Range(0, spawnTile.Count)];

            foreach (Vector3Int cell in spawnTile)
            {
                rangeBetween = Vector3Int.Distance(randomRange, cell);
                if (rangeBetween < 5)
                {
                    tilesToRemove.Add(cell);
                }
            }

            foreach (Vector3Int tileToRemove in tilesToRemove)
            {
                spawnTile.Remove(tileToRemove);
            }

            tilesToRemove.Clear();

            Instantiate(weaponSpawner, randomRange, Quaternion.identity);
            spawnTile.Remove(randomRange);
        }


        for (int i = 0; i < spawnerNumber; i++)
        {
            randomRange = spawnTile[Random.Range(0, spawnTile.Count)];

            foreach (Vector3Int cell in spawnTile)
            {
                rangeBetween = Vector3Int.Distance(randomRange, cell);
                if (rangeBetween < 20)
                {
                    tilesToRemove.Add(cell);
                }
            }

            foreach (Vector3Int tileToRemove in tilesToRemove)
            {
                spawnTile.Remove(tileToRemove);
            }

            tilesToRemove.Clear();

            Instantiate(spawner, randomRange, Quaternion.identity);
            spawnTile.Remove(randomRange);
        }

        randomRange = spawnTile[Random.Range(0, spawnTile.Count)];
        Instantiate(player, randomRange, Quaternion.identity);
        GameObject loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen");
        loadingScreen.SetActive(false);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(-84,84));
    }
}
