using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require components to avoid needing null checks
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            // Start coroutine by object to ensure correct amount and order of parameters
            IEnumerator cr = Camera.main.GetComponent<CameraShake>().ShakeCamera(0.1f, rb.velocity);
            StartCoroutine(cr);

            // Make a hard stop on the arrow to simulate a hard target
            rb.velocity = Vector2.zero;
        }
    }
}
