using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseCaller : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        // SceneTransition.instance.Chase();
        Manager.instance.ForestBelow();
        Debug.Log("[CHASE CALLER] FELL!");
    }
}
