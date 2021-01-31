using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalValues
{
    public static int tilePrice = 4;
    public static int tileCount = 24;
    public static int subjectCount = 5;
    public static int tileMaxCoins = 30;
    public static int tileMaxThreshold = 10;

    public struct Card_t
    {
        int type;
        int cost;
        int subject;

        public int Cost { get => cost; set => cost = value; }
        public int Type { get => type; set => type = value; }
        public int Subject { get => subject; set => subject = value; }
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
        ART,
        SPORTS,
        SCIENCE,
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
        PETS,
        GAMING,
        MOVIES,
        HIKING,
        PARTYING
    };

    public enum ArtSubjects_t
    {
        MUSIC,
        POETRY,
        DANCING,
        DRAWING,
        POTTERY
    };

    public enum HumanitiesSubjects_t
    {
        LAW,
        TOURISM,
        CULTURES,
        LANGUAGES,
        ARCHEOLOGY
    };
}
