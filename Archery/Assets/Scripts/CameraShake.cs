using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    float velocityDampener = 600f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator ShakeCamera(float duration, Vector2 arrowVelocity)
    {
        // Gives the possibility of a slight variance to cam shake depending on arrow velocity, higher = more shake
        float magnitude = (arrowVelocity.x + arrowVelocity.y) / velocityDampener;

        // Cache the position of camera so it can be reset later
        Vector3 initPos = transform.position;

        float time = 0f;

        do
        {
            // Get a random offset for X & Y dependent on the calculated magnitude
            float offsetX = Random.Range(-magnitude, magnitude);
            float offsetY = Random.Range(-magnitude, magnitude);

            // Apply the offset
            transform.position = initPos + new Vector3(offsetX, offsetY);

            time += Time.deltaTime;

            yield return null;

        } while (time < duration);

        // Reset camera to original position
        transform.position = initPos;
    }
}
