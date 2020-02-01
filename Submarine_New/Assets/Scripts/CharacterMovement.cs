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
            animator.SetFloat("SPEED", 1f);
        }

        if (xInput == -1)
        {
            if(yInput == -1)
            {
                transform.Rotate(Vector3.up* -135);
            }
            else if(yInput == 0)
            {
                transform.Rotate(Vector3.up * -90);
            }
            else
            {
                transform.Rotate(Vector3.up * -45);
            }
        }
        else if(xInput == 1)
        {
            if (yInput == -1)
            {
                transform.Rotate(Vector3.up * 135);
            }
            else if(yInput == 0)
            {
                transform.Rotate(Vector3.up * 90);
            }
            else
            {
                transform.Rotate(Vector3.up * 45);
            }
        }else
        {
            if (yInput == -1)
            {
                transform.Rotate(Vector3.up * 180);
            }
            else if (yInput == 1)
            {
                transform.Rotate(Vector3.up * 0);
            }
            }

    }

    private void FixedUpdate()
    {
			transform.Translate((new Vector3(xInput, yInput, 0f)).normalized * speed * Time.deltaTime);
    }
}
