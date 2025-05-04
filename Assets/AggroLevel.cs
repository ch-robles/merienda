using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroLevel : MonoBehaviour
{
    public static AggroLevel instance;
    private float aggroLevel;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }

    void Start(){
        CalculateAggroLevel();
    }

    public float GetAggroLevel(){
        return aggroLevel;
    }

    public void CalculateAggroLevel(){
        // if gamestate is running
        // aggroLevel = 50;
        // aggroLevel = Random.Range(0,100);
        aggroLevel = 25.0f;
        Debug.Log("[AGGRO LEVEL] AggroLevel: " + aggroLevel);
    }
}
