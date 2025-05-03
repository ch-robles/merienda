using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChaseExits : MonoBehaviour
{
    [SerializeField] public List<GameObject> treeGroup;

    private List<int> areas;
    private int[] areasArray = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
    private int treehouseCount, areaNo;

    // Update is called once per frame
    void Start(){
        // TEST: Choose 5 random areas, and then 
        treehouseCount = 5;
        areas = new List<int>();

        while(treehouseCount != 0){
            
            areaNo = Random.Range(0,16);
            
            if (areasArray[areaNo] != 0){
                Debug.Log("[CHASE EXITS] Area " + areasArray[areaNo] + " added.");
                areas.Add(areasArray[areaNo]);
                areasArray[areaNo] = 0;
                treehouseCount--;
            }
        }

        // Deciding which of the two becomes a treehouse in the area
        for (int i = 0; i < areas.Count; i++){
            int decider = Random.Range(0,2);
            int treehouse = 0;

            // if 1, odd number becomes the treehouse
            if(decider == 0){
                treehouse = (areas.ElementAt(i)*2)-1;
                Debug.Log("[CHASE EXITS] Treehouse No.: " + treehouse);
            } 
            
            // else, even becomes treehouse
            else if (decider == 1){
                treehouse = (areas.ElementAt(i)*2)-2;
                Debug.Log("[CHASE EXITS] Treehouse No.: " + treehouse);
            }

            treeGroup.ElementAt(treehouse).transform.GetChild(0).gameObject.SetActive(true);
            treeGroup.ElementAt(treehouse).transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
