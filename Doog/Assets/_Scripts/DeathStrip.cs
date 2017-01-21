using UnityEngine;
using System.Collections;

public class DeathStrip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("in here " + other.name);

        if (Input.GetKey("space"))
            Destroy(other.gameObject);
    }
}
