using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Field mainField;
    private List<Player> players;
    private Cards cards;

    public void InitGame(int playerCount, int fieldCount, string [] playerColors, string [] playerNames)
    {
        mainField = new Field(fieldCount, playerCount);
        players = new List<Player>();
        cards = new Cards();
   
        for (int i = 0; i < playerCount; i++)
        {
            players.Add(new Player(playerNames[i], playerColors[i], 0));
        }

        cards.InitCards();
    }

    public void Play()
    {
        GlobalValues.DiceFaces_t currentDiceFace = Dice.Roll();
        GlobalValues.Card_t currentCard = cards.GetCard(currentDiceFace);

    }

    private void Start()
    {
        string[] playerColors = { "Red", "Blue" };
        string[] playerNames = { "1Red", "2Blue" };
        InitGame(playerColors.Length, GlobalValues.tileCount, playerColors, playerNames);

        Play();
    }

}
