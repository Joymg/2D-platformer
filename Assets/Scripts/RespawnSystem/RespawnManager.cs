using System;
using System.Collections.Generic;
using UnityEngine;

namespace Joymg.Platformer2D.RespawnSystem
{
    public class RespawnManager : MonoBehaviour
    {
        private List<RespawnPoint> _respawnPoints = new();
        private RespawnPoint currentRespawnPoint;

        private void Awake()
        {
            foreach (Transform item in transform)
            {
                if (item.TryGetComponent(out RespawnPoint respawnPoint))
                {
                    respawnPoint.OnSpawnPointActivated.AddListener(() => UpdateRespawnPoint(respawnPoint));
                    _respawnPoints.Add(respawnPoint);
                }
            }

            currentRespawnPoint = _respawnPoints[0];
        }

        public void UpdateRespawnPoint(RespawnPoint newRespawnPoint)
        {
            currentRespawnPoint.DisableRespawnPoint();
            currentRespawnPoint = newRespawnPoint;
        }

        public void Respawn(GameObject objectToRespawn)
        {
            currentRespawnPoint.RespawnAgent();
            objectToRespawn.SetActive(true);
        }

        public void RespawnAt(RespawnPoint respawnPoint, GameObject agent)
        {
            respawnPoint.SetRespawnTarget(agent);
            Respawn(agent);
        }

        public void ResetAllSpawnPoints()
        {
            for (int i = 0; i < _respawnPoints.Count; i++)
            {
                _respawnPoints[i].ResetRespawnPoint();
            }

            currentRespawnPoint = _respawnPoints[0];
        }
    }
}