using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float groundAcceleration;
    [SerializeField] float glideAcceleration;
    [SerializeField] float groundDrag;
    [SerializeField] float glideDrag;
    [SerializeField] float initialJump;
    [SerializeField] float buoySpeed;
    [SerializeField] float fallAcceleration;
    [SerializeField] float poundSpeed;
    [SerializeField] float maxRunSpeed;
    [SerializeField] float maxJumpSpeed;
    [SerializeField] float maxFallSpeed;

    [HideInInspector] public float horizontalVelocity;
    [HideInInspector] public float verticalVelocity;
    [HideInInspector] public bool grounded;
    [HideInInspector] public bool jumping;
    [HideInInspector] public bool fixedFall = true;
    [HideInInspector] public bool pounding;

    bool ready;

    private void Awake()
    {
        StartCoroutine(Delay());
    }

    private void Update()
    {
        float acceleration;
        float drag;
        if (grounded)
        {
            acceleration = groundAcceleration;
            drag = groundDrag;
        }
        else
        {
            acceleration = glideAcceleration;
            drag = glideDrag;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalVelocity += acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalVelocity -= acceleration * Time.deltaTime;
        }
        
        float runSign = Mathf.Sign(horizontalVelocity);
        horizontalVelocity -= drag * runSign * Time.deltaTime;
        if (Mathf.Sign(horizontalVelocity) != runSign)
            horizontalVelocity = 0;

        horizontalVelocity = Mathf.Clamp(horizontalVelocity, -maxRunSpeed, maxRunSpeed);



        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
        {
            verticalVelocity = initialJump;
            grounded = false;
            fixedFall = false;
            jumping = true;
        }

        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && jumping && !pounding)
        {
            verticalVelocity += buoySpeed * Time.deltaTime;
        }
        else
        {
            jumping = false;
        }
        /*
        if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !grounded)
        {
            pounding = true;
        }

        if(pounding)
        {
            verticalVelocity -= poundSpeed;
        }
        */
        verticalVelocity -= fallAcceleration * Time.deltaTime;
        verticalVelocity = Mathf.Clamp(verticalVelocity, maxFallSpeed, maxJumpSpeed);

        if(verticalVelocity <= 0)
        {
            jumping = false;
        }

        if (!ready)
            verticalVelocity = Mathf.Max(0, verticalVelocity);

        transform.position += Vector3.right * horizontalVelocity * Time.deltaTime;
        if (!fixedFall)
            transform.position += Vector3.up * verticalVelocity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (ready && fixedFall)
            transform.position += (Vector3.up * verticalVelocity * Time.fixedDeltaTime)/2f;
    }

    IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(.1f);

        ready = true;
    }

}
