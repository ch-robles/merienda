using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectCounter : MonoBehaviour
{
    [MenuItem("Tools/Count All Objects In Scene")]
    static void CountObjects()
    {
        int count = Resources.FindObjectsOfTypeAll<GameObject>().Length;
        Debug.Log("Total GameObjects in scene (including inactive): " + count);
    }
}
