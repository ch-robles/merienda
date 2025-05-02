using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
    [SerializeField] Animator transitionAnim;

    void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }

    public void Chase(){
        // Debug.Log("[SCENETRANSITION] Game Mode: Chase");
        StartCoroutine(ChaseStart());
    }
    IEnumerator ChaseStart(){

        // Debug.Log("[SCENETRANSITION] Anim: End");
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("HuntingGrounds");

        yield return new WaitForSeconds(2);

        // Debug.Log("[SCENETRANSITION] Anim: Start");
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        transitionAnim.SetTrigger("Idle");
        
        
    }
}
