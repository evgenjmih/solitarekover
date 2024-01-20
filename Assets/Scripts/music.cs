using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource mus;
    public bool hur;
    // Start is called before the first frame update
    void Start()
    {
        hur = true;
        print(hur);
        mus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hur == true)
        {
            mus.Play();
        }
        else
        {
            mus.Stop();
        }
    }
}
