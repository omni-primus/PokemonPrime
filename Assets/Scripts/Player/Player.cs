using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pokemon, Items the Player currently has

public class Player : MonoBehaviour
{
    public List<OwnedPokemon> ownedPokemon = new List<OwnedPokemon>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class OwnedPokemon
{
    public string NickName;
    public BasePokemon pokemon;
    public int level;
    public List<PokemonMoves> moves = new List<PokemonMoves>();
}
