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
                Manager.instance.Resume();
                break;
            
            case "Level2":
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(2);
                Manager.instance.Resume();
                break;
            
            case "Level3":
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(3);
                Manager.instance.Resume();
                break;

            // need ng main menu ditow
            case "[TREE TEST] HuntingGrounds":
                Manager.instance.ForestBelow();
                Manager.instance.Resume();
                break;
            
            default:
                Manager.instance.ForestBelow();
                AggroLevel.instance.ResetAggro();
                Manager.instance.QuitGame();
                break;
        }
       
        // change the level value according to scene string
    }
}
