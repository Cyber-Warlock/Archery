﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Used for developer visualization
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * -1;
    }
}
