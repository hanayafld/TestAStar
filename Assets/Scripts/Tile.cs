using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TextMesh textMeshF;
    public TextMesh textMeshG;
    public TextMesh textMeshH;
    public TextMesh textMeshPos;
    public GameObject imageGo;

    //int 0 : normal // 1 : impos // 2 : start // 3 : end 
    public int tileType;

    public int f;
    public int g;
    public int h;

    public Vector2 pos;

    void Start()
    {
        StartCoroutine(this.SetText());
        if (this.tileType == 1)
        {
            this.imageGo.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (this.tileType == 2)
        {
            this.imageGo.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (this.tileType == 3)
        {
            this.imageGo.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            this.imageGo.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    private IEnumerator SetText()
    {
        while (true)
        {
            this.pos = new Vector2(-this.transform.position.y, this.transform.position.x);
            this.textMeshPos.text = string.Format("{0}, {1}", -this.transform.position.y, this.transform.position.x);
            //this.textMeshF.text = this.f.ToString();
            //this.textMeshG.text = this.g.ToString();
            //this.textMeshH.text = this.h.ToString();

            yield return null;
        }
    }
}
