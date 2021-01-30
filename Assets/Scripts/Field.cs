using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private int fieldSize;
    private Tiles[] mainField;
    private Dictionary<Player, Tiles> ownershipMap;

    public Field(int fieldSize, int playerCount)
    {
        this.fieldSize = fieldSize;
        mainField = new Tiles[fieldSize];

        int i = 0;
        while(playerCount-- != 0)
        {
            mainField[i++].IsOpened = true;
        }
    }

    public void BuyTile(Player player, Tiles tile)
    {
        ownershipMap.Add(player, tile);
        player.Points -= GlobalValues.tilePrice; 
    }

    public bool IsTileOwner(Player player, Tiles tile)
    {
        if (ownershipMap.ContainsKey(player))
            if (ownershipMap[player] == tile)
                return true;

        return false;
    }

    public Tiles[] MainField { get => mainField; set => mainField = value; }
    public int FieldSize { get => fieldSize; set => fieldSize = value; }
}
