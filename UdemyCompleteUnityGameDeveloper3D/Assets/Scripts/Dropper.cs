using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float timeToLate = 5f;
    MeshRenderer meshRenderer;
    Rigidbody rigid;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigid= GetComponent<Rigidbody>();   

        rigid.useGravity = false;
        meshRenderer.enabled= false;
    }
    private void Update()
    {
        if(Time.time > timeToLate)
        {
            meshRenderer.enabled = true;
            rigid.useGravity= true;
        }
    }
}
