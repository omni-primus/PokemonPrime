using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Values of a Pokemon

public class BasePokemon : MonoBehaviour
{
    public string Name;
    public Sprite image;
    public BiomeList biomeFound;
    public PokemonType type;
    public Rarity rarity;
    public Stat hpStat;
    public Stat attStat;
    public Stat defStat;
    public Stat spAttStat;
    public Stat spDefStat;
    public float Speed;

    private int level;
    public bool canEvolve;
    public PokemonEvolution evolveTo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Rarity
{
    VeryCommon,
    Common,
    SemiRare,
    Rare,
    VeryRare
}

public enum PokemonType
{
    normal,
    grass,
    fire,
    water,
    poison,
    steel,
    rock,
    ground,
    crystal,
    ice,
    flying,
    electric,
    psychic,
    ghost,
    fighting,
    dragon,
    dark
}

[System.Serializable]
public class PokemonEvolution
{
    public BasePokemon nextEvolution;
    public int levelUpLevel;

}
