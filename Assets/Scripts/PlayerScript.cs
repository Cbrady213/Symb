using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Callbacks;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{


    Rigidbody rb;
    GameObject cam;
    public float speed = 1000;
    float collected = 0;
    float remaining = 20;
    public GameObject endZone;
    float time = 0;
    Boolean timerRunning;
    Boolean powerUpActive = false;
    TextMeshProUGUI timerDisp, healthDisp;
    Animator anim;
    public GameObject carrot;
    public GameObject baby;
    int countUntilBaby = 5;

    public AudioClip eat;
    AudioSource charAudio;





    int health = 100;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("Centre");
        timerRunning = true;
        timerDisp = GameObject.Find("TimerDisp").GetComponent<TextMeshProUGUI>();
        healthDisp = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();
        charAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {


        HandleMovement();
        HandleJump();
        handleGUI();
        transform.rotation = cam.transform.rotation;
        // cam.transform.position = rb.transform.position + offset;
    }

    void HandleMovement()

    {
        float vInput = Input.GetAxis("Vertical");
        rb.AddForce(cam.transform.forward * vInput * speed * Time.deltaTime, 0);
        if (vInput != 0)
        {
            anim.SetBool("Moving", true);


        }
        else anim.SetBool("Moving", false);


    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PowerUP());
            SpawnBaby();
            
        }
    }

    IEnumerator PowerUP()
    {
        if (!powerUpActive)
        {
            powerUpActive = true;
            speed = speed * 2;
            yield return new WaitForSeconds(5);
            speed = speed / 2;
            powerUpActive = false;


        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            pickupCollect();

        }

        else if (other.gameObject.CompareTag("EndZone"))
        {
            Debug.Log("YOU WIN!!!!!");
            timerRunning = false;

        }

    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health > 0)
            {
                health = health - 10;
                rb.AddForce(-transform.forward * 150);
                collision.gameObject.GetComponent<Termin>().KB(transform.forward * 150);

                if (health <= 0)
                {
                    anim.SetBool("Dead", true);
                    collision.gameObject.GetComponent<Termin>().agent.enabled = false;

                }

            }


        }
    }

    void pickupCollect()
    {
        collected++;
        charAudio.PlayOneShot(eat);
        countUntilBaby--;
        SpawnBaby();

        Debug.Log(collected);
        remaining--;
        if (remaining <= 0)
        {
            endZone.SetActive(true);
        }
        else SpawnPickup();
    }

    void handleGUI()
    {
        timerDisp.text = "Time: " + Math.Round(time, 2);
        if (timerRunning)
            time = time + Time.deltaTime;

        healthDisp.text = "Health: " + health;

    }


    void SpawnPickup()
    {
        Vector3 spawnloc = new Vector3(UnityEngine.Random.Range(-8, 8), 2, UnityEngine.Random.Range(-8, 8));

        Instantiate(carrot, spawnloc, carrot.transform.rotation);

        // test commit push cmd
    }

    void SpawnBaby()
    {
        if (countUntilBaby == 0)
        {
            Instantiate(baby, transform.position + (-transform.forward * 2), transform.rotation);
            countUntilBaby = 5;

        }


    }
}
