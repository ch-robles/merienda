using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPositioner : MonoBehaviour
{
    [SerializeField] public GameObject player, enemy;
    float aggroVal, maxDistance; 
    // int[] randomizer = {0,1,2,3};
    Vector3 newEnemyPosition = new Vector3(0,0,0);
    
    void Start(){
        aggroVal = AggroLevel.instance.GetAggroLevel();
    }
    public void PlayerPosition(){
        float x = Random.Range(-190, 190);
        float z = Random.Range(-190, 190);

        player.transform.position = new Vector3(x, player.transform.position.y, z);
        EnemyPosition();
    }

    public void EnemyPosition(){
        maxDistance = Mathf.Clamp((float) 1000-((aggroVal/100)*1000), 100, 1000);
        Debug.Log("[CHARACTER POSITIONER] maxDistance of enemy from player: " + maxDistance);
        newEnemyPosition = (Random.insideUnitCircle.normalized)*maxDistance;
        enemy.transform.position = new Vector3(Mathf.Clamp(newEnemyPosition.x,-190,190), enemy.transform.position.y, Mathf.Clamp(newEnemyPosition.z,-190,190));

    }
}
