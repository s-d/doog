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
        //Debug.Log("Animation strip triggered" + other.name);
        Renderer[] sprites = other.gameObject.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < sprites.Length; ++i)
        {
            sprites[i].material.color = Color.Lerp(sprites[i].material.color, Color.white, (float)0.15);
        }
    }
}
