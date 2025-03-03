using System;
using UnityEngine;

namespace Joymg.Platformer2D.RespawnSystem
{
    public class RespawnHelper : MonoBehaviour
    {
        private RespawnManager manager;

        private void Awake()
        {
            manager = FindObjectOfType<RespawnManager>();
        }

        public void RespawnAgent()
        {
            manager.Respawn(gameObject);
        }

        public void ResetAgent()
        {
            manager.ResetAllSpawnPoints();
            manager.Respawn(gameObject);
        }
    }
}