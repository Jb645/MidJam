﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainController : MonoBehaviour
{
    [Header("Needed")]
    public GameObject tile;
    [Header("Start Settings")]
    public int verticalSpace;

    [Header("Settings")]
    public int islandSize;
    public int iSpread;
    public int iSpreadChance;
    public int resources;
    public int rSpread;
    public int rSpreadChance;
    private Transform[] chunk;
    private tileScript[][,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        if (verticalSpace > 5 && islandSize > 15 && resources > 3)
        {
            chunk = new Transform[3];
            tiles = new tileScript[3][,];
            for (int i = 0; i < 3; i++)
            {
                GameObject newChunk = new GameObject("Chunk 1");
                Instantiate(newChunk, new Vector3(0, 0, 0), Quaternion.identity);
                chunk[i] = newChunk.transform;
                tiles[i] = new tileScript[50, verticalSpace];
                for (int x = 0; x < 50; x++)
                {
                    for (int y = 0; y < verticalSpace; y++)
                    {
                        GameObject temp = Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity);
                        temp.transform.parent = chunk[i];
                        tiles[i][x, y] = temp.GetComponent<tileScript>();
                    }
                }
            }
        }
        else
        {
            Debug.Log("ERROR: Wrong world generation settings");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            purgeIsland(0);
            createIsland(0);
        }
    }

    public void createIsland(int pos)
    {
        Vector2 pivot = new Vector2(25, verticalSpace / 2);
        Vector2 safearea(int[] limits,int spread){
            Vector2 moved = new Vector2(0, 0);
            while (moved.x == 0){
                moved = new Vector2(pivot.x + Random.Range(-spread, spread), pivot.y + Random.Range(-spread, spread));
                if (moved.x < limits[0] || moved.x > limits[1] || moved.y < limits[2] || moved.y >= limits[3]){
                    moved.x = 0;
                }
            }
            return moved;
        }
        int remain = islandSize;
        int topLine = verticalSpace - 5;
        while (remain > 0){
            Vector2 moved = safearea(new int[] { 1, 46, 1, topLine }, iSpread);
            for (int x = 0; x < 3; x++){
                for (int y = 0; y < 3; y++){
                    if (tiles[pos][x+(int)moved.x, y+(int)moved.y].getState() == 0){
                        remain--;
                        tiles[pos][x+(int)moved.x, y+(int)moved.y].setState(1);
                    }
                }
            }
            if (Random.Range(0, iSpreadChance) == 1)
                pivot = moved;
        }
        void resourceFill(int type){
            int notCrash = resources * 5;
            remain = resources;
            while (remain > 0 && notCrash > 0){
                Vector2 moved = safearea(new int[] { 0, 49, 0, verticalSpace }, rSpread);
                notCrash--;
                if (tiles[pos][(int)moved.x, (int)moved.y].getState() != 0){
                    if (tiles[pos][(int)moved.x, (int)moved.y].getContent() == -1){
                        remain--;
                        tiles[pos][(int)moved.x, (int)moved.y].setContent(type);
                    }
                    if (Random.Range(0, rSpreadChance) == 1)
                        pivot = moved;
                }
            }
        }
        resourceFill(0);
        resourceFill(1);
        pivot = new Vector2(25, verticalSpace / 2);
        resourceFill(0);
        resourceFill(1);
        pivot = safearea(new int[] { 0, 49, 0, verticalSpace }, rSpread * 2);
        resourceFill(0);
        resourceFill(1);
    }
    public void purgeIsland(int pos)
    {
        for (int x = 0; x < 50; x++){
            for (int y = 0; y < verticalSpace; y++){
                tiles[pos][x, y].setState(0);
            }
        }
    }

}
