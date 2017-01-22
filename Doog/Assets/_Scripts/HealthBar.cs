using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public int score = 0;

    public void increaseHealth()
    {
        score++;
    }

    public void decreaseHealth()
    {

        score--;
    }
}
