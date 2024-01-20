using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Solitaire solitaire;
    private User_Input user_Input;


    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = Solitaire.GenerateDeck();
        solitaire = FindObjectOfType<Solitaire>();
        user_Input = FindObjectOfType<User_Input>();

        int i = 0;
        foreach (string card in deck)
        {
            if (this.name == card)
            {
                cardFace = solitaire.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;

        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }

        if (user_Input.slot1)
        {

            if (name == user_Input.slot1.name)
            {
                spriteRenderer.color = Color.green;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }

        if (user_Input.updating)
        {
            if (solitaire.top.Contains(name))
            {
                spriteRenderer.color = Color.grey;
            }
        }


    }
}
