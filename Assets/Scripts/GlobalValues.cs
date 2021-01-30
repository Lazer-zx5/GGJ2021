using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GlobalValues
{
    public static int tilePrice = 2;
    public static int subjectCount = 5;

    private static Stack<int> data = new Stack<int>(new [] { 2, 2, 2, 2, 2, 4, 4, 4, 4, 6, 6, 6, 8, 8, 10});
    private static List<Stack<int>> cards;

    public enum DiceFaces_t
    {
        SCIENCE,
        ART,
        SPORTS,
        HUMANITIES,
        ENTERTAINMENT,
        PETS
    };
}
