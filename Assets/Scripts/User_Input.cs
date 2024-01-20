using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class User_Input : MonoBehaviour
{
    public GameObject slot1;
    private Solitaire solitaire;
    public bool updating = false;
    string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    private start_click sc;
    private AudioSource mus;
    public bool vkl = true;
    private music f;


    // Start is called before the first frame update
    void Start()
    {
        slot1 = this.gameObject;
        solitaire = GetComponent<Solitaire>();
        sc = GetComponent<start_click>();
        mus = GetComponent<AudioSource>();
        
 

    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.collider.CompareTag("Deck"))
                {
                    if (solitaire.Rascladca == false)
                    {
                        Deck();
                    }
                }
                else if (hit.collider.CompareTag("Bottom"))
                {
                    Bottom();
                }

                else if (hit.collider.CompareTag("Music"))
                {
                    print("ms");
                    Music();
                }
                else if (hit.collider.CompareTag("Card"))
                {
                    Card(hit.collider.gameObject);
                }
                else if (solitaire.positions[hit.collider.name] != null)
                {
                    print(hit.collider.name);
                    print(solitaire.positions[hit.collider.name]);
                    Card(GameObject.Find(solitaire.positions[hit.collider.name][0] + values[int.Parse(solitaire.positions[hit.collider.name].Substring(1, solitaire.positions[hit.collider.name].Length - 1)) - 1]));
                }
                else if (hit.collider.CompareTag("empty") && solitaire.positions[hit.collider.name] == null)
                {
                   
                    empty(hit.collider.gameObject);
                }


            }
        }
    }

    void Deck()
    {
        print("deck");
        solitaire.Reset = true;
    }

    void Card(GameObject selected)
    {
        print("card");
        if (solitaire.top.Contains(selected.name) == false)
        {
            if (slot1 = this.gameObject)
            {
                slot1 = selected;
            }
        }


    }

    void Music()
    {
        f = GetComponent<music>();
        print(f);
        if (f.hur == true)
        {
            f.hur = false;

        }
        else
        {
            f.hur = true;
        }
    }

    void empty(GameObject selected)
    {
        print(Stackable(selected));
        print(solitaire.positions[selected.name]);
        if (Stackable(selected))
        {
            Stack(selected);
           
        }
    }

    void Bottom()
    {
        print("bottom");
        start_click.instance.startAm = true;
        start_click.instance.scen = 0;
    }

    bool Stackable(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();

        if (s1 != null && solitaire.positions[selected.name] == null)
        {
            string z = selected.name[0].ToString() + " ";
            string u = (int.Parse(selected.name.Split(" ")[1]) - 1).ToString();
            
            string l = z + u;
            if (solitaire.positions.ContainsKey(l))
            {
                print(solitaire.positions[l]);
                print(solitaire.positions[l][0].ToString() + values[s1.value - 2]);
                if (solitaire.positions[l] == (s1.suit + (s1.value - 1).ToString()))
                {
                    if (solitaire.top.Contains(solitaire.positions[l][0].ToString() + values[s1.value - 2]))
                    {
                        solitaire.tops[int.Parse(selected.name.Split(" ")[0])].Add(s1.suit + s1.value);
                        solitaire.top.Add(slot1.name);
                        print(solitaire.top.Last<string>());
                        updating = true;
                        int a = 1;
                        int k = 0;

                        if (s1.value < 14)
                        {
                            while ((solitaire.positions[selected.name.Split(" ")[0] + " " + (int.Parse(selected.name.Split(" ")[1]) + a).ToString()] == (s1.suit + (s1.value + 1 + k).ToString())) && (s1.value + k < 14))
                            {
                                solitaire.tops[int.Parse(selected.name.Split(" ")[0])].Add(s1.suit + (s1.value + k).ToString());
                                solitaire.top.Add(s1.suit + values[s1.value + k]);
                                print(solitaire.tops[int.Parse(selected.name.Split(" ")[0])].Last<string>());
                                print(solitaire.top.Last<string>());
                                updating = true;
                                StackForCringe(GameObject.Find(selected.name.Split(" ")[0] + " " + (int.Parse(selected.name.Split(" ")[1]) + k + 1).ToString()), GameObject.Find(s1.suit + values[s1.value + k]));
                                a++;
                                k++;

                            }
                        }
                    }
                    return true;
                }
            }

            else if (s1.value == 1 && selected.name[2].ToString() == "0".ToString())
            {
                solitaire.tops[int.Parse(selected.name.Split(" ")[0])].Add((s1.suit + s1.value));
                solitaire.top.Add(slot1.name);
                updating = true;
                int a = 1;
                int k = 0;
                while ((solitaire.positions[selected.name.Split(" ")[0] + " " + (int.Parse(selected.name.Split(" ")[1]) + a).ToString()] == (s1.suit + (s1.value + 1 + k).ToString())) && (s1.value + k <= 13))
                {
                    solitaire.tops[int.Parse(selected.name.Split(" ")[0])].Add(s1.suit + (s1.value + k).ToString());
                    solitaire.top.Add(s1.suit + values[s1.value + k]);
                    print(solitaire.top.Last<string>());
                    updating = true;
                    StackForCringe(GameObject.Find(selected.name.Split(" ")[0] + " " + (int.Parse(selected.name.Split(" ")[1]) + k + 1).ToString()), GameObject.Find(s1.suit + values[s1.value + k]));
                    a++;
                    k++;
                }
                    return true;
            }

            return false;


        }

        return false;
        
    }

    void Stack(GameObject selected)
    {

        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        string k = PrintDict(solitaire.positions, (s1.suit + (s1.value).ToString()));
        solitaire.positions[k] = null;
        slot1.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y, selected.transform.position.z);
        slot1.transform.parent = selected.transform;
        mus.Play();
        solitaire.positions[selected.name] = (s1.suit + (s1.value).ToString());
        if (start_click.instance.tryes == 0)
        {
            print(k);
            int f = 1;
            while (solitaire.positions[k.Split()[0] + " " + (int.Parse(k.Split()[1]) - f).ToString()] == null)
            {
                f++;
            }
            print(f);
            string p = k.Split()[0] + " " + (int.Parse(k.Split()[1])).ToString();
            string j = solitaire.positions[k.Split()[0] + " " + (int.Parse(k.Split()[1]) - f).ToString()];
            print(j.Substring(1));

            if (s1.value == 13 && (int.Parse(k.Split()[1]) + 1) <= 13)
            {
                int o = 1;
                while (solitaire.positions[k.Split()[0] + " " + (int.Parse(k.Split()[1]) + o).ToString()] == null && (int.Parse(k.Split()[1]) + o < 13))
                {
                    solitaire.tresh--;
                    o++;
                }
                if (int.Parse(k.Split()[1]) + o == 13)
                {
                    if (solitaire.positions[k.Split()[0] + " " + (int.Parse(k.Split()[1]) + o).ToString()] == null)
                    {
                        solitaire.tresh--;
                    }
                }

            }

            if (j.Substring(1) == "13")
            {
                int g = 0;
                print(solitaire.positions[p.Split()[0] + " " + (int.Parse(p.Split()[1]) + g).ToString()]);

                while (solitaire.positions[p.Split()[0] + " " + (int.Parse(p.Split()[1]) + g).ToString()] == null && ((int.Parse(p.Split()[1]) + g) < 13))
                {
                    print(p.Split()[0] + " " + (int.Parse(p.Split()[1]) + g).ToString());
                    solitaire.tresh++;
                    g++;
                }
                if ((int.Parse(p.Split()[1]) + g) == 13)
                {
                    if (solitaire.positions[p.Split()[0] + " " + (int.Parse(p.Split()[1]) + g).ToString()] == null)
                    {
                        solitaire.tresh++;
                    }
                }



            }

            if (s1.value == 13 && int.Parse(selected.name.Split()[1]) < 13)
            {
                int q = 1;
                while (solitaire.positions[selected.name.Split()[0] + " " + (int.Parse(selected.name.Split()[1]) + q).ToString()] == null && (int.Parse(selected.name.Split()[1]) + q) < 13)
                {
                    print(selected.name.Split()[0] + " " + (int.Parse(selected.name.Split()[1]) + q).ToString());
                    solitaire.tresh++;
                    q++;
                }
                if ((int.Parse(selected.name.Split()[1]) + q) == 13)
                {
                    if (solitaire.positions[selected.name.Split()[0] + " " + (int.Parse(selected.name.Split()[1]) + q).ToString()] == null)
                    {
                        solitaire.tresh++;
                    }
                }

            }



        }
        print(this.gameObject.name);
        

        slot1 = this.gameObject;



    }

    void StackForCringe(GameObject selected, GameObject selected1)
    {

        Selectable s1 = selected1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        selected1.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y, selected.transform.position.z);
        selected1.transform.parent = selected.transform;


    }

    private string PrintDict(Dictionary<string, string> dict, string u)
    {
        List<string> keys = new List<string>(dict.Keys);

        foreach (string key in keys)
        {
            if (dict[key] == u)
            {
                return key;
            }
            
        }
        return "0 0";
    }


}
