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
        
        switch(scene){
            case "Level1":
                LoadingManager.Instance.SwitchToScene(2);

                Manager.instance.setMamons(5.0f);
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(1);
                AudioManager.PlayGameMusic();

                Manager.instance.Resume();
                break;
            
            case "Level2":
                LoadingManager.Instance.SwitchToScene(3);

                Manager.instance.setMamons(6.0f);
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(2);
                AudioManager.PlayGameMusic();
                Manager.instance.Resume();
                break;
            
            case "Level3":
                LoadingManager.Instance.SwitchToScene(4);

                Manager.instance.setMamons(7.0f);
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(3);
                Manager.instance.Resume();
                break;

            // need ng main menu ditow

            case "Tutorial":
                LoadingManager.Instance.SwitchToScene(1);

                Manager.instance.setMamons(0.0f);
                Manager.instance.VillageAbove();
                Manager.instance.SetLevel(0);
                Manager.instance.Resume();
                break;

            case "[TREE TEST] HuntingGrounds":
                SceneManager.LoadScene(scene);

                Manager.instance.setMamons(0.0f);
                Manager.instance.ForestBelow();
                Manager.instance.Resume();
                break;

            default:
                SceneManager.LoadScene(scene);

                Manager.instance.setMamons(0.0f);
                Manager.instance.ForestBelow();
                AggroLevel.instance.ResetAggro();
                Manager.instance.QuitGame();
                break;
        }
       
        // change the level value according to scene string
    }
}
