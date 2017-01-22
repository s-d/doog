using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour
{
    // Tracks how many times the user has pressed the space bar
    // Determines the score of the space bar
    private int _space_used = 0;

    // 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 currentPosition = this.transform.localPosition;
            transform.Translate(new Vector3(0, -0.78f, 0.79f));
            transform.Rotate(new Vector3(70.0f, 0, 0));
            _space_used++;
        }

         if (Input.GetKeyUp(KeyCode.Space))
         {
            transform.Rotate(new Vector3(-70.0f, 0, 0));
            transform.Translate(new Vector3(0, 0.78f, -0.785f));
        }
    }
}
