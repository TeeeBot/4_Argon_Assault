using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f; //metres per second
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 4f; //metres per second

    [Tooltip("In Metres")][SerializeField] float xRange = 3f;

    [Tooltip("In Metres")] [SerializeField] float yMin = 3f;
    [Tooltip("In Metres")] [SerializeField] float yMax = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 7f;
    [SerializeField] float controlRollFactor = -20f;  

    float xThrow, yThrow;
     

    void Start()
    {

    }

    void Update()
    {
        ProcessPlayerTranslation();
        ProcessPlayerRotation();

    }

    private void ProcessPlayerTranslation()
    {
        //throw is used to describe the movement of the analgue stick (0 to 1)
        //All the calculations are per frame as this is on the update method
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXpos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(rawYPos, -yMin, yMax);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }

    private void ProcessPlayerRotation() 
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToThrow = yThrow * controlPitchFactor;
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float rollDueToThrow = xThrow * controlRollFactor; 

        float pitch =  pitchDueToPosition + pitchDueToThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
