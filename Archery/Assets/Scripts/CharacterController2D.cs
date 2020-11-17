using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterController2D : MonoBehaviour
{
    float hort;
    float vert;

    float speed;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //hort = Input.GetAxisRaw("Horizontal");
        //vert = Input.GetAxisRaw("Vertical");

        anim.SetBool("Drawn", Input.GetButton("Fire1"));
    }
}
