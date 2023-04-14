using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed =10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor = 10f;

    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor; 
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(-pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xoffset = xThrow * Time.deltaTime * speed;
        float nextXPos = transform.localPosition.x + xoffset;
        float clampedXPos = Mathf.Clamp(nextXPos, -xRange, xRange);

        float yoffset = yThrow * Time.deltaTime * speed;
        float nextYPos = transform.localPosition.y + yoffset;
        float clampedYPos = Mathf.Clamp(nextYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
