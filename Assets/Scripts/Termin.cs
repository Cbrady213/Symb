using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Termin : MonoBehaviour
{

    int health = 100;
    GameObject player;
    public NavMeshAgent agent;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(knockdown());
        }
    }
    IEnumerator knockdown()
    {

        agent.isStopped = true;
        yield return new WaitForSeconds(5);

        agent.isStopped = false;
    }

    public void Movement()
    {
        agent.SetDestination(player.transform.position);
    }

    public void KB(Vector3 kbDir)
    {
        StartCoroutine(Knockback(kbDir)) ;

    }

    public IEnumerator Knockback(Vector3 direction)
    {
        agent.enabled = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(direction);
        yield return new WaitForSeconds(2);
        rb.isKinematic = true;
        rb.useGravity = false;
        agent.enabled = true;
        agent.Warp(transform.position);

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
