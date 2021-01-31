using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field
{
    private int fieldSize;
    private Tiles[] mainField;
    private int currentTileNumber;
    private Color inactiveColor = new Color(.4f, .4f, .4f, .6f);
    private Color activeColor = new Color(.05f, 1f, 1f);

    public Field(int fieldSize, int playerCount, List<GameObject> tileObjects)
    {
        this.fieldSize = fieldSize;
        mainField = new Tiles[fieldSize];

        for (int i = 0; i < fieldSize; i++)
            mainField[i] = new Tiles(false, false, false, 0);

        foreach (var tile in tileObjects)
        {
            tile.GetComponent<Image>().color = inactiveColor;
        }

        int j = 10;
        while(playerCount-- != 0)
        {
            mainField[j++].IsOpened = true;
            tileObjects[j].GetComponent<Image>().color = activeColor;
        }
    }

    public void BuyTile(ref Player player, int tileNumber)
    {
        mainField[tileNumber].Owner = player;
        GlobalValues.Card_t tmp;
        tmp = player.CurrentCard;
        tmp.Cost -= GlobalValues.tilePrice;
        player.CurrentCard = tmp;
    }

    public bool IsTileOwner(Player player, int tileNumber)
    {
        if (mainField[tileNumber].IsOpened && mainField[tileNumber].Owner.Color == player.Color)
            return true;

        return false;
    }

    public void Karma(Player player)
    {
        for (int i = 0; i < fieldSize; i++)
        {
            if (IsTileOwner(player, i) && mainField[i].TilePoints <= GlobalValues.tileMaxThreshold)
            {
                mainField[i].TilePoints = mainField[i].TilePoints % 2 == 0 ? mainField[i].TilePoints / 2 : (mainField[i].TilePoints + 1) / 2;
            }
        }
    }

    public void EndOfYear()
    {
        for (int i = 0; i < fieldSize; i++)
        {
            if (mainField[i].IsOpened && !mainField[i].IsFull)
            {
                if (mainField[i].TilePoints > 0)
                    mainField[i].TilePoints--;

                if (mainField[i].TilePoints == 0)
                {
                    mainField[i].IsFull = false;
                    mainField[i].IsOpened = false;
                    mainField[i].IsDead = true;
                }
            }
        }
    }

    public bool EndGame()
    {
        int count = 0;
        for (int i = 0; i < fieldSize; i++)
        {
            if (mainField[i].IsOpened)
            {
                count++;
            }
        }

        return (count + 1) == fieldSize;
    }

    public GlobalValues.Status_t PutCard(GlobalValues.Card_t currentCard, int tileNumber, ref Player player, int coins)
    {
        if (mainField[tileNumber].IsOpened && !mainField[tileNumber].IsFull)
        {
            mainField[tileNumber].TilePoints = (mainField[tileNumber].TilePoints + coins > GlobalValues.tileMaxCoins) ? GlobalValues.tileMaxCoins : mainField[tileNumber].TilePoints + coins;
            if (mainField[tileNumber].TilePoints == GlobalValues.tileMaxCoins)
            {
                mainField[tileNumber].IsFull = true;
            }

            player.Points += coins;
        }
        else if (mainField[tileNumber].IsFull || !mainField[tileNumber].IsOpened)
        {
            return GlobalValues.Status_t.TILE_NOT_AVAILABLE;
        }

        return GlobalValues.Status_t.OKAY; 
    }

    public Tiles[] MainField { get => mainField; set => mainField = value; }
    public int FieldSize { get => fieldSize; set => fieldSize = value; }
    public int CurrentTileNumber { get => currentTileNumber; set => currentTileNumber = value; }
}
