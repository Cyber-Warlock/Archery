﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require components to avoid needing null checks
[RequireComponent(typeof(Animator))]
public class CharacterController2D : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Drawn", Input.GetButton("Fire1"));

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(0);
    }
}
