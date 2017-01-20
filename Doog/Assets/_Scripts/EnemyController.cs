using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;
    private Renderer[] sprites;
   


	void Awake ()
    {
        sprites = this.GetComponentsInChildren<Renderer>();

       
        // shoddy code
        var tex = Resources.Load("Sprites\\Body\\body_01_a") as Texture2D;
        tex.filterMode = FilterMode.Point;
        sprites[0].material.shader = Shader.Find("Sprites/Diffuse");
        sprites[0].material.SetTexture("_MainTex", tex);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 translation = new Vector3(0.0f, 0.0f, -1.0f);

        translation *= speed * Time.deltaTime;

        this.transform.Translate(translation);

	}
}
