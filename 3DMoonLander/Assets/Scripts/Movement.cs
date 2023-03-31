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
            //AddRelativeForce = ��ü �������� ���� ���� ���� ������ �ƴ϶� 
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
        //��ü�� �ٸ� ��ü�� �扥�ϰ� �Ǹ� ���ο� ���� �ۿ��ϰ� �Ǵµ� �̸� �����ϱ� ���� �ڵ� 
        rigid.freezeRotation = true; //Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigid.freezeRotation = false; // unfreezing ratation so the physics system can take over 
    }
}
