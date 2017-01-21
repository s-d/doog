using UnityEngine;
using UnityEditor;
using UnityEngine.Windows.Speech;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;
    private Renderer[] sprites;

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

        Debug.Log("whee " + this.transform.localPosition.x);

        //TODO
        // destroy after off screen
        if (this.transform.localPosition.z <= -14.0f)
        {
            Destroy(this);
        }

	}

    public void SetLook(Texture2D[] textures)
    {
        sprites = this.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < textures.Length; ++i)
        {
            sprites[i].material.shader = Shader.Find("Sprites/Diffuse");
            sprites[i].material.SetTexture("_MainTex", textures[i]);
        }
    }
}
