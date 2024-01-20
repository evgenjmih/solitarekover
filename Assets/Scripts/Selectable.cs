using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Selectable : MonoBehaviour
{
    public bool top = false;
    public string suit;
    public int value;
    public int row;
    public bool faceUp = false;
    public bool inDeckPile = false;

    private string valueString;

    string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    // Start is called before the first frame update
    void Start()
    {

        if (CompareTag("Card"))
        {
            suit = transform.name[0].ToString();

            for (int i = 1; i < transform.name.Length; i++)
            {
                char c = transform.name[i];
                valueString = valueString + c.ToString();
            }

            value = Array.IndexOf(values, valueString) + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
