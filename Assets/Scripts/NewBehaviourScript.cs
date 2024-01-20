using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Solitaire sol;
    private AudioSource mus;
    // Start is called before the first frame update
    void Start()
    {
        sol = GetComponent<Solitaire>();
        mus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sol.Rascladca == true)
        {
            mus.Play();
        }
        else
        {
            mus.Stop();
        }
    }
}
