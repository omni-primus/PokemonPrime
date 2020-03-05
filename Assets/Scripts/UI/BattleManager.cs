using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public BattleMenu currentMenu;
    private GameManager gm;

    [Header("Selecion")]
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

    [Header("Pokemon-Player")]
    public GameObject PlayerDetails;
    public Text pPokeName;
    public Text pPokeLevel;
    public Text pPokeHP;


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
    }

    // Update is called once per frame
    void Update()
    {
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
            if (currentMenu == BattleMenu.Selection)
            {
                if(currentSelection == 1)
                {
                    ChangeMenu(BattleMenu.Fight);
                }
                if (currentSelection == 4)
                {
                    gm.LeaveBattle();
                }
            }
            if (currentMenu == BattleMenu.Fight)
            {
                Debug.Log("Test");
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
                break;
        }
    }
    public void UpdateEnemyPokemonDetails(string PokemonName, int elevel, int eHP, int eMaxHP, string PlayerPokemonName, int pLevel, int pHP, int pMaxHP)
    {
        ePokeName.text = PokemonName;
        ePokeLevel.text = "Lv " + elevel;
        ePokeHP.text = eHP + "/" + eMaxHP;

        pPokeName.text = PlayerPokemonName;
        pPokeLevel.text = "Lv " + pLevel;
        pPokeHP.text = pHP + "/" + pMaxHP;
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
