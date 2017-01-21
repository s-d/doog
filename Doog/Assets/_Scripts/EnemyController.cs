using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    public float speed;
    private Renderer[] sprites;

    //Tracks which texture is active -> _a or _s
    private int _activeTexture = 0;

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

        // destroy after off screen
        if (this.transform.localPosition.z <= -14.0f)
        {
            Destroy(this);
        }
	}

    public void SetLook()
    {
        sprites = this.GetComponentsInChildren<Renderer>();
        Shader tmp = Shader.Find("Sprites/Diffuse");

        foreach (Parts part in System.Enum.GetValues(typeof(Parts)))
        {
            sprites[(int)part].material.shader = Shader.Find("Sprites/Diffuse");

            if (part == Parts.Body)
            {
                sprites[(int)part].material.SetTexture("_MainTex", _body[_activeTexture]);
            } 
            else if (part == Parts.Head)
            {
                sprites[(int)part].material.SetTexture("_MainTex", _head);
            } 
            else if (part == Parts.Legs)
            {
                sprites[(int)part].material.SetTexture("_MainTex", _legs[_activeTexture]);
            }
            
            sprites[(int)part].material.color = Color.Lerp(sprites[(int)part].material.color, Color.black, 1);
        }        
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
