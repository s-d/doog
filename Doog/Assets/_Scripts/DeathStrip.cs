using UnityEngine;
using System.Collections;

public class DeathStrip : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        Destroy(other.gameObject);
    }


}
