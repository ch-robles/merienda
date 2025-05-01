using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCaller : MonoBehaviour
{
    // Start is called before the first frame update

    public TreeSeperator initTreeSeperator;
    public HunterCaller initHunterCaller;
    // public EnemyMovement initEnemyMove;
    void Start()
    {
        // initTreeSeperator = GetComponent<TreeSeperator>();
        // initHunterCaller = GetComponent<HunterCaller>();

        StartCoroutine(StartSequence());
    }

    public IEnumerator StartSequence(){
        initTreeSeperator.Seperate();
        yield return null;

        initHunterCaller.Hunt();
        yield return null;
    }

}
