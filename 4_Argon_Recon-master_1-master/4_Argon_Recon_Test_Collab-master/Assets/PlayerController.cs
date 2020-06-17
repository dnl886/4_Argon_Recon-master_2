using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float speed = 22f;
    //[Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In ms")] [SerializeField] float xRange = 12f;
    [Tooltip("In ms")] [SerializeField] float yRange = 12f;

    [SerializeField] GameObject[] guns;

    [Header("Position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control Based")]
    [SerializeField] float controlPitchFactor = -20;
    [SerializeField] float controlRollFactor = -20;

    float xThrow, yThrow;
    bool isControllerEnabled;

    void Start()
    {
        
    }

    void OnPlayerDeath()
    {
        isControllerEnabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print ("Player Collided with enemy");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Player Triggered Something");
    }

    // Update is called once per frame
    void Update()
    {
        if (isControllerEnabled = true)
        {
            ProcessTranslations();
            ProcessRotations();
            ProcessFiring();
        }
    }
    void ProcessRotations()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToRotation = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToRotation;

        float yaw = transform.localPosition.x * positionYawFactor;
        
        float roll = xThrow * controlRollFactor;
        

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslations()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // the offset is simply how much do we want to move left and right in this frame
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");   //// the offset is simply how much do we want to move left and right in this frame

        float xOffsetThisFrame = xThrow * speed * Time.deltaTime; //how many centermiters do i need to move in this frame
        float yOffsetThisFrame = yThrow * speed * Time.deltaTime; //how many centermiters do i need to move in this frame

        //Debug.Log(yOffsetThisFrame);

        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float rawYPos = transform.localPosition.y + yOffsetThisFrame;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    void ActivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    void DeactivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }
}
