using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private Cards cards;
    private Field mainField;
    private int playerCount;
    private int currentPlayer;
    private List<Player> players;

    public void InitGame(int playerCount, int fieldCount, string [] playerColors, string [] playerNames)
    {
        this.currentPlayer = 0;
        this.playerCount = playerCount;

        mainField = new Field(fieldCount, playerCount);
        players = new List<Player>();
        cards = new Cards();
   
        for (int i = 0; i < playerCount; i++)
        {
            players.Add(new Player(playerNames[i], playerColors[i], 0));
        }

        cards.InitCards();
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

            GlobalValues.DiceFaces_t currentDiceFace = Dice.Roll();
            if (currentDiceFace == GlobalValues.DiceFaces_t.KARMA)
            {
                mainField.Karma(players[currentPlayer]);
            }
            else
            {
                GlobalValues.Card_t currentCard = cards.GetCard(currentDiceFace);
                players[currentPlayer].CurrentCard = currentCard;

                if (GlobalValues.Status_t.OKAY != Play(players[currentPlayer], mainField.CurrentTileNumber))
                {
                    // notify user that something wrong
                }
            }

            if (currentPlayer == playerCount - 1)
                mainField.EndOfYear();
        }
        else
        {
            // End of the game
        }
    }
}
