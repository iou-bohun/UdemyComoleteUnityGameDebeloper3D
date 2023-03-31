using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    [SerializeField] private float rotationSpeed = 100;

    bool audioIsPlaying;
    AudioSource audio;
    Rigidbody rigid;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotation(-rotationSpeed);
        }
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //AddRelativeForce = 물체 기준으로 물리 적용 월드 기준이 아니라 
            rigid.AddRelativeForce(Vector3.up * speed *Time.deltaTime);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            audio.Pause(); 
        }
    }

    private void Rotation(float rotationThisFrame)
    {
        //물체가 다른 물체와 충돟하게 되면 새로운 힘이 작용하게 되는데 이를 방지하기 위한 코드 
        rigid.freezeRotation = true; //Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigid.freezeRotation = false; // unfreezing ratation so the physics system can take over 
    }
}
