using UnityEngine;
//using UnityEditor;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    public float speed;
    private Renderer[] sprites;

    private Animator[] spriteAnim;

    //Tracks which texture is active -> _a or _s
    private int _activeTexture = 0;

    private RuntimeAnimatorController _body;
    private RuntimeAnimatorController _legs;
    private Texture2D _head;

    private enum Parts { Body, Head, Legs }

    void Start()
    {
      //  PrefabUtility.DisconnectPrefabInstance(this);

        // randomly generate 
        Vector3 initialPos = this.transform.localPosition;
        initialPos.x = Random.Range(-2.3f, 2.3f);
        transform.localPosition = initialPos;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 translation = new Vector3(0.0f, 0.0f, -1.0f);

        translation *= speed * Time.deltaTime;

        this.transform.Translate(translation);

        // destroy after off screen
        if (this.transform.localPosition.z <= -14.0f || transform.localPosition.y <= -15.0f)
        {
            Debug.Log("destroy" + this.name);
            Destroy(this.gameObject);
        }
	}

    public void SetLook()
    {
        sprites = this.GetComponentsInChildren<Renderer>();

        foreach (Parts part in System.Enum.GetValues(typeof(Parts)))
        {
            sprites[(int)part].material.shader = Shader.Find("Sprites/Diffuse");
            sprites[(int)part].material.color = Color.Lerp(sprites[(int)part].material.color, Color.black, 1);
        }        

        spriteAnim = this.GetComponentsInChildren<Animator>();
        spriteAnim[(int)Parts.Body].runtimeAnimatorController = _body;
        sprites[(int)Parts.Head].material.SetTexture("_MainTex", _head);
        spriteAnim[(int)Parts.Legs-1].runtimeAnimatorController = _legs;
    }

    public void SetBody(RuntimeAnimatorController body) 
    {
        _body = body;
    }

    public void SetLegs(RuntimeAnimatorController legs)
    {
        _legs = legs;
    }

    public void SetHead(Texture2D head) {
        _head = head;
    }
}
