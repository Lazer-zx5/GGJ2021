using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Field mainField;
    private List<Player> players;
    private Cards cards;
    private int currentPlayer;
    private int playerCount;

    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private List<GameObject> tileObjects;
    [SerializeField]
    private List<Sprite> skillIcons;

    private Dictionary<string, Sprite> scienceIcons;
    private Dictionary<string, Sprite> artIcons;
    private Dictionary<string, Sprite> sportsIcons;
    private Dictionary<string, Sprite> humIcons;
    private Dictionary<string, Sprite> entIcons;


    public void InitGame(int playerCount, int fieldCount, string [] playerColors, string [] playerNames)
    {
        this.currentPlayer = 0;
        this.playerCount = playerCount;
        mainField = new Field(fieldCount, playerCount, tileObjects);
        players = new List<Player>();
        cards = new Cards();
   
        for (int i = 0; i < playerCount; i++)
        {
            players.Add(new Player(playerNames[i], playerColors[i], 0));
        }
        InitSkillSprites();
        cards.InitCards();
    }

    private int genSkillSpriteInit<StackType>(ref Dictionary<string, Sprite> dest, int counter)
    {
        foreach (StackType i in Enum.GetValues(typeof(StackType)))
        {
            dest[i.ToString()] = skillIcons[counter++];
        }

        return counter;
    }

    private void InitSkillSprites()
    {
        scienceIcons = new Dictionary<string, Sprite>();
        sportsIcons = new Dictionary<string, Sprite>();
        artIcons = new Dictionary<string, Sprite>();
        humIcons = new Dictionary<string, Sprite>();
        entIcons = new Dictionary<string, Sprite>();

        int i = 0;
        i = genSkillSpriteInit<GlobalValues.ScienceSubjects_t>(ref scienceIcons, i);
        i = genSkillSpriteInit<GlobalValues.ArtSubjects_t>(ref artIcons, i);
        i = genSkillSpriteInit<GlobalValues.SportsSubjects_t>(ref sportsIcons, i);
        i = genSkillSpriteInit<GlobalValues.HumanitiesSubjects_t>(ref humIcons, i);
        i = genSkillSpriteInit<GlobalValues.EntertainmentSubjects_t>(ref entIcons, i);
    }

    public int SelectPlayer()
    {
        int playerIndex = this.currentPlayer;

        if (playerIndex < this.playerCount - 1)
            playerIndex++;
        else
            playerIndex = 0;

        return playerIndex;
    }

    public GlobalValues.Status_t Play(Player player, int currentTileNumber, bool buy = false)
    {
        GlobalValues.Status_t status = GlobalValues.Status_t.OKAY;
        if (buy)
        {
            mainField.BuyTile(ref player, currentTileNumber);
        }

        if (player.CurrentCard.Cost > 0)
        {
            status = mainField.PutCard(player.CurrentCard, currentTileNumber, ref player, player.CurrentCard.Cost);
        }

        return status;
    }

    private void Start()
    {
        string[] playerColors = { "Red", "Blue" };
        string[] playerNames = { "1Red", "2Blue" };
        InitGame(playerColors.Length, GlobalValues.tileCount, playerColors, playerNames);

        if (!mainField.EndGame())
        {
            currentPlayer = SelectPlayer();
        }
        else
        {
            // End of the game
        }
    }

    public void RollDice()
    {
        GlobalValues.DiceFaces_t currentDiceFace = Dice.Roll();
        Debug.Log(currentDiceFace.ToString());
        if (currentDiceFace == GlobalValues.DiceFaces_t.KARMA)
        {
            //mainField.Karma(players[currentPlayer]);  // null ref error 
        }
        else
        {
            GlobalValues.Card_t currentCard = cards.GetCard(currentDiceFace);
            GameObject cardObj = GameObject.Instantiate(cardPrefab, GameObject.Find("Main Game Canvas").transform);
            cardObj.transform.GetChild(0).GetComponent<Text>().text = currentCard.Subject.ToUpper();
            switch (currentCard.Type)
            {
                case (int)GlobalValues.DiceFaces_t.SCIENCE:
                    cardObj.transform.GetChild(1).GetComponent<Image>().sprite = scienceIcons[currentCard.Subject];
                    break;
                case (int)GlobalValues.DiceFaces_t.ART:
                    cardObj.transform.GetChild(1).GetComponent<Image>().sprite = artIcons[currentCard.Subject];
                    break;
                case (int)GlobalValues.DiceFaces_t.SPORTS:
                    cardObj.transform.GetChild(1).GetComponent<Image>().sprite = sportsIcons[currentCard.Subject];
                    break;
                case (int)GlobalValues.DiceFaces_t.HUMANITIES:
                    cardObj.transform.GetChild(1).GetComponent<Image>().sprite = humIcons[currentCard.Subject];
                    break;
                case (int)GlobalValues.DiceFaces_t.ENTERTAINMENT:
                    cardObj.transform.GetChild(1).GetComponent<Image>().sprite = entIcons[currentCard.Subject];
                    break;
                default:
                    break;
            }
            cardObj.transform.GetChild(2).GetComponent<Text>().text = $"+{currentCard.Cost}";

            players[currentPlayer].CurrentCard = currentCard;

            if (GlobalValues.Status_t.OKAY != Play(players[currentPlayer], mainField.CurrentTileNumber))
            {
                // notify user that something wrong
            }
        }

        if (currentPlayer == playerCount - 1)
            mainField.EndOfYear();
    }
}