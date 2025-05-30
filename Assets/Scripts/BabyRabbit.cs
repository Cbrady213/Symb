using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BabyRabbit : MonoBehaviour
{
    NavMeshAgent navMA;
    GameObject player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        navMA = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
;        
    }

    // Update is called once per frame
    void Update()
    {
        navMA.SetDestination(player.transform.position);
        Debug.Log(navMA.velocity.magnitude);
        if (navMA.velocity.magnitude > 0)
        {
            anim.SetBool("Moving", true);
        }
        
    }
}
