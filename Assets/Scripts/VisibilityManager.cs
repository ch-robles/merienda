using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    public float activeDistance = 80f;
    public float deactivateDistance = 100f;
    public float dist = 0f;
    public GameObject[] taggedObjects;

    // Start is called before the first frame update
    void Start()
    {
        taggedObjects = GameObject.FindGameObjectsWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in taggedObjects)
        {
            Transform platform = obj.transform;
            float dist = Vector3.Distance(platform.position, transform.position);
            if (obj.activeSelf && dist > deactivateDistance)
            {
                obj.SetActive(false);
            }
            else if (!obj.activeSelf && dist < activeDistance)
            {
                obj.SetActive(true);
            }
        }
    }
}
