using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Fader : MonoBehaviour
{
    private const string FADER_PATH = "Fader";

    [SerializeField] private Animator animator;

    public static Fader _instance;
    public static Fader instance
    {
        get
        {
            if (_instance == null)
            {
                var prefab = Resources.Load<Fader>(FADER_PATH);
                _instance = Instantiate(prefab);
                DontDestroyOnLoad(_instance.gameObject);

            }
            return _instance;
        }
    }

    public bool isFading { get; private set; }

    private UnityAction _fadedInCallback;
    private UnityAction _fadedOutCallback;

    public void FadeIn(UnityAction fadedInCallback)
    {
        if (isFading)
        {
            return;
        }

        isFading = true;
        _fadedInCallback = fadedInCallback;
        animator.SetBool("faded", true);
    }

    public void FadeOut(UnityAction fadedOutCallback)
    {
        if (isFading)
        {
            return;
        }

        isFading = true;
        _fadedOutCallback = fadedOutCallback;
        animator.SetBool("faded", false);
    }

    private void Handle_FadeInAnimationOver()
    {
        _fadedInCallback?.Invoke();
        _fadedInCallback = null;
        isFading = false;
    }

    private void Handle_FadeOutAnimationOver()
    {
        _fadedOutCallback?.Invoke();
        _fadedOutCallback = null;
        isFading = false;
    }

}
