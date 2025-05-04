using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(NavMeshSurface))]
public class BakeNavMesh : MonoBehaviour
{
    private NavMeshSurface surface;
    void Awake(){
        surface = GetComponent<NavMeshSurface>();
    }
    public void Bake(){
        surface.BuildNavMesh();
        Debug.Log("[BAKE NAV MESH] NavMesh built.");
    }
}
