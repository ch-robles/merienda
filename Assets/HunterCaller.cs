using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterCaller : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hunter, player;
    public EnemyMovement hunterMovement;
    // public bool roamNow = false;
    private float aggroVal = 50;
    private float maxTime = 6;
    private float maxDistance = 20;

    // Update is called once per frame

    void Start(){
        Positioner();
        StartCoroutine(Roaming());
    }

    public void Positioner(){
        // closer to target when more aggressive
        float dist = maxDistance - ((aggroVal/100)*maxDistance);

        // randomize! rn its not
        hunter.transform.position = player.transform.position + new Vector3(dist, 0, dist);
    }

    public IEnumerator Roaming()
    {
        // start chase based on aggro level
        Debug.Log("Time Start");

        float secs = maxTime - ((aggroVal/100)*maxTime);
        
        yield return new WaitForSeconds(secs);
        
        Debug.Log(secs);
        hunter.SetActive(true);
        StartCoroutine(hunterMovement.FollowTarget());

        yield return null;
    }
}
