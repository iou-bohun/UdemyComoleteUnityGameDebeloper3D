using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        MeshRenderer meshRenderer= GetComponent<MeshRenderer>();
        
        if(collision.gameObject.tag == "Player")
        {
            meshRenderer.material.color = Color.red;
            gameObject.tag = "Hit";
        }

    }
}
