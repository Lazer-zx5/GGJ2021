using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public static class GlobalValues
{
    public static int tilePrice = 2;
    public static int tileCount = 20;
    public static int subjectCount = 5;
    private static Random rng = new Random();

    public struct Card_t
    {
        int cost;
        int subject;
        int type;

        public int Cost { get => cost; set => cost = value; }
        public int Subject { get => subject; set => subject = value; }
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

    public enum DiceFaces_t
    {
        SCIENCE,
        ART,
        SPORTS,
        HUMANITIES,
        ENTERTAINMENT
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
        DANCING,
        POETRY,
        POTTERY
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
