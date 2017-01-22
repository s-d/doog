using UnityEngine;
using UnityEngine.UI;
using Assets._Scripts;

public class GameLogic : MonoBehaviour {

    public HealthBar _healthbar;

	// Update is called once per frame
	void Update () {
        // No more lives, launch the Serrels
        // You lose
        if (_healthbar.GetComponent<Slider>().value == 0)
        {
            
        }
	}

    public void damage()
    {
        _healthbar.GetComponent<Slider>().value--;
    }
}
