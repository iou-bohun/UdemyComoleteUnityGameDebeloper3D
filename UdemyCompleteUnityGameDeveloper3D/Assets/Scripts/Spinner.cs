using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float spinSpeed;

    [SerializeField] private float yAngle = 1f;
    [SerializeField] private float xAngle = 0f;
    [SerializeField] private float zAngle = 0f;
    private void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
