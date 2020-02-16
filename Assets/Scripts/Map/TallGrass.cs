using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tall grass handling, encountering pokemon

public class TallGrass : MonoBehaviour
{
    public BiomeList grassType;

    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<PlayerMovement>())
        {
            //P= x / 187.5
            //VC = 10, C= 8.5, semi-rare = 6.75, Rare = 3.33 VR = 1.24
            float verycommon = 10 / 187.5f; //5.3333
            float common = 8.5f / 187.5f; //4.5333
            float semirare = 6.75f / 187.5f; //3.6
            float rare = 3.33f / 187.5f; //1.776
            float veryrare = 1.24f / 187.5f;  //0.661

            float p = Random.Range(0.0f, 50.0f);

            if(p < veryrare*100)
            {
                if (gm != null)
                    gm.EnterBattle(Rarity.VeryRare);
            }
            else if(p < rare*100)
            {
                if (gm != null)
                    gm.EnterBattle(Rarity.Rare);
            }
            else if (p < semirare * 100)
            {
                if (gm != null)
                    gm.EnterBattle(Rarity.SemiRare);
            }
            else if (p < common * 100)
            {
                if (gm != null)
                    gm.EnterBattle(Rarity.Common);
            }
            else if (p < verycommon * 100)
            {
                if (gm != null)
                    gm.EnterBattle(Rarity.VeryCommon);
            }
        }
    }
}
