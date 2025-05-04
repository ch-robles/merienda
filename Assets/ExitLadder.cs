using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLadder : MonoBehaviour
{
    private void OnTriggerStay(Collider other){
        if (other != null && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("[EXIT LADDER] EXIT HERE");
            SceneChanger.instance.ChangeScene("[TREE TEST] HuntingGrounds");
        } else {
            Debug.Log("[EXIT LADDER] No button detected.");
        }
    }
}
