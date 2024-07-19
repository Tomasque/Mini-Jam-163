using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float groundAcceleration;
    [SerializeField] float glideAcceleration;
    [SerializeField] float alwaysDrag;
    [SerializeField] float jumpAcceleration;
    [SerializeField] float fallAcceleration;
    [SerializeField] float maxRunSpeed;
    [SerializeField] float maxJumpSpeed;
    [SerializeField] float maxFallSpeed;
    [HideInInspector] public float horizontalVelocity;
    [HideInInspector] public float verticalVelocity;

    private void Update()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalVelocity += groundAcceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalVelocity -= groundAcceleration * Time.deltaTime;
        }

        float runSign = Mathf.Sign(horizontalVelocity);
        horizontalVelocity -= alwaysDrag * runSign * Time.deltaTime;
        if (Mathf.Sign(horizontalVelocity) != runSign)
            horizontalVelocity = 0;

        horizontalVelocity = Mathf.Clamp(horizontalVelocity, -maxRunSpeed, maxRunSpeed);

        transform.position += Vector3.right * horizontalVelocity * Time.deltaTime;


        //Notes for code for the platforms: When a platform triggerStay2Ds your foot trigger, it sets vertical velocity to be minimum of 0
            //then, if it is 0, it sets your yPosition to the yPosition of the platform
    }
}
