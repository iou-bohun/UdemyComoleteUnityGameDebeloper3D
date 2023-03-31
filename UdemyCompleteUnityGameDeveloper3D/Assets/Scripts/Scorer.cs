using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int hit;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag !="Hit")
            hit++;
           Debug.Log("You've bumped into a thing this many times : " + hit);
    }
}
