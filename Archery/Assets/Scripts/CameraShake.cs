using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
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
        float magnitude = (arrowVelocity.x + arrowVelocity.y) / 800;

        Vector3 initPos = transform.position;

        float time = 0f;

        do
        {
            float offsetX = Random.Range(-1, 1) * magnitude;
            float offsetY = Random.Range(-1, 1) * magnitude;

            transform.position = initPos + new Vector3(offsetX, offsetY);

            time += Time.deltaTime;

            yield return null;

        } while (time < duration);

        transform.position = initPos;
    }
}
