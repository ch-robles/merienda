using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroLevel : MonoBehaviour
{
    public static AggroLevel instance;
    private float aggroLevel;
    private float mamonCount;

    private bool running;
    bool mamonSent = false;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }

    // on play move
    public void StartLevel(){
        // CalculateAggroLevel();
        InvokeRepeating("CalculateAggroLevelTime", 0.0f, 1.0f);
        Debug.Log("[AGGRO LEVEL] AggroLevel: " + aggroLevel);
    }

    // on chase mode
    public void ChaseScene(){
        CancelInvoke();
        Debug.Log("[AGGRO LEVEL] AggroLevel: " + aggroLevel);
    }

    // when game is not started, or when finishing level
    void ResetAggro(){
        aggroLevel = 0;
    }


    public float GetAggroLevel(){
        return aggroLevel;
    }

    public void CalculateAggroLevelMamon(){

        int level = Manager.instance.GetLevelNow();
        switch (level){
            case 1:
                mamonCount = 5f;
                break;
            case 2:
                mamonCount = 6f;
                break;
            case 3:
                mamonCount = 7f;
                break;
            }
        
        float aggroLevelCalc = aggroLevel + (mamonCount/100f);

        if(aggroLevel < 100){
            aggroLevel = aggroLevelCalc;
            Debug.Log("[AGGRO LEVEL] AggroLevel: " + aggroLevel);
        }
    }

    public void CalculateAggroLevelTime(){
        float aggroLevelCalc = aggroLevel + (100f/600f);

        if(aggroLevel < 100){
            aggroLevel = aggroLevelCalc;
            Debug.Log("[AGGRO LEVEL] AggroLevel: " + aggroLevel);
        }
    }
}
