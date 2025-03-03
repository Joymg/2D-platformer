using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


namespace Joymg.Platformer2D.RespawnSystem
{
    public class RespawnPoint : MonoBehaviour
    {
        [SerializeField]private GameObject respawnTarget;
        [field: SerializeField] public UnityEvent OnSpawnPointActivated { get; set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            
            respawnTarget = other.gameObject;
            OnSpawnPointActivated?.Invoke();
            DisableRespawnPoint();
        }

        public void RespawnAgent()
        {
            respawnTarget.transform.position = transform.position;
        }

        public void SetRespawnTarget(GameObject agent)
        {
            respawnTarget = agent;
            DisableRespawnPoint();
        }

        public void DisableRespawnPoint()
        {
            GetComponent<Collider2D>().enabled = false;
        }

        public void ResetRespawnPoint()
        {
            respawnTarget = null;
            GetComponent<Collider2D>().enabled = true;
        }
    }
}