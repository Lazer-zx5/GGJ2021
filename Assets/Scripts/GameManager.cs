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
   
        for (int i = 0; i < playerCount; i++)
        {
            players.Add(new Player(playerNames[i], playerColors[i], 0));
        }

        cards.InitCards();
    }

    public void Play()
    {
        GlobalValues.DiceFaces_t currentDiceFace = Dice.Roll();
        switch(currentDiceFace)
        {
            case GlobalValues.DiceFaces_t.SCIENCE:
                
                break;
            case GlobalValues.DiceFaces_t.SPORTS:
                break;
            case GlobalValues.DiceFaces_t.HUMANITIES:
                break;
            case GlobalValues.DiceFaces_t.ENTERTAINMENT:
                break;
            case GlobalValues.DiceFaces_t.PETS:
                break;
            case GlobalValues.DiceFaces_t.ART:
                break;


        }
        
    }

}
