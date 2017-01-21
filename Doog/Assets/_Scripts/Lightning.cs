using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lightning : MonoBehaviour
{

	// Use this for initialization
    public Image myPanel;
    public float fadeTime = 10f;
    Color colorToFadeTo;


    void Start()
    {
        colorToFadeTo = new Color(1f, 1f, 1f, 0f);
        myPanel.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
