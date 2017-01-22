using UnityEngine;
using UnityEngine.UI;
using Assets._Scripts;

public class GameLogic : MonoBehaviour {

    public HealthBar _healthbar;

    public GameObject sam;

    private GameObject serrels;

	// Update is called once per frame
	void Update () {
        // No more lives, launch the Serrels
        // You lose
        if (_healthbar.GetComponent<Slider>().value == 0)
        {
            Spawner.dead = true;
        }

        if (!serrels && Spawner.dead)
        {
            serrels = Instantiate(sam);
        }
	}

    public void damage()
    {
        if (_healthbar.GetComponent<Slider>().value != 0)
            _healthbar.GetComponent<Slider>().value--;
    }
}
