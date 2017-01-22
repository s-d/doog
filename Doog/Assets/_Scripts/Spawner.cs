using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    private List<Texture2D> _heads = new List<Texture2D>();

    private List<RuntimeAnimatorController> _bodyAnims = new List<RuntimeAnimatorController>();
    private List<RuntimeAnimatorController> _legAnims = new List<RuntimeAnimatorController>();


    private Texture2D samHead;

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
            enemy.GetComponent<EnemyController>().SetBody(GetRandomBodyAnim());
            enemy.GetComponent<EnemyController>().SetLegs(GetRandomLegsAnim());
            enemy.GetComponent<EnemyController>().SetHead(GetRandomHeadTexture());
            // set look of enemy
            enemy.GetComponent<EnemyController>().SetLook();
        }
	}

    RuntimeAnimatorController GetRandomBodyAnim()
    {
        RuntimeAnimatorController body;
        int rng = Random.Range(0, _bodyAnims.Count);
        body = _bodyAnims[rng];
        return body;
    }

    RuntimeAnimatorController GetRandomLegsAnim()
    {
        RuntimeAnimatorController legs;
        int rng = Random.Range(0, _legAnims.Count);
        legs = _legAnims[rng];
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
        extractAnimation(resources, _bodyAnims);

        // Load Legs Sets
        resources = Resources.LoadAll("Sprites/Legs");
        extractAnimation(resources, _legAnims);

        resources = Resources.LoadAll("Sprites/Head");
        FindHeads(resources);
        Debug.Log("load");
    }

    void extractAnimation(Object[] resources, List<RuntimeAnimatorController> anims)
    {
        // TODO, move into findParts
        for (int i = 0; i < resources.Length; ++i)
        {
            if (resources[i] is RuntimeAnimatorController)
            {
                bool existsAlready = false;
                foreach (RuntimeAnimatorController tex in anims)
                {
                    if (tex.name == resources[i].name)
                    {
                        existsAlready = true;
                    }
                }

                if (!existsAlready)
                {
                    anims.Add(resources[i] as RuntimeAnimatorController);
                }
            }
        }
    }

    void FindHeads(Object[] resources)
    {
        // TODO, move into findParts
        for (int i = 0; i < resources.Length; ++i)
        {
            if (resources[i] is Texture2D)
            {
                if (resources[i].name != "sam")
                    _heads.Add(resources[i] as Texture2D);
                else
                    samHead = resources[i] as Texture2D;

            }

        }
    }
}





