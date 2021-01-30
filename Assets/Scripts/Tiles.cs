using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    private bool isOpened;
    private bool isDead;
    private int tilePoints;

    public Tiles(bool isOpened, bool isDead, int tilePoints)
    {
        this.isOpened = isOpened;
        this.isDead = isDead;
        this.tilePoints = tilePoints;
    }

    public bool IsOpened { get => isOpened; set => isOpened = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public int TilePoints { get => tilePoints; set => tilePoints = value; }
}
