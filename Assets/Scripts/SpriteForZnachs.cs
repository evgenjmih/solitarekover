using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteForZnachs : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "Square" && start_click.instance.a == 1)
        {
            spriteRenderer.color = Color.grey;
        }
        else if (this.name == "Square (1)" && start_click.instance.a == 2)
        {
            spriteRenderer.color = Color.grey;
        }
        else if (this.name == "Square (2)" && start_click.instance.a == 3)
        {
            spriteRenderer.color = Color.grey;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
