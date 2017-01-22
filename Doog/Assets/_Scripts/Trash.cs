using UnityEngine;
using System.Collections;

public class Trash : MonoBehaviour {


    public float speed;
    private Vector3 init;

    public GameLogic gl;

	// Use this for initialization
	void Start ()
    {
        init = gameObject.transform.position;
	}

    // Update is called once per frame


    bool doubleTapD = false;
    float _doubleTapTimeD;

    // Update is called once per frame
    void Update()
    {
        Vector3 translation = new Vector3(0.0f, 0.0f, 0.0f);


        #region doubleTapD

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time < _doubleTapTimeD + .3f)
            {
                doubleTapD = true;
                gl.damage();
                gl.damage();
                gl.damage();
                gl.damage();
                gl.damage();
                gl.damage();
            }
            _doubleTapTimeD = Time.time;
        }

        #endregion

        if (doubleTapD)
        {
            Debug.Log("DoubleTapD");
            translation = new Vector3(0.0f, 0.0f, -1.0f);
        }

        translation *= speed * Time.deltaTime;
        this.gameObject.transform.Translate(translation);

        if (this.gameObject.transform.position.z <= 0.0f)
        {

            doubleTapD = false;
            this.gameObject.transform.position = init;
        }
    }

    void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<EnemyController>().evil = false;
    }
}
