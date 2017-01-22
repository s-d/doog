using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject logo_doom;
    public GameObject logo_doog;
    public Image lightning;
    public float fadeTime = 1f;
    Color colorToFadeTo;
    public AudioSource audSource;
    public GameObject space;
    private bool once = false;
    
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
            if (!once)
            {
                once = true;
                lightningStrike();
            }
        }

        if (lightning.canvasRenderer.GetColor().a < 0.3)
            space.SetActive(true);

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("FirstScene");
        }
    }


    private void lightningStrike()
    {
        audSource.PlayOneShot(audSource.clip);
        logo_doom.SetActive(false);
        logo_doog.SetActive(true);
        lightning.enabled = true;
        colorToFadeTo = new Color(1, 1, 1, 0);
        lightning.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
    }
}
