using Unity.Mathematics;
using UnityEngine;

namespace Joymg.Platformer2D.Commons
{
    public class InstantiateUtil : MonoBehaviour
    {
        public GameObject objectToInstantiate;

        public void DropLoot()
        {
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }

    }
}