using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject prefab;

    private List<Texture2D> bodies = new List<Texture2D>();
    private List<Texture2D> heads = new List<Texture2D>();
    private List<Texture2D> legs = new List<Texture2D>();

	void Awake ()
    {
        LoadTextures();
    }

	void Update ()
    {
	
        if (Input.GetMouseButtonDown(0))
        {
            GameObject enemy = Instantiate(prefab) as GameObject;

            enemy.transform.SetParent(this.transform);

            // set look of enemy
            enemy.GetComponent<EnemyController>().SetLook(GetRandomTextures());
        }
	}

    Texture2D[] GetRandomTextures()
    {

        Texture2D[] look = new Texture2D[3];

        int rng = Random.Range(0, bodies.Count);

        look[0] = bodies[rng];

        rng = Random.Range(0, heads.Count);

        look[1] = heads[rng];

        rng = Random.Range(0, legs.Count);

        look[2] = legs[rng];

        return look;
    }

    void LoadTextures()
    {
        int count = 1;

        var tex = Resources.Load("Sprites\\Body\\body_0" + count + "_a") as Texture2D;

        while (tex)
        {
            tex.filterMode = FilterMode.Point;
            bodies.Add(tex);
            count++;
            tex = Resources.Load("Sprites\\Body\\body_0" + count + "_a") as Texture2D;

            Debug.Log(tex);
        }

        count = 1;
        tex = null;
        tex = Resources.Load("Sprites\\Head\\head_0" + count) as Texture2D;

        while (tex)
        {
            tex.filterMode = FilterMode.Point;
            heads.Add(tex);
            count++;

            tex = Resources.Load("Sprites\\Head\\head_0" + count) as Texture2D;
        }


        count = 1;
        tex = null;
        tex = Resources.Load("Sprites\\Legs\\legs_0" + count + "_a") as Texture2D;

        while (tex)
        {
            tex.filterMode = FilterMode.Point;
            legs.Add(tex);
            count++;
            tex = Resources.Load("Sprites\\Legs\\legs_0" + count + "_a") as Texture2D;
        }

        Debug.Log("load");
    }
}

