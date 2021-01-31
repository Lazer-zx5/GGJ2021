﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards
{
    private List<int> data = new List<int>(new [] { 2, 2, 2, 2, 2, 4, 4, 4, 4, 6, 6, 6, 8, 8, 10});

    private Dictionary<GlobalValues.ScienceSubjects_t, Stack<int>> science;
    private Dictionary<GlobalValues.ArtSubjects_t, Stack<int>> art;
    private Dictionary<GlobalValues.EntertainmentSubjects_t, Stack<int>> entertainment;
    private Dictionary<GlobalValues.HumanitiesSubjects_t, Stack<int>> humanity;
    private Dictionary<GlobalValues.SportsSubjects_t, Stack<int>> sports;

    private void generateStacks<StackType>(ref Dictionary<StackType, Stack<int>> dest)
    {
        foreach (StackType i in Enum.GetValues(typeof(StackType)))
        {
            data.Shuffle<int>();
            dest.Add(i, new Stack<int>(data.ToArray()));
        }
    }

    public void InitCards()
    {
        generateStacks<GlobalValues.ScienceSubjects_t>(ref science);
        generateStacks<GlobalValues.ArtSubjects_t>(ref art);
        generateStacks<GlobalValues.EntertainmentSubjects_t>(ref entertainment);
        generateStacks<GlobalValues.HumanitiesSubjects_t>(ref humanity);
        generateStacks<GlobalValues.SportsSubjects_t>(ref sports);
    }

    public Cards()
    {
        science = new Dictionary<GlobalValues.ScienceSubjects_t, Stack<int>>();
        art = new Dictionary<GlobalValues.ArtSubjects_t, Stack<int>>();
        entertainment = new Dictionary<GlobalValues.EntertainmentSubjects_t, Stack<int>>();
        humanity = new Dictionary<GlobalValues.HumanitiesSubjects_t, Stack<int>>();
        sports = new Dictionary<GlobalValues.SportsSubjects_t, Stack<int>>();
    }

    public GlobalValues.Card_t GetCard(GlobalValues.DiceFaces_t face, GameObject cardPrefab)
    {
        GlobalValues.Card_t obj = new GlobalValues.Card_t();
        switch (face)
        {
            case GlobalValues.DiceFaces_t.ART:
                GlobalValues.ArtSubjects_t artTmp = (GlobalValues.ArtSubjects_t)Enum.ToObject(typeof(GlobalValues.ArtSubjects_t), UnityEngine.Random.Range(0, GlobalValues.subjectCount - 1));
                obj.Cost = art[artTmp].Pop();
                obj.Type = (int)GlobalValues.DiceFaces_t.ART;
                obj.Subject = artTmp.ToString();
                obj.CardPrefab = cardPrefab;
                obj.CreateCardGameObject();
                return obj;
            case GlobalValues.DiceFaces_t.SCIENCE:
                GlobalValues.ScienceSubjects_t scienceTmp = (GlobalValues.ScienceSubjects_t)Enum.ToObject(typeof(GlobalValues.ScienceSubjects_t), UnityEngine.Random.Range(0, GlobalValues.subjectCount - 1));
                obj.Cost = science[scienceTmp].Pop();
                obj.Type = (int)GlobalValues.DiceFaces_t.SCIENCE;
                obj.Subject = scienceTmp.ToString();
                obj.CardPrefab = cardPrefab;
                obj.CreateCardGameObject();
                return obj;
            case GlobalValues.DiceFaces_t.HUMANITIES:
                GlobalValues.HumanitiesSubjects_t humanTmp = (GlobalValues.HumanitiesSubjects_t)Enum.ToObject(typeof(GlobalValues.HumanitiesSubjects_t), UnityEngine.Random.Range(0, GlobalValues.subjectCount - 1));
                obj.Cost = humanity[humanTmp].Pop();
                obj.Type = (int)GlobalValues.DiceFaces_t.HUMANITIES;
                obj.Subject = humanTmp.ToString();
                obj.CardPrefab = cardPrefab;
                obj.CreateCardGameObject();
                return obj;
            case GlobalValues.DiceFaces_t.ENTERTAINMENT:
                GlobalValues.EntertainmentSubjects_t entertainmentTmp = (GlobalValues.EntertainmentSubjects_t)Enum.ToObject(typeof(GlobalValues.EntertainmentSubjects_t), UnityEngine.Random.Range(0, GlobalValues.subjectCount - 1));
                obj.Cost = entertainment[entertainmentTmp].Pop();
                obj.Type = (int)GlobalValues.DiceFaces_t.ENTERTAINMENT;
                obj.Subject = entertainmentTmp.ToString();
                obj.CardPrefab = cardPrefab;
                obj.CreateCardGameObject();
                return obj;
            case GlobalValues.DiceFaces_t.SPORTS:
                GlobalValues.SportsSubjects_t sportTmp = (GlobalValues.SportsSubjects_t)Enum.ToObject(typeof(GlobalValues.SportsSubjects_t), UnityEngine.Random.Range(0, GlobalValues.subjectCount - 1));
                obj.Cost = sports[sportTmp].Pop();
                obj.Type = (int)GlobalValues.DiceFaces_t.SPORTS;
                obj.Subject = sportTmp.ToString();
                obj.CardPrefab = cardPrefab;
                obj.CreateCardGameObject();
                return obj;
            default:
                obj.Cost = 0;
                obj.Subject = "";
                obj.Type = -1;
                return obj;
        }
    }
}
