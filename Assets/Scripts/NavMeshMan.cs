using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMan : MonoBehaviour
{

    public NavMeshSurface navMeshSurface;
    // Start is called before the first frame update
    void Start()
    {

        navMeshSurface = GameObject.Find("NavMesh").GetComponent<NavMeshSurface>();
        StartCoroutine(UpdateNavMesh());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator UpdateNavMesh()
    {
        yield return new WaitForSeconds(0);
        navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);




    }

}
