﻿using UnityEngine;
using UnityEditor;
using UnityEngine.Windows.Speech;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    public float speed;
    private Renderer[] sprites;

    //Tracks which texture is active -> _a or _s
    private int _activeTexture;

    private List<Texture2D> _body;
    private List<Texture2D> _legs;
    private Texture2D _head;

    private enum Parts { Body, Head, Legs }

    void Start()
    {
        PrefabUtility.DisconnectPrefabInstance(this);

        // randomly generate 
        Vector3 initialPos = this.transform.localPosition;
        initialPos.x = Random.Range(-2.5f, 2.5f);
        this.transform.localPosition = initialPos;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 translation = new Vector3(0.0f, 0.0f, -1.0f);

        translation *= speed * Time.deltaTime;

        this.transform.Translate(translation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Flip Texture
            _activeTexture = 1 - _activeTexture;
            sprites[(int)Parts.Body].material.SetTexture("_MainTex", _body[_activeTexture]);
            sprites[(int)Parts.Legs].material.SetTexture("_MainTex", _legs[_activeTexture]);
        }


        // destroy after off screen
        if (this.transform.localPosition.z <= -14.0f)
        {
            Destroy(this);
        }

	}

    public void SetLook()
    {
        sprites = this.GetComponentsInChildren<Renderer>();
        _activeTexture = 0;
        sprites[(int)Parts.Body].material.shader = Shader.Find("Sprites/Diffuse");
        sprites[(int)Parts.Body].material.SetTexture("_MainTex", _body[_activeTexture]);

        sprites[(int)Parts.Head].material.shader = Shader.Find("Sprites/Diffuse");
        sprites[(int)Parts.Head].material.SetTexture("_MainTex", _head);

        sprites[(int)Parts.Legs].material.shader = Shader.Find("Sprites/Diffuse");
        sprites[(int)Parts.Legs].material.SetTexture("_MainTex", _legs[_activeTexture]);
    }

    public void SetBody(List<Texture2D> body) 
    {
        _body = body;
    }

    public void SetLegs(List<Texture2D> legs)
    {
        _legs = legs;
    }

    public void SetHead(Texture2D head) {
        _head = head;
    }
}
