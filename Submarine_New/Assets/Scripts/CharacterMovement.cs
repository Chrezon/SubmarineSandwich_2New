using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //CharacterController chara;
    public float speed = 4f;
    public Animator animator; 
    float xInput = 0f;
    float yInput = 0f;

    //private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");


        if (xInput !=0 || yInput != 0)
        {
            animator.SetFloat("SPEED", 10f);
        }
        else
        {
            animator.SetFloat("SPEED", 0f);
        }
    }

        private void FixedUpdate()
    {
        float angle = Vector2.SignedAngle(Vector2.down, new Vector2(xInput, yInput));
        Quaternion q = Quaternion.Euler(0f, 0f, angle);
        this.transform.rotation = q;
        transform.Translate((new Vector3(xInput, yInput, 0f)).normalized * speed * Time.deltaTime, Space.World);
        //moveDirection = new Vector3(xInput, yInput, 0f);
        /*
        if (xInput == -1 || xInput == 1)
        {
            Quaternion theRotation = transform.localRotation;
            theRotation.x = 180 * xInput;
            theRotation.y = 0f;
            theRotation.z = 0f;
            transform.localRotation = theRotation;
            transform.Translate((new Vector3(xInput, 0f, 0f)).normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate((new Vector3(0f, yInput, 0f)).normalized * speed * Time.deltaTime, Space.World);
        }*/
        //float div = yInput / xInput;
        //transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan(div));
        //transform.rotation = Quaternion.LookRotation(moveDirection);


        /*void movement()
    {
        Vector3 direction = new Vector3(xInput, yInput, 0f);
        transform.up = direction.normalized;
    }*/

    }

}
