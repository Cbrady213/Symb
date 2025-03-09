using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject point;
    
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.Find("Centre");
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, hInput * 100 * Time.deltaTime);
        //Debug.Log(hInput);
        

    }
}
