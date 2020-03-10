using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Overall Game Informations

public class GameManager : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject battleCamera;

    public GameObject player;
    public GameObject dPoke;
    public GameObject aPoke;
    public BasePokemon tempPoke;
    public BasePokemon playerTempPoke;
    public Player plyr;

    public List<BasePokemon> allPokemon = new List<BasePokemon>();
    public List<BasePokemon> Route1 = new List<BasePokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();

    public Transform defencePodium;
    public Transform attackPodium;

    public GameObject emptyPoke;
    public GameObject emptyfriendlyPoke;

    public BattleManager bm;
    private bool firstTime = true;

    void Start()
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterBattle(Rarity rarity)
    {
        //Camera into BattleMode
        playerCamera.SetActive(false);
        battleCamera.SetActive(true);

        //change State
        bm.state = BattleState.Start;
        //Get a Random Pokemon from the List
        BasePokemon battlePokemon = GetRandomPokemonFromList(GetPokemonByRarity(rarity));
        OwnedPokemon PlayerPokemon = GetOwnedPokemon(plyr.ownedPokemon);
        //Stop Player from Moving
        player.GetComponent<PlayerMovement>().isAllowedToMove = false;
        //Initiate Pokemon
        dPoke = Instantiate(emptyPoke, defencePodium.transform.position, Quaternion.identity) as GameObject;
        aPoke = Instantiate(emptyPoke, attackPodium.transform.position, Quaternion.identity) as GameObject;
        //Set Position to to a flat Number?
        Vector3 pokeLocalPos = new Vector3(0, 1, 0);
        Vector3 friendlyLocalPos = new Vector3(0, 0, 0);

        dPoke.transform.parent = defencePodium;
        aPoke.transform.parent = attackPodium;
        dPoke.transform.localPosition = pokeLocalPos;
        aPoke.transform.localPosition = friendlyLocalPos;

        dPoke.transform.parent = defencePodium;
        aPoke.transform.parent = attackPodium;
        //copy BasePokemon so it gets individuell
        tempPoke = dPoke.AddComponent<BasePokemon>() as BasePokemon;
        playerTempPoke = aPoke.AddComponent<BasePokemon>() as BasePokemon;
        tempPoke.AddMember(battlePokemon);
        playerTempPoke.AddMember(PlayerPokemon.pokemon);

        //Random level
        int p = Random.Range(2, 5);
        tempPoke.level = p;
        //PlayerPokemon Level
        playerTempPoke.level = PlayerPokemon.level;
        //calculate HP
        tempPoke.HP = (((2 * tempPoke.HP) * p) / 100) + p + 10;
        playerTempPoke.HP = (((2 * playerTempPoke.HP) * playerTempPoke.level) / 100) + playerTempPoke.level + 10;
        tempPoke.currentHP = tempPoke.HP;
        playerTempPoke.currentHP = playerTempPoke.HP;

        //Set Sprites
        dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.image;
        aPoke.GetComponent<SpriteRenderer>().sprite = PlayerPokemon.pokemon.image;
        //User Interface Update
        bm.InfoText.text = "A wild " + battlePokemon.Name + " appeared!";
        bm.ChangeMenu(BattleMenu.Info);
        bm.GetMoves(PlayerPokemon);
        //Update 
        bm.UpdatePokemonDetails(tempPoke.Name, tempPoke.level, tempPoke.currentHP, tempPoke.HP, PlayerPokemon.NickName, playerTempPoke.level, playerTempPoke.currentHP, playerTempPoke.HP);
    }

    public void LeaveBattle()
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);

        player.GetComponent<PlayerMovement>().isAllowedToMove = true;
        Destroy(dPoke);
        Destroy(aPoke);
        bm.ChangeMenu(BattleMenu.Off);
        bm.state = BattleState.None;
    }

    public List<BasePokemon> GetPokemonByRarity(Rarity rarity)
    {
        List<BasePokemon> returnPokemon = new List<BasePokemon>();
        foreach(BasePokemon Pokemon in allPokemon)
        {
            if (Pokemon.rarity == rarity)
                returnPokemon.Add(Pokemon);
        }
        return returnPokemon;
    }

    public BasePokemon GetRandomPokemonFromList(List<BasePokemon> pokeList)
    {
        BasePokemon poke = new BasePokemon();
        int pokeIndex = Random.Range(0, pokeList.Count - 1);
        poke = pokeList[pokeIndex];
        return poke;
    }

    public OwnedPokemon GetOwnedPokemon(List<OwnedPokemon> ownedPokemons)
    {
        OwnedPokemon PlayerPoke = new OwnedPokemon();
        PlayerPoke = ownedPokemons[0];
        return PlayerPoke;
    }
}

[System.Serializable]
public class PokemonMoves
{
    public string name;
    public MoveType category;
    public Stat moveStat;
    public PokemonType moveType;
    public int PP;
    public float power;
    public float accuracy;
}

[System.Serializable]
public class Stat
{
    public float currentStat;
}

public enum MoveType
{
    Physical,
    Special,
    Status
}