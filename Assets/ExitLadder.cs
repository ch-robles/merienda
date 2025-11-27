using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitLadder : MonoBehaviour
{
    public GameObject hunterUnity;

    public void Start()
    {
        hunterUnity = GameObject.FindGameObjectWithTag("Hunter");
    }

    private void OnTriggerStay(Collider other){
        if (other != null && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("[EXIT LADDER] EXIT HERE");

            int currentLevel = Manager.instance.GetLevel();
            
            switch(currentLevel){
                case 0:
                    //SceneManager.LoadScene("Level1");
                    //SceneChanger.instance.ChangeScene("Level1");
                    //SceneManager.LoadSceneAsync(2);
                    LoadingManager.Instance.SwitchToScene(2);
                    hunterUnity.SetActive(false);
                    Manager.instance.VillageAbove();
                    break;
                case 1:
                    //SceneManager.LoadScene("Level1");
                    //SceneChanger.instance.ChangeScene("Level1");
                    //SceneManager.LoadSceneAsync(2);
                    LoadingManager.Instance.SwitchToScene(2);
                    hunterUnity.SetActive(false);
                    Manager.instance.VillageAbove();
                    break;
                case 2:
                    //SceneManager.LoadScene("Level2");
                    //SceneChanger.instance.ChangeScene("Level2");
                    //SceneManager.LoadSceneAsync(3);
                    LoadingManager.Instance.SwitchToScene(3);
                    hunterUnity.SetActive(false);
                    Manager.instance.VillageAbove();
                    break;
                case 3:
                    //SceneManager.LoadScene("Level3");
                    //SceneChanger.instance.ChangeScene("Level3");
                    //SceneManager.LoadSceneAsync(4);
                    LoadingManager.Instance.SwitchToScene(4);
                    hunterUnity.SetActive(false);
                    Manager.instance.VillageAbove();
                    break;
            }

            // SceneChanger.instance.ChangeScene("[TREE TEST] HuntingGrounds");
        } else {
            Debug.Log("[EXIT LADDER] No button detected.");
        }
    }
}
