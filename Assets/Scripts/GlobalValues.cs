using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public static class GlobalValues
{
    public static int tilePrice = 4;
    public static int tileCount = 24;
    public static int subjectCount = 5;
    public static int tileMaxCoins = 30;
    public static int tileMaxThreshold = 10;

    public struct Card_t
    {
        int cost;
        string subject;
        int type;

        public int Cost { get => cost; set => cost = value; }
        public string Subject { get => subject; set => subject = value; }
        public int Type { get => type; set => type = value; }
    };


    public static void Shuffle<T>(this List<T> ts)
    {
        int count = ts.Count;
        int last = count - 1;
        for (int i = 0; i < last; ++i)
        {
            int r = UnityEngine.Random.Range(i, count);
            T tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public enum Status_t
    {
        OKAY = 0,
        TILE_NOT_AVAILABLE = int.MinValue,
        TILE_IS_DEAD

        
    };

    public enum DiceFaces_t
    {
        SCIENCE,
        ART,
        SPORTS,
        HUMANITIES,
        ENTERTAINMENT,
        KARMA
    };

    public enum ScienceSubjects_t
    {
        MATH,
        PHYSICS,
        BIOLOGY,
        CHEMISTERY,
        ENGINEERING
    };

    public enum SportsSubjects_t
    {
        SOCCER,
        BIKING,
        TENNIS,
        PARKOUR,
        SWIMMING
    };

    public enum EntertainmentSubjects_t
    { 
        GAMING,
        PARTYING,
        MOVIES,
        HIKING,
        PETS
    };

    public enum ArtSubjects_t
    {
        DRAWING,
        MUSIC,
        POETRY,
        POTTERY,
        DANCING
    };

    public enum HumanitiesSubjects_t
    {
        LANGUAGES,
        CULTURES,
        TOURISM,
        ARCHEOLOGY,
        LAW
    };
}
