using System.Collections;
using System.Collections.Generic;
using Joymg.Platformer2D.WeaponSystem;
using UnityEngine;
using UnityEngine.Events;

public class DummyBox : MonoBehaviour, IHittable
{

    public UnityEvent OnHit;
    public void GetHit(GameObject agentGameObject, int damage)
    {
        OnHit?.Invoke();
        DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
