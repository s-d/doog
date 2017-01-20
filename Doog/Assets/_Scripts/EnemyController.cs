using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start ()
    { 
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 translation = new Vector3(0.0f, 0.0f, -1.0f);

        translation *= speed * Time.deltaTime;

        this.transform.Translate(translation);

	}
}
