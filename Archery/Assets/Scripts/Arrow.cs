using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            IEnumerator cr = Camera.main.GetComponent<CameraShake>().ShakeCamera(0.1f, rb.velocity);

            StartCoroutine(cr);

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
