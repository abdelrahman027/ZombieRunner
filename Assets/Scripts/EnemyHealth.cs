using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HitPoints=100f;

    public void PlayerHit(float Damage)
    {
        BroadcastMessage("onDamageTaken");
        HitPoints-=Damage;
        Debug.Log($"enemy Health is {HitPoints}");
        if (HitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
