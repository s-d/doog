using UnityEngine;
using System.Linq;
using System.Text;

namespace Assets._Scripts
{
    class FinalAnimationStrip : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            //Debug.Log("Animation strip triggered" + other.name);
            Renderer[] sprites = other.gameObject.GetComponentsInChildren<Renderer>();
            float t = (float)0.0;
            for (int i = 0; i < sprites.Length; ++i)
            {
                sprites[i].material.color = Color.Lerp(sprites[i].material.color, Color.white, (float)1.0);
            }
        }
    }
}
