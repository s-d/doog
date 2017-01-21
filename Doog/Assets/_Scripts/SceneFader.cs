using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    // fade speed
    public float fadeSpeed = 1.5f;

    private Image screenQuad;

    private bool transitioning = false;

    public Image logo;

    void Awake()
    {
        // initialise rectangle 
        screenQuad = GetComponent<Image>();

        // scale to screensize
        screenQuad.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        
        if (logo.GetComponent<RectTransform>().localPosition.y > -1 )
        {
            if (screenQuad.color.a >= 0.9f)
            {
                transitioning = false;
                return;
            }

            // fade to white
            Fade(Color.white);
        }
        else
        {
            Fade(Color.clear);
        }
    }

    public void Flash()
    {
        transitioning = true;
        Debug.Log("FLASHH!!!");
    }

    private void Fade(Color fadingTo)
    {
        // lerp between colours of screen quad
        screenQuad.color = Color.Lerp(screenQuad.color, fadingTo, fadeSpeed * Time.deltaTime);
    }
} 