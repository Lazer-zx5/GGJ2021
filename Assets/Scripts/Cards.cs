using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Subjects
{
    Math,
    Physics
};

public class Cards : MonoBehaviour
{
    private Stack<int> data = new Stack<int>(new [] { 2, 2, 2, 2, 2, 4, 4, 4, 4, 6, 6, 6, 8, 8, 10});

    private List<Dictionary<Subjects, Stack<int>>> science;
    private Stack<Stack<int>> art;
    private Stack<Stack<int>> entertainment;
    private Stack<Stack<int>> humanity;
    private Stack<Stack<int>> pets;

    public void InitCards()
    {
        for (int i = 0; i < GlobalValues.subjectCount; i++)
        {
            science.Push(data.Sufle());
            art.Push(data);
            entertainment.Push(data);
            humanity.Push(data);
            pets.Push(data);
        }
    }

    int GetCard(GlobalValues.DiceFaces_t face)
    {
        switch(face)
        {
            case GlobalValues.DiceFaces_t.ART:
                art.Peek
            case GlobalValues.DiceFaces_t.SCIENCE:
            case GlobalValues.DiceFaces_t.HUMANITIES:
            case GlobalValues.DiceFaces_t.PETS:
            case GlobalValues.DiceFaces_t.ENTERTAINMENT:
        }
    }
}
