using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class BattleManager : MonoBehaviour
{
    public BattleMenu currentMenu;
    private GameManager gm;

    [Header("Selection")]
    public GameObject SelectionMenu;
    public GameObject SelectionInfo;
    public Text selectionInfoText;
    public Text fight;
    private string fightT;
    public Text bag;
    private string bagT;
    public Text pokemon;
    private string pokemonT;
    public Text run;
    private string runT;

    [Header("Moves")]
    public GameObject movesMenu;
    public GameObject movesDetails;
    public Text PP;
    public Text pType;
    public Text moveO;
    private string moveOT;
    public Text moveT;
    private string moveTT;
    public Text moveTH;
    private string moveTHT;
    public Text moveF;
    private string movefT;

    [Header("Info")]
    public GameObject InfoMenu;
    public Text InfoText;

    [Header("Misc")]
    public int currentSelection;

    [Header("Pokemon-Enemy")]
    public GameObject enemyDetails;
    public Text ePokeName;
    public Text ePokeLevel;
    public Text ePokeHP;
    public Slider eHpSlider;

    [Header("Pokemon-Player")]
    public GameObject PlayerDetails;
    public Text pPokeName;
    public Text pPokeLevel;
    public Text pPokeHP;
    public Slider pHpSlider;

    [Header("BattleState")]
    public BattleState state;


    void Start()
    {
        fightT = fight.text;
        bagT = bag.text;
        pokemonT = pokemon.text;
        runT = run.text;
        moveOT = moveO.text;
        moveTT = moveT.text;
        moveTHT = moveTH.text;
        movefT = moveF.text;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        state = BattleState.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == BattleState.Start || state == BattleState.None || state == BattleState.Run)
        {
            enemyDetails.gameObject.SetActive(false);
            PlayerDetails.gameObject.SetActive(false);
        }
        else
        {
            enemyDetails.gameObject.SetActive(true);
            PlayerDetails.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentSelection == 1 || currentSelection == 2)
            {
                currentSelection = currentSelection + 2;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentSelection == 3 || currentSelection == 4)
            {
                currentSelection = currentSelection - 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelection == 2 || currentSelection == 4)
            {
                currentSelection--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentSelection == 1 || currentSelection == 3)
            {
                currentSelection++;
            }
        }
        if (Input.GetKeyDown("return"))
        {
            
            //In case Run was Selected
            if (currentMenu == BattleMenu.Info)
            {
                if (state == BattleState.Run)
                {
                    gm.LeaveBattle();
                }
            }

            //return for Fight Menu
            if (currentMenu == BattleMenu.Fight)
            {
                if (currentSelection == 1)
                {
                    //Attack(gm.playerTempPoke, gm.tempPoke, 4);
                }
            }

            //return for Move Selection
            if (currentMenu == BattleMenu.Selection)
            {
                if(currentSelection == 1)
                {
                    ChangeMenu(BattleMenu.Fight);
                }
                if (currentSelection == 4)
                {
                    InfoText.text = "You ran from the battle!";
                    ChangeMenu(BattleMenu.Info);
                    state = BattleState.Run;
                }
            }
            //return for Info Text
            if (currentMenu == BattleMenu.Info)
            {
                if (state == BattleState.Start)
                {
                    ChangeMenu(BattleMenu.Selection);
                    state = BattleState.PlayerTurn;
                    selectionInfoText.text = "Choose your move..";
                }
            }
        }
        if (Input.GetKeyDown("x"))
        {
            if (currentMenu == BattleMenu.Fight)
            {
                ChangeMenu(BattleMenu.Selection);
            }
        }

            if (currentSelection == 0)
            currentSelection = 1;

        switch (currentMenu)
        {
            case BattleMenu.Fight:
                switch (currentSelection)
                {
                    case 1:
                        moveO.text = "> " + moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        moveF.text = movefT;
                        break;
                    case 2:
                        moveO.text = moveOT;
                        moveT.text = "> " + moveTT;
                        moveTH.text = moveTHT;
                        moveF.text = movefT;
                        break;
                    case 3:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = "> " + moveTHT;
                        moveF.text = movefT;
                        break;
                    case 4:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        moveF.text = "> " + movefT;
                        break;

                }

                break;
            case BattleMenu.Selection:
                switch (currentSelection)
                {
                    case 1:
                        fight.text = "> " + fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        break;
                    case 2:
                        fight.text = fightT;
                        bag.text = "> " + bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        break;
                    case 3:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = "> " + pokemonT;
                        run.text = runT;
                        break;
                    case 4:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = "> " + runT;
                        break;
                }

                break;
        }
    }

    public void ChangeMenu(BattleMenu m)
    {
        currentMenu = m;
        currentSelection = 1;
        switch (m)
        {
            case BattleMenu.Selection:
                SelectionMenu.gameObject.SetActive(true);
                SelectionInfo.gameObject.SetActive(true);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                InfoMenu.gameObject.SetActive(false);
                break;
            case BattleMenu.Fight:
                SelectionMenu.gameObject.SetActive(false);
                SelectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(true);
                movesDetails.gameObject.SetActive(true);
                InfoMenu.gameObject.SetActive(false);
                break;
            case BattleMenu.Info:
                SelectionMenu.gameObject.SetActive(false);
                SelectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                InfoMenu.gameObject.SetActive(true);
                break;
            case BattleMenu.Off:
                SelectionMenu.gameObject.SetActive(false);
                SelectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                InfoMenu.gameObject.SetActive(false);
                enemyDetails.gameObject.SetActive(false);
                PlayerDetails.gameObject.SetActive(false);
                break;
        }
    }
    public void UpdatePokemonDetails(string PokemonName, int elevel, int eHP, int eMaxHP, string PlayerPokemonName, int pLevel, int pHP, int pMaxHP)
    {
        SetHUD(eMaxHP, eHP, PokemonName, elevel, ePokeName, ePokeLevel, ePokeHP, eHpSlider);
        SetHP(eHP, eHpSlider);

        SetHUD(pMaxHP, pHP, PlayerPokemonName, pLevel, pPokeName, pPokeLevel, pPokeHP, pHpSlider);
        SetHP(pHP, pHpSlider);
    }
    public void SetHUD(int maxHP, int hp, string PName, int level, Text PokeName, Text PokeLevel, Text PokeHP, Slider slider)
    {
        PokeName.text = PName;
        PokeLevel.text = "Lv " + level;
        PokeHP.text = hp + "/" + maxHP;
        slider.maxValue = maxHP;
        slider.value = hp;
    }

    public void SetHP(int hp, Slider slider)
    {
        slider.value += hp;
    }
    public void Attack(BasePokemon Attacker, BasePokemon Defender, int Damage)
    {
        Defender.currentHP += -(Damage);
    }
}

public enum BattleMenu
{
    Selection,
    Pokemon,
    Bag,
    Fight,
    Info,
    Off
}

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost,
    Run,
    None
}