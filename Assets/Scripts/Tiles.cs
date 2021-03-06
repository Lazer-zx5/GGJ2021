﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tiles : MonoBehaviour
{
    private bool isFull;
    private bool isDead;
    private Player owner;
    private bool isOpened;
    private int tilePoints;

    public Tiles(bool isOpened, bool isDead, bool isFull, int tilePoints)
    {
        this.owner = null;
        this.isDead = isDead;
        this.isFull = isFull;
        this.isOpened = isOpened;
        this.tilePoints = tilePoints;
    }

    public Player Owner { get => owner; set => owner = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public bool IsFull { get => isFull; set => isFull = value; }
    public bool IsOpened { get => isOpened; set => isOpened = value; }
    public int TilePoints { get => tilePoints; set => tilePoints = value; }
}
