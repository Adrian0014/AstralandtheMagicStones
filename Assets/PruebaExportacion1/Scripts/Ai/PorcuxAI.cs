using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PorcuxAI : MonoBehaviour
{
    
    
    enum State
    {
        Patrolling,
        PatrolWait,
        Chasing,
        Attacking,
        WaitingAttack,

        
    }
    State currentState;
    NavMeshAgent porcuxAgent;

    public Transform player;
    
    int locationIndex = 0;
    public Transform[] locationPoints;
    
    public float visionRange;
    public float attackRange;

    public float startWaitTime;
    private float waitTime;

    public float atackTime;

    public float startAttackWaitTime;
    private float attackWaitTime;


    public Transform AibulletSpawn;
    public int powerType;


    public Transform quieta;
    
    void Awake()
    {
        porcuxAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
   

    void Start()
    {
        currentState = State.Patrolling;
        locationIndex = Random.Range(0, locationPoints.Length);
        waitTime = startWaitTime;
    }

  
    void Update()
    {
        switch (currentState)
        {
            case State.Patrolling:
                Patrol();               //
            break;
            case State.PatrolWait:
                Wait();
            break;
            case State.Chasing:
                Chase();
            break;
            case State.Attacking:
                Attack();
            break;
            case State.WaitingAttack:
                WaitAttack();
                break;
            default:
                Chase();
            break;
        }
    }

    void Patrol()
    {
        porcuxAgent.destination = locationPoints[locationIndex].position;                   //

        if(Vector3.Distance(transform.position, locationPoints[locationIndex].position) < 1)
        {
            currentState = State.PatrolWait;
        }
        
        if(Vector3.Distance(transform.position, player.position) < visionRange)
        {
            currentState = State.Chasing;
        }
    }

    void Wait()
    {
        porcuxAgent.destination = locationPoints[locationIndex].position;
        if(waitTime <= 0)
        {
            locationIndex = Random.Range(0, locationPoints.Length);
            waitTime = startWaitTime;
            currentState = State.Patrolling;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        if(Vector3.Distance(transform.position, player.position) < visionRange)
        {
            currentState = State.Chasing;
        }
    }

    void Chase()
    {
        porcuxAgent.destination = player.position;
        
        if(Vector3.Distance(transform.position, player.position) > visionRange)
        {
            currentState = State.Patrolling;
        }
        if(Vector3.Distance(transform.position, player.position) < attackRange)
        {
            currentState = State.Attacking;
        }
    }

    void Attack()
    {
        porcuxAgent.destination = player.position;
        
        if(this.gameObject.tag == "PorcuxPlanta")
        {
            powerType = 3;
        }

        if(this.gameObject.tag == "PorcuxFuego")
        {
            powerType = 2;
        }   

        if(atackTime <= 0 && this.gameObject.tag == "PorcuxPlanta")
        {
            Debug.Log("Patada en la boca");
            atackTime = 1;
            GameObject AIPlantBall = PoolManager.Instance.GetPooledPower(powerType, AibulletSpawn.position, AibulletSpawn.rotation);
            AIPlantBall.SetActive(true);
            //Instantiate(AIPlantbullet, AibulletSpawn.position, AibulletSpawn.rotation);
            currentState = State.WaitingAttack;

        }

        if (atackTime <= 0 && this.gameObject.tag == "PorcuxFuego")
        {
            Debug.Log("Patada en la boca");
            atackTime = 1;
            GameObject AIFireBall = PoolManager.Instance.GetPooledPower(powerType, AibulletSpawn.position, AibulletSpawn.rotation);
            AIFireBall.SetActive(true);

            //Instantiate(AIFirebullet, AibulletSpawn.position, AibulletSpawn.rotation);
            currentState = State.WaitingAttack;

        }

        else
        {
            atackTime -= Time.deltaTime;
        }        

        if(Vector3.Distance(transform.position, player.position) > attackRange)
        {
            currentState = State.Chasing;
        }



    }
    void WaitAttack()
    {
        porcuxAgent.destination = quieta.position;

        if (attackWaitTime <= 0)
        {
            attackWaitTime = 1;
            currentState = State.Chasing;
        }
        else
        {
            attackWaitTime -= Time.deltaTime;
        }

    }


    void OnDrawGizmos() 
    {
        foreach (Transform point in locationPoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(point.position, 1);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void OnTriggerEnter(Collider collider)
    {

        if (this.gameObject.tag == "PorcuxFuego" && collider.gameObject.tag == "Mojado")
        {
            Destroy(this.gameObject);
        }

        if (this.gameObject.tag == "PorcuxPlanta" && collider.gameObject.tag == "Caliente")
        {
            Destroy(this.gameObject);
        }
    }


}
