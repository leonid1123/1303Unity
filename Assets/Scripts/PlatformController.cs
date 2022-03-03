using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private int dir = 1;
    void Start()
    {
        InvokeRepeating("ChangeDir", 0f, 0.8f);
    }

    void Update()
    {
        transform.Translate(Vector2.up * dir*Time.deltaTime*5);
    }
    void ChangeDir()
    {
        dir *= -1;
    }
}
