using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour
{

    private Texture2D windowTexture;
    private Color bottomCol;
    private Color topCol;
    private Color middleCol;

    private GameObject nightlight;
    private GameObject daylight;

    // Use this for initialization
    void Start()
    {
        nightlight = GameObject.FindGameObjectWithTag("Night");
        daylight = GameObject.FindGameObjectWithTag("Day");
        SetColourFromTime();
        
        windowTexture = new Texture2D(3, 1);
        windowTexture.SetPixel(1, 1, middleCol);
        windowTexture.SetPixel(2, 1, bottomCol);
        windowTexture.SetPixel(3, 1, topCol);
        windowTexture.filterMode = FilterMode.Bilinear;
        windowTexture.wrapMode = TextureWrapMode.Clamp;
        windowTexture.Apply();
    }

    void Update()
    {
        this.gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", windowTexture);
    }


    void SetColourFromTime()
    {
        int systemHour = System.DateTime.Now.Hour;

        bool day = false;

        if (systemHour > 18 || systemHour < 6)
        {
            // night
            topCol = GetColour(15, 29, 50);
            bottomCol = GetColour(177, 100, 164);
            middleCol = GetColour(54, 53, 100);
            day = false;           
        }
        else
        {
            // day
            topCol = GetColour(115, 226, 255);
            bottomCol = GetColour(195, 215, 220);
            middleCol = GetColour(154, 198, 255);
            day = true;
        }

        nightlight.SetActive(!day);
        daylight.SetActive(day);
    }

    Color GetColour(float R, float G, float B)
    {
        float multiplier = 255;
        return new Color(R / multiplier, G / multiplier, B / multiplier);
    }

}
