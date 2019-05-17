using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAStar : MonoBehaviour
{
    public Tile[] Tiles;
    public Button btn;

    private Tile[,] arrTiles = new Tile[5, 7];
    private Tile startTile;

    private List<Tile> openList = new List<Tile>();
    private List<Tile> closeList = new List<Tile>();

    void Start()
    {
        //이차원 배열만들기
        int k = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                this.arrTiles[i, j] = Tiles[k];
                Debug.Log(arrTiles[i, j].pos);
                k++;
            }
        }

        this.startTile = arrTiles[2, 1];

        this.btn.onClick.AddListener(() =>
        {
            Debug.Log("버튼누름");
            this.startTile.imageGo.GetComponent<SpriteRenderer>().color = Color.red;
            int x = (int)this.arrTiles[2, 1].pos.x;
            int y = (int)this.arrTiles[2, 1].pos.y;
            
            var pos = this.arrTiles[x, y].pos;
            
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = (int)pos.x + i;
                    int newY = (int)pos.y + j;
                    
                    if (newX == pos.x && newY == pos.y)
                    {
                        this.closeList.Add(this.arrTiles[newX, newY]);
                    }
                    else if(arrTiles[newX,newY].tileType!=1)
                    {
                        this.openList.Add(this.arrTiles[newX, newY]);
                        foreach (var data in openList)
                        {
                            data.imageGo.GetComponent<SpriteRenderer>().color = Color.yellow;
                        }
                    }
                }
            }

        });
    }
}
