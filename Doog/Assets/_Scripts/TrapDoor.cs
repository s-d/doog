using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Vector3 currentPosition = this.transform.localPosition;
            this.transform.Translate(new Vector3(0, -0.564f, 0.488f));
            this.transform.Rotate(new Vector3(70.0f, 0, 0));
            Debug.Log("Transforming");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {


        }
    }
}
