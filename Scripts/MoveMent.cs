using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    Rigidbody rb;
    AudioSource aus;
    [SerializeField] float mainThrust = 800f;

    [SerializeField] float mainRotate = 100f;


    [SerializeField] AudioClip mainEngine;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        aus = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*mainThrust*Time.deltaTime);
            if (!aus.isPlaying)
            {
                aus.PlayOneShot(mainEngine);
            }
           
        }
        else
        {
            aus.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward*Time.deltaTime*mainRotate);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * mainRotate);
        }
    }
}
