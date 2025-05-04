using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }

    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
        
        switch(scene){
            case "[TREE TEST] HuntingGrounds":
                Manager.instance.ForestBelow();
                break;
            // need ng main menu ditow
            default:
                Manager.instance.VillageAbove();
                break;
        }
       
        // change the level value according to scene string
    }
}
