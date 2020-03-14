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
            float verycommon = 0.0533f; //5.33 - 2.71 = 2.62
            float common = 0.027f; //2.7 - 1.51 = 1.19
            float semirare = 0.015f; //1.5 - 0.81 = 0.69
            float rare = 0.008f; //0.8 - 0.31 = 0.49
            float veryrare = 0.003f;  //0.3

            float p = Random.Range(0.0f, 90.0f);

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
