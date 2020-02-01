using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 4f;
    public Animator animator; 
    float xInput = 0f;
    float yInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        // Code to take care of animations
        /*
       if (xInput != 0f)
        {
            animator.SetFloat("SPEED", 0f);
            animator.SetFloat("SPEED", xInput);
        } else
        {
            animator.SetFloat("SPEED", 0f);
            animator.SetFloat("SPEED", yInput);
        }
       */
        if (xInput != 0 || yInput != 0)
        {
            animator.SetFloat("SPEED", 10f);
        }
        else
        {
            animator.SetFloat("SPEED", 0f);
        }

        bool check = false;
        if (xInput == -1 && !check)
        {
            if (yInput == -1)
            {
                transform.Rotate(Vector3.up * -135);
                check = true;
            }
            else if (yInput == 0)
            {
                transform.Rotate(Vector3.up * -90);
                check = true;
            }
            else
            {
                transform.Rotate(Vector3.up * -45);
                check = true;
            }
        }
        else if (xInput == 1 && !check)
        {
            if (yInput == -1)
            {
                transform.Rotate(Vector3.up * 135);
                check = true;
            }
            else if (yInput == 0)
            {
                transform.Rotate(Vector3.up * 90);
                check = true;
            }
            else
            {
                transform.Rotate(Vector3.up * 45);
                check = true;
            }
        }
        else if (xInput == 0 && !check)
        {
            if (yInput == -1)
            {
                transform.Rotate(Vector3.up * 180);
                check = true;
            }
            else if (yInput == 1)
            {
                transform.Rotate(Vector3.up * 0);
                check = true;
            }
        }
        if (yInput == 0 && xInput == 0)
        {
            check = false;
        }
    }
            
        /*if (Input.GetButtonDown("left") && Input.GetButtonDown("up"))
            RotateLeft();
    }

        void RotateLeft()
        {
            Quaternion theRotation = transform.localRotation;
            theRotation.z = 315;
            transform.localRotation = theRotation;
        }*/

        private void FixedUpdate()
    {
			transform.Translate((new Vector3(xInput, yInput, 0f)).normalized * speed * Time.deltaTime);
    }

}
