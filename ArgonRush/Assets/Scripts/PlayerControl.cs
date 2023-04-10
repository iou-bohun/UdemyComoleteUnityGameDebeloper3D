using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private void Update()
    {
        float horizontalThrow = Input.GetAxis("Horizontal");
        float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(horizontalThrow);
    }
}
