using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbovePositioner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;

    void Start(){
        transform.position = Manager.instance.GetCheckpoint();
        Debug.Log("[PLAYERABOVEPOSITIONER] Player positioned.");
    }
}
