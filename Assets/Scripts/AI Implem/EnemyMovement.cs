using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float UpdateRate = 0f;
    private NavMeshAgent Agent;
    private float aggroVal;
    private float maxSpeed = 30;
    private float maxAnimSpeed = 5;
    private float maxDistance = 100;
    public Animator anim;
	bool walkReady; 

    public void Move()
    {
        aggroVal = AggroLevel.instance.GetAggroLevel();
        // Debug.Log("[ENEMY MOVEMENT] AggroLevel: " + aggroVal);
        Agent = GetComponent<NavMeshAgent>();
        float agentSpeed = maxSpeed*(aggroVal/100);
        Debug.Log("[ENEMY MOVEMENT] ENEMY SPEED: " + agentSpeed);

        Agent.speed = agentSpeed;
        Debug.Log(agentSpeed);

        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(FollowTarget());
    }

    public IEnumerator FollowTarget()
    {
        while(enabled)
        {
            Agent.SetDestination(Player.transform.position);
            anim.speed = maxAnimSpeed*(aggroVal/100);
            anim.SetBool("hunterWalk", true);
            yield return null;
        }
    }
}