using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Termin : MonoBehaviour
{

    int health = 100;
    GameObject player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(knockdown());
        }
    }
    IEnumerator knockdown()
    {
        //agent.acceleration = 0;
        //agent.speed = 0;
        agent.isStopped = true;
        yield return new WaitForSeconds(5);
        //agent.acceleration = 8;
        //agent.speed = 3.5f;
        agent.isStopped = false;
    }


    /****************** Sudo code **********************************************************

    Enemry shoould follow the player hunting them down
    if they find them they attack


    if they get hit they recieve damage and flinch ani

    if health = 0 enemy fall ani and timer starts
    afte timer ends stnad ani
    health goes back to full and they start hunting again



    */
}
