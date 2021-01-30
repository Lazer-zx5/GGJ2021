using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string name;
    private string color;
    private int points;

    public Player(string name, string color, int points)
    {
        this.name = name ?? throw new ArgumentNullException(nameof(name));
        this.color = color ?? throw new ArgumentNullException(nameof(color));
        this.points = points;
    }

    public int Points { get => points; set => points = value; }
    public string Color { get => color; set => color = value; }
}
