using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float PlayerHitPoints =100f;
    DeathHandler deathHandler;
    // Start is called before the first frame update
    void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyHit(float Damage)
    {
        PlayerHitPoints -= Damage;
        if (PlayerHitPoints <=0)
        {
            deathHandler.HandleDeath();
        }
    }
}
