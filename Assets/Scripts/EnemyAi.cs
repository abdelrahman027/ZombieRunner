using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMesh;
    [SerializeField] Transform target;
    [SerializeField] float chaseRange =5f;
    [SerializeField] float turnSpeed=5f;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked =false; 
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) 
        {
            EngageTarget();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked=true;
            // navMesh.SetDestination(target.position);
        }

    }
    public void onDamageTaken()
    {
        isProvoked=true;
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMesh.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMesh.stoppingDistance)
        {
            AttackTarget();
        }
    }
    void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("move");
        navMesh.SetDestination(target.position);
        GetComponent<Animator>().SetBool("attack",false);
    }
    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack",true);
        Debug.Log("Attacking!");
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime* turnSpeed);
    }
}
