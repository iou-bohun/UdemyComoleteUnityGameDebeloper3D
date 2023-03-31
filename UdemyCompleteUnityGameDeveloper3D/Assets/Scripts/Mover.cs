using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed ;
    private void Start()
    {
        ShowInformation();
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(xValue, 0f, zValue);
    }

    void ShowInformation()
    {
        Debug.Log("Press W A S D to move your player");
        Debug.Log("Don't hit the walls!!");
    }
}
