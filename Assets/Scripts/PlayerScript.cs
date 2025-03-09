using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Callbacks;
using UnityEngine;
using TMPro;
public class PlayerScript : MonoBehaviour
{


    Rigidbody rb;
    GameObject cam;
    public float speed = 1000;
    float collected = 0;
    float remaining = 3;
    public GameObject endZone;
    float time = 0;
    Boolean timerRunning;
    Boolean powerUpActive = false;
    TextMeshProUGUI timerDisp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("Centre");
        timerRunning = true;
        timerDisp = GameObject.Find("TimerDisp").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        rb.AddForce(cam.transform.forward * vInput * speed * Time.deltaTime, 0);
        HandleJump();
        handleTimer();
        // cam.transform.position = rb.transform.position + offset;
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PowerUP());
            //rb.AddForce(cam.transform.up *300);
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
            powerUpActive =false;

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

    void pickupCollect()
    {
        collected++;
        Debug.Log(collected);
        remaining--;
        if (remaining == 0)
        {
            endZone.SetActive(true);
        }
    }

    void handleTimer()
    {
        timerDisp.text = "Time: " + time;
        if (timerRunning)
            time = time + Time.deltaTime;

    }
}
