using System.Collections.Generic;
using UnityEngine;

namespace Joymg.Platformer2D
{
    public class ParallaxEffect : MonoBehaviour
    {
        public Camera mainCamera;
        [SerializeField] private List<ParallaxLayer> _layers = new(); 

        private void Awake()
        {
            mainCamera ??= Camera.main;
        }

        private void FixedUpdate()
        {
            foreach (ParallaxLayer layer in _layers)
            {
                layer.tilemap.transform.position =
                    new Vector2(mainCamera.transform.position.x * layer.movementSpeed, 0);
            }
        }
    }

    [System.Serializable]
    public struct ParallaxLayer
    {
        public GameObject tilemap;
        [Range(0f, 1f)] public float movementSpeed;


    }
}