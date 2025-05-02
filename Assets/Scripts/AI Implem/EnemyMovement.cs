using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float UpdateRate = 0f;
    private NavMeshAgent Agent;
    private float aggroVal = 100;
    private float maxSpeed = 30;
    private float maxAnimSpeed = 5;
    private float maxDistance = 100;
    public Animator anim;
	bool walkReady; 

    public void Move()
    {
        Agent = GetComponent<NavMeshAgent>();
        float agentSpeed = maxSpeed*(aggroVal/100);

        Agent.speed = agentSpeed;
        Debug.Log(agentSpeed);

        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(FollowTarget());
        anim.SetBool("hunterWalk", false);
		// walkReady = false;
    }

    public IEnumerator FollowTarget()
    {
        // WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
        
        while(enabled)
        {
            // transform.LookAt(Player);
            // FaceTarget();
            Agent.SetDestination(Player.transform.position);
            anim.speed = maxAnimSpeed*(aggroVal/100);
            anim.SetBool("hunterWalk", true);
            // Debug.Log(Player.transform.position.x + ", " + Player.transform.position.y + ", " + Player.transform.position.z);
            // Debug.Log("Player Position X: " + Player.transform.position.x);
            // Debug.Log("Player Position Y: " + Player.transform.position.y);
            // Debug.Log("Player Position Z: " + Player.transform.position.z);
            yield return null;
        }
    }

    // void FaceTarget(){
    //     Vector3 direction = (Player.position - transform.position).normalized;
    //     Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //     transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    // }
}