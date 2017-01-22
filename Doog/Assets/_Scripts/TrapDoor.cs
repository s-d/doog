using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets._Scripts;

public class TrapDoor : MonoBehaviour
{

    public GameLogic _gameLogic;
    // Tracks how many times the user has pressed the space bar
    // Determines the score of the space bar
    public GameObject _healthbar;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _healthbar.GetComponent<Slider>().value++;
        } else
        {
            _healthbar.GetComponent<Slider>().value--;
        }
         
        // Increase count aslong as the space is held down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 currentPosition = transform.localPosition;
            transform.Translate(new Vector3(0, -0.78f, 0.79f));
            transform.Rotate(new Vector3(70.0f, 0, 0));
        }

         if (Input.GetKeyUp(KeyCode.Space))
         {
            transform.Rotate(new Vector3(-70.0f, 0, 0));
            transform.Translate(new Vector3(0, 0.78f, -0.785f));
        }

        if (_healthbar.GetComponent<Slider>().value >= 95)
        {
            _gameLogic.damage();
        }

    }

    
}
