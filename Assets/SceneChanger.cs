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
            case "Level1":
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(1);
                break;
            
            case "Level2":
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(2);
                break;
            
            case "Level3":
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(3);
                break;

            // need ng main menu ditow
            case "[TREE TEST] HuntingGrounds":
                Manager.instance.ForestBelow();
                break;
            
            default:
                Manager.instance.ForestBelow();
                AggroLevel.instance.ResetAggro();
                break;
        }
       
        // change the level value according to scene string
    }
}
