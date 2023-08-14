using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] AudioClip engageSFX;
    [SerializeField] AudioClip attackSFX;
    
    EnemyHealth enemyHealth;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    NavMeshAgent navMeshAgent;
    Transform target;
    AudioSource s;
    void Start()
    {   
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth =  GetComponent<EnemyHealth>(); 
        target = FindObjectOfType<PlayerHealth>().transform;
        s = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (enemyHealth.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget =  Vector3.Distance(target.position, transform.position);

        if (isProvoked == true)
        {   
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {   
            if (!s.isPlaying)
            {
                s.PlayOneShot(engageSFX);
            }
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {   
        if (!s.isPlaying)
        {
            s.PlayOneShot(engageSFX);
        }
        isProvoked = true;
    }

    void EngageTarget()
    {   
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {   
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {  
            AttackTarget();
        }
    }

    void ChaseTarget()
    {   
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    void AttackTarget()
    {   
        GetComponent<Animator>().SetBool("attack", true);
        if (!s.isPlaying)
        {
            s.PlayOneShot(attackSFX);
        }
    }
    void FaceTarget()
    {   
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        //transform.rotation = where the target is, we need to rotate at a certain speed
    }
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
