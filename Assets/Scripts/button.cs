using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    private bool isLoading;
    public static button instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start_click.instance.startAm == true)
        {
            print(1);
            LoadScene(start_click.instance.scen);
            
        }
        start_click.instance.startAm = false;
    }

    public void LoadScene(int number)
    {
        StartCoroutine(LoadSceneRoutine(number));
        

    }

    private IEnumerator LoadSceneRoutine(int number)
    {
        isLoading = true;

        var waitFading = true;
        Fader.instance.FadeIn(() => waitFading = false);
        print(5);


        var async = SceneManager.LoadSceneAsync(number);
        async.allowSceneActivation = false;
        print(2);
        while (async.progress < 0.9f)
        {
            yield return null;
        }

        async.allowSceneActivation = true;
        print(3);
        waitFading = true;
        print(2);
        Fader.instance.FadeOut(() => waitFading = false);

        while (waitFading)
        {
            yield return null;
        }

        isLoading = false;
    }
}
