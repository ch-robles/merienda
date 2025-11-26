using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public float dist = 0f;
    public GameObject[] taggedObjects;
    private LODGroup lodGroup;

    // Start is called before the first frame update
    void Start()
    {
        /*taggedObjects = GameObject.FindGameObjectsWithTag("Trees");
        foreach (GameObject obj in taggedObjects)
        {
            lodGroup = obj.GetComponent<LODGroup>();
            lodGroup.ForceLOD(4);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (GameObject obj in taggedObjects)
        {
            lodGroup = obj.GetComponent<LODGroup>();

            Transform platform = obj.transform;
            float dist = Vector3.Distance(platform.position, transform.position);

            if (dist < 60f)
            {
                lodGroup.ForceLOD(0);
            }
            else if (dist < 70f)
            {
                lodGroup.ForceLOD(1);
            }
            else if (dist < 80f)
            {
                lodGroup.ForceLOD(2);
            }
            else if (dist < 90f)
            {
                lodGroup.ForceLOD(3);
            }
            else
            {
                lodGroup.ForceLOD(4);
            }
        }*/
    }
}
