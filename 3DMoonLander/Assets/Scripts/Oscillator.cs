using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVec;
    [SerializeField] [Range(0,1)] float movementFactor;
     
    private void Start()
    {
        startingPos = transform.position;
    }
    private void Update()
    {
        Vector3 offset = movementVec * movementFactor;
        transform.position =startingPos +  offset;
    }
}
