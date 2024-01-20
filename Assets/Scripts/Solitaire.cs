using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Solitaire : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public GameObject[] bottomPos;
    public GameObject[] topPos;

    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public List<string>[] bottoms;
    public List<string>[] tops;
    public List<string> top;

    private List<string> bottom0 = new List<string>();
    private List<string> bottom1 = new List<string>();
    private List<string> bottom2 = new List<string>();
    private List<string> bottom3 = new List<string>();

    private List<string> top0 = new List<string>();
    private List<string> top1 = new List<string>();
    private List<string> top2 = new List<string>();
    private List<string> top3 = new List<string>();

    public List<string> deck;
    public Dictionary<string, string> positions;
    public bool Reset = false;
    public int tresh = 0;

    public bool Rascladca = true;
    // Start is called before the first frame update
    void Start()
    {
        bottoms = new List<string>[] {bottom0, bottom1, bottom2, bottom3};
        tops = new List<string>[] { top0, top1, top2, top3 };
        positions = new Dictionary<string, string>();
        PlayCards();
        print(positions);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Reset && start_click.instance.tryes > 0)
        {

            
            start_click.instance.tryes--;
            for ( int i = 0; i < 4; i++ )
            {
                bottoms[i].Clear();
                if (tops[i].Count == 13 && start_click.instance.tryes == 0)
                {
                    tresh++;
                }
            }
            ResetScene();
            print("complete");
            PlayCards();

            
        }
        Reset = false;
        if (top.Count == 104)
        {
            Finish();
        }
        if (tresh == 4 && top.Count < 104)
        {
            Dead();
        }
    }

    public void PlayCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);

        SolitaireSort();

        StartCoroutine(SolitaireDeal());
    }

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
               newDeck.Add(s + v);

                
            }
        }
        return newDeck;
    }


    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    IEnumerator SolitaireDeal()
    {
        Rascladca = true;
        for (int i = 0; i < 4; i++)
        {
            print(tops[i].Count * 0.5);
            if (positions.ContainsKey(i.ToString() + " " + (tops[i].Count * 0.5).ToString()))
            {
                positions[i.ToString() + " " + (tops[i].Count * 0.5).ToString()] = null;
            }
            if (positions.ContainsKey(i.ToString() + " " + tops[i].Count.ToString()) == false)
            {
                positions.Add((i.ToString() + " " + tops[i].Count.ToString()), null);
            }
            
            float xOffset = 0f;
            foreach (string card in bottoms[i])
            {
                yield return new WaitForSeconds(0.01f);
                GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomPos[i].transform.position.x + xOffset, bottomPos[i].transform.position.y, bottomPos[i].transform.position.z), Quaternion.identity, bottomPos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Selectable>().row = i;
                newCard.GetComponent<Selectable>().faceUp = true;
                string h = i.ToString() + " " + (13 - bottoms[i].FindIndex(a => a.Contains(card))).ToString();

                string suit = card[0].ToString();
                string valueString = "";
                for (int r = 1; r < card.Length; r++)
                {
                    char c = card[r];
                    valueString = valueString + c.ToString();
                }

                string value = (Array.IndexOf(values, valueString) + 1).ToString();

                if (positions.ContainsKey(h) == false)
                {
                    positions.Add(h, (suit + value));
                }
                
                else 
                {
                    positions[h] = (suit + value);
                }
                xOffset = xOffset - 1.5f;
            }
        }
        Rascladca = false;
    }

    void SolitaireSort()
    {
        for (int i = 0; i < 4; i++)
        {
            print(tops[i].Count);
            for (int j = 0; j < 13 - (tops[i].Count)*0.5f; j++)
            {
                print(deck.Last<string>());
                if (top.Contains(deck.Last<string>()) == false)
                {
                    bottoms[i].Add(deck.Last<string>());
                    deck.RemoveAt(deck.Count - 1);

                }
                else 
                {
                    deck.RemoveAt(deck.Count - 1);
                    j--;
                }
                
            }
        }
    }

    void ResetScene()
    {
        UpdateSprite[] cards = FindObjectsOfType<UpdateSprite>();
        foreach (UpdateSprite card in cards)
        {
            if (top.Contains(card.name) == false && card.name != "Formica 7897 Spectrum Green full sheet")
            {
                Destroy(card.gameObject);
            }
        }
    }

    void Finish()
    {
        start_click.instance.startAm = true;
        start_click.instance.scen = 2;
    }

    void Dead()
    {
        start_click.instance.startAm = true;
        start_click.instance.scen = 3;
    }
}
