using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public GameObject logo_doom;
    public GameObject logo_doog;
    public Image lightning;
    public float fadeTime = 5f;
    Color colorToFadeTo;


    private void Start()
    {
        lightning.enabled = false;
        logo_doom.transform.position.y.Equals(-250.0f);
        logo_doog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (logo_doom.GetComponent<RectTransform>().localPosition.y < 0.0f)
        {
            logo_doom.transform.Translate(new Vector3(0.0f, 1.0f, 0.0f));
        }
        else
        {
            lightningStrike();
        }
    }


    private void lightningStrike()
    {

        logo_doom.SetActive(false);
        logo_doog.SetActive(true);
        lightning.enabled = true;
        colorToFadeTo = new Color(1, 1, 1, 0);
        lightning.CrossFadeColor(colorToFadeTo, fadeTime, true, true);

    }
}
