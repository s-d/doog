using UnityEngine;
using System.Collections;

public class Serrels : MonoBehaviour {

    public float speed;

    public Sprite scary;

    private bool spawn = true;
    private bool end = false;

    Vector3 translation;

    // Use this for initialization
    void Start ()
    {
        translation = new Vector3(0.0f, 0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (end)
            return;

        translation = new Vector3(0.0f, 0.0f, -1.0f);

        // float down
        if (spawn)
            translation = new Vector3(0.0f, -1.0f, 0.0f);

        translation *= speed * Time.deltaTime;
        this.gameObject.transform.Translate(translation);

        if (this.gameObject.transform.localPosition.y <= 2.0f)
        {
            spawn = false;
        }

        if (this.gameObject.transform.localPosition.z <= 5.0f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = scary;
        }

        if (this.gameObject.transform.localPosition.z <= 0.9)
        {
            end = true;

            // play screech
            Application.Quit();
        }

    }
}
