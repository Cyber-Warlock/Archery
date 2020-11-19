using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quick n Dirty audio control script
public class AudioManager : MonoBehaviour
{
    static AudioManager instance;

    [SerializeField]
    List<AudioSource> sources = default;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("AudioManager was null");
                //instance = new AudioManager();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Release()
    {
        sources[0].Play();
    }

    public void Impact()
    {
        sources[1].Play();
    }
}
