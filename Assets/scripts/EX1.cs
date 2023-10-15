using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EX1 : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 Position;
    private Vector3 Direction;

    public float MoveTimer;
    public float MoveTimerMax = 2f; //movement from point to point every 0.5 seconds.

    private float horizontalInput, verticalInput;

    private bool DirectQ = true;
    private bool DirectA = true;
    private bool DirectE = true;
    private bool DirectD = true;



    




    private void Awake()
    {
        startPosition = new Vector3(0, 0, 0);
        Position = startPosition;

        Direction = new Vector3(0, 0, 1); //FROG DIRECTION

    }

    private void Update() //executed everytime
    {
        FrogDirection();
        FrogMovement();

    }

    private void FrogMovement()
    {
        MoveTimer += Time.deltaTime;
        if (MoveTimer >= MoveTimerMax)
        {
            Position += Direction;
            MoveTimer -= MoveTimerMax;
        }

        transform.position = Vector3.MoveTowards(transform.position, Position, Time.deltaTime);
    }

    float speed = 3f;

    private void FrogDirection()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        transform.position = transform.position + moveDirection * speed * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Q) && DirectQ == true)
        {
            Direction.x = -1;
            Direction.y = 0;
            Direction.z = 1;

            DirectD = false;
            DirectA = true;
            DirectE = true;

        }

        else if (Input.GetKeyDown(KeyCode.A) && DirectA == true)
        {
            Direction.x = -1;
            Direction.y = 0;
            Direction.z = -1;

            DirectD = true;
            DirectQ = true;
            DirectE = false;
        }

        else if (Input.GetKeyDown(KeyCode.D) && DirectD == true)
        {
            Direction.x = 1;
            Direction.y = 0;
            Direction.z = -1;

            DirectA = true;
            DirectQ = false;
            DirectE = true;


        }

        else if (Input.GetKeyDown(KeyCode.E) && DirectE == true)
        {
            Direction.x = 1;
            Direction.y = 0;
            Direction.z = 1;

            DirectA = false;
            DirectQ = true;
            DirectD = true;
        }





    }

                
       


}
