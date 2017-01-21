using UnityEngine;
using System.Collections;

public class AnimationStrip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Animation strip triggered" + other.name);
    }
}
