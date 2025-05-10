using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        SaveCheckpoint();
    }

    public void SaveCheckpoint(){
        Manager.instance.SetCheckpoint(transform.position);
        Debug.Log("[CHECKPOINT] CHECKPOINT SAVED");
        if(Manager.instance.GetState() == false){
            Manager.instance.SetState(true);
        }
    }
}
