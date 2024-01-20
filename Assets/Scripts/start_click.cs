using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class start_click : MonoBehaviour
{
    public static start_click instance;

    public Color back;
    public int tryes;
    public int a;
    private AudioSource mus;
    public bool startAm = false;

    public int scen = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        mus = GetComponent<AudioSource>();
        tryes = 99999999;
        back = GameObject.Find("Circle").GetComponent<SpriteRenderer>().color;
        a = 1;
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
                if (hit.collider.CompareTag("color1"))
                {
                    mus.Play();
                    tryes = 99999999;
                    a = 1;
                    back = GameObject.Find("Circle").GetComponent<SpriteRenderer>().color;
                    print("color1");
                }
                else if (hit.collider.CompareTag("color2"))
                {
                    mus.Play();
                    tryes = 5;
                    a = 2;
                    back = GameObject.Find("Circle (1)").GetComponent<SpriteRenderer>().color;
                    print("color2");
                }
                else if (hit.collider.CompareTag("color3"))
                {
                    mus.Play();
                    tryes = 3;
                    a = 3;
                    back = GameObject.Find("Circle (2)").GetComponent<SpriteRenderer>().color;
                    print("color3");
                }
                else if (hit.collider.CompareTag("start"))
                {
                    print("perehod");
                    startAm = true;
                    scen = 1;
                }


            }
        }
    }
}
