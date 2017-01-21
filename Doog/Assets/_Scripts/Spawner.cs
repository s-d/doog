using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject prefab;


    private List<List<Texture2D>> _bodies = new List<List<Texture2D>>();
    private List<List<Texture2D>> _legs = new List<List<Texture2D>>();
    private List<Texture2D> _heads = new List<Texture2D>();

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
            enemy.GetComponent<EnemyController>().SetBody(GetRandomBodyTextures());
            enemy.GetComponent<EnemyController>().SetLegs(GetRandomLegsTextures());
            enemy.GetComponent<EnemyController>().SetHead(GetRandomHeadTexture());
            // set look of enemy
            enemy.GetComponent<EnemyController>().SetLook();
        }
	}


    // TODO, clean up
    List<Texture2D> GetRandomBodyTextures()
    {
        List<Texture2D> body;
        int rng = Random.Range(0, _bodies.Count);
        body = _bodies[rng];
        return body;
    }

    List<Texture2D> GetRandomLegsTextures()
    {
        List<Texture2D> legs;
        int rng = Random.Range(0, _legs.Count);
        legs = _legs[rng];
        return legs;
    }

    Texture2D GetRandomHeadTexture()
    {
        Texture2D head;
        int rng = Random.Range(0, _heads.Count);
        head = _heads[rng];
        return head;
    }


    void LoadTextures()
    {

        // Load Body Sets
        Object[] resources = Resources.LoadAll("Sprites/Body");
        findParts(resources, _bodies);

        // Load Legs Sets
        resources = Resources.LoadAll("Sprites/Legs");
        findParts(resources, _legs);

        resources = Resources.LoadAll("Sprites/Head");

        // TODO, move into findParts
        for (int i = 0; i < resources.Length; ++i)
        {
            if (resources[i] is Texture2D)
            {
                bool existsAlready = false;
                foreach (Texture2D tex in _heads)
                {
                    if (tex.name == resources[i].name)
                    {
                        existsAlready = true;
                    }
                }

                if (!existsAlready)
                {
                    _heads.Add(resources[i] as Texture2D);
                }
            }
        }
        Debug.Log("load");
    }

    void findParts(Object[] resources, List<List<Texture2D>> storage)
    {
        // Ohh God it's dirty
        for (int i = 0; i < resources.Length; ++i)
        {
            if (resources[i] is Texture2D)
            {
                bool existsAlready = false;
                // If the bodies list dosen't contain that part already
                foreach (List<Texture2D> checkParts in storage)
                {
                    foreach (Texture2D body in checkParts)
                    {
                        if (body.name == resources[i].name)
                        {
                            existsAlready = true;
                        }
                    }
                }

                // Not already part of a body list
                if (!existsAlready)
                {
                    List<Texture2D> parts = new List<Texture2D>();
                    parts.Add(resources[i] as Texture2D);
                    string currentTexture = resources[i].name;
                    // Look for other animations of that body, my eyes are bleeding
                    for (int j = 0; j < resources.Length; ++j)
                    {
                        // Next texture is not equal to the current one but is of the  same kind
                        if (resources[j] is Texture2D && resources[j].name != currentTexture && resources[j].name.Substring(0, 7) == currentTexture.Substring(0, 7))
                        {
                            parts.Add(resources[j] as Texture2D);
                        }
                    }
                    storage.Add(parts);
                }
            }
        }
    } 

}





