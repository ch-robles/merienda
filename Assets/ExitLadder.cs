using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitLadder : MonoBehaviour
{
    private void OnTriggerStay(Collider other){
        if (other != null && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("[EXIT LADDER] EXIT HERE");

            int currentLevel = Manager.instance.GetLevel();
            
            switch(currentLevel){
                case 1:
                    //SceneManager.LoadScene("Level1");
                    SceneChanger.instance.ChangeScene("Level1");
                    Manager.instance.VillageAbove();
                    break;
                case 2:
                    //SceneManager.LoadScene("Level2");
                    SceneChanger.instance.ChangeScene("Level2");
                    Manager.instance.VillageAbove();
                    break;
                case 3:
                    //SceneManager.LoadScene("Level3");
                    SceneChanger.instance.ChangeScene("Level3");
                    Manager.instance.VillageAbove();
                    break;
            }

            // SceneChanger.instance.ChangeScene("[TREE TEST] HuntingGrounds");
        } else {
            Debug.Log("[EXIT LADDER] No button detected.");
        }
    }
}
