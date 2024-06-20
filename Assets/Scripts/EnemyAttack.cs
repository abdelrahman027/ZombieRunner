using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth target;
    [SerializeField]float Damage =40f;
    // Start is called before the first frame update



    void Start() 
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    void attackHitEvent()
    {
        if (target == null)return;
        Debug.Log("bang Bang");
        target.EnemyHit(Damage);
    }




}
