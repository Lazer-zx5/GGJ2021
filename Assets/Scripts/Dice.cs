using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Dice
{
    public static GlobalValues.DiceFaces_t Roll()
    {
        return (GlobalValues.DiceFaces_t)(System.Environment.TickCount % 6);
    }
}
