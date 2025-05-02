using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseCaller : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other){
        // Debug.Log("Fall detected.");
        // SceneManager.LoadScene("HuntingGrounds");

        // StartCoroutine(SceneTransition.instance.Chase());
        // Manager.instance.Chase();

        SceneTransition.instance.Chase();
    }
}
