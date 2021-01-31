using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private Color color;
    private int points;
    private GlobalValues.Card_t currentCard;

    public Player(string name, Color color, int points)
    {
        this.name = name ?? throw new ArgumentNullException(nameof(name));
        this.color = color;
        this.points = points;
    }

    public int Points { get => points; set => points = value; }
    public Color Color { get => color; set => color = value; }
    public GlobalValues.Card_t CurrentCard { get => currentCard; set => currentCard = value; }
}
