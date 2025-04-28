using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float UpdateRate = 0.1f;
    private NavMeshAgent Agent;
    private float aggroVal = 100;
    private float maxSpeed = 200;
    private float maxDistance = 100;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        float agentSpeed = maxSpeed*(aggroVal/100);

        Agent.speed = agentSpeed;
        Debug.Log(agentSpeed);

        
    }

    public IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
        
        while(enabled)
        {
            Agent.SetDestination(Player.transform.position);
            yield return Wait;
        }
    }
}