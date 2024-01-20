using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rend : MonoBehaviour
{
    private music mus;
    private SpriteRenderer h;
    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<SpriteRenderer>();
        mus = GetComponent<music>();
        print(mus);
    }

    // Update is called once per frame
    void Update()
    {
        if (mus.hur == true)
        {
            h.color = Color.white;
        }
        else
        {
            h.color = Color.grey;
        }
    }
}
