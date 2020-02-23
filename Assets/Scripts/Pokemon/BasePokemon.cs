﻿using System.Collections;
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
    public int HP;
    private int maxHP;
    public Stat attStat;
    public Stat defStat;
    public Stat spAttStat;
    public Stat spDefStat;

    public PokemonStats pokemonStats;

    private int level;
    public bool canEvolve;
    public PokemonEvolution evolveTo;

    void Start()
    {
        maxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMember (BasePokemon bp)
    {
        this.Name = bp.Name;
        this.image = bp.image;
        this.biomeFound = bp.biomeFound;
        this.type = bp.type;
        this.rarity = bp.rarity;
        this.HP = bp.HP;
        this.maxHP = bp.maxHP;
        this.attStat = bp.attStat;
        this.defStat = bp.defStat;
        this.spAttStat = bp.spAttStat;
        this.spDefStat = bp.spDefStat;
        this.pokemonStats = bp.pokemonStats;
        this.level = bp.level;
        this.canEvolve = bp.canEvolve;
        this.evolveTo = bp.evolveTo;
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

[System.Serializable]
public class PokemonStats
{
    public int AttStat;
    public int DefStat;
    public int SpAttStat;
    public int SpDefStat;
    public int SpeedStat;
    public int EvasionStat;
}
