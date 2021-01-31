using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGO : MonoBehaviour
{
    public float speed = 3000f;

    private Vector3 start;
    private Vector3 des;
    private float fraction = 0;

    void Start()
    {
        start = new Vector3(733, 0, 0);
        des = new Vector3(-733, 200, 0);

    }

    void Update()
    {
        if (fraction < 1)
        {
            fraction += Time.deltaTime * speed;
            transform.localPosition = Vector3.Lerp(start, des, fraction);
        }
    }
}
