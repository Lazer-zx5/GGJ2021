using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles
{
    private bool isFull;
    private bool isDead;
    private bool isOpened;
    private int tilePoints;
    private Player owner;
    private string skill;

    public Tiles(bool isOpened, bool isDead, bool isFull, int tilePoints)
    {
        this.owner = null;
        this.isDead = isDead;
        this.isFull = isFull;
        this.isOpened = isOpened;
        this.tilePoints = tilePoints;
        this.skill = "";
    }

    public Player Owner { get => owner; set => owner = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public bool IsFull { get => isFull; set => isFull = value; }
    public bool IsOpened { get => isOpened; set => isOpened = value; }
    public int TilePoints { get => tilePoints; set => tilePoints = value; }
    public string Skill { get => skill; set => skill = value; }
}
