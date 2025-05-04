using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCaller : MonoBehaviour
{
    // Start is called before the first frame update

    public TreeSeperator initTreeSeperator;
    public HunterCaller initHunterCaller;
    CharacterPositioner initCharacterPositioner;
    public ChaseExits initChaseExits;
    public BakeNavMesh initBakeNavMesh;
    // public EnemyMovement initEnemyMove;
    void Start()
    {
        // initTreeSeperator = GetComponent<TreeSeperator>();
        // initHunterCaller = GetComponent<HunterCaller>();
        initCharacterPositioner = GetComponent<CharacterPositioner>();
        StartCoroutine(StartSequence());
    }

    public IEnumerator StartSequence(){
        initChaseExits.SpawnExits();
        yield return null;

        initBakeNavMesh.Bake();
        yield return null;

        initTreeSeperator.Seperate();
        yield return null;

        initCharacterPositioner.PlayerPosition();
        yield return null;

        initHunterCaller.Hunt();
        yield return null;
    }

}
