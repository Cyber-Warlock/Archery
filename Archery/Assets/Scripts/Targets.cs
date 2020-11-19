using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    // Component.particleSystem is deprecated but requires new keyword to indicate intended hiding
    [SerializeField]
    new ParticleSystem particleSystem = default;

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
        // If an arrow hit this...
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // ... play some particle effects at the collision position
            particleSystem.transform.position = collision.transform.position;
            particleSystem.Play();

            // And a sound!
            AudioManager.Instance.Impact();
        }
    }
}
