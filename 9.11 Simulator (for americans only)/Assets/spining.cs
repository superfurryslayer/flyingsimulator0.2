﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spining : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 30f, Space.Self);
    }
}
