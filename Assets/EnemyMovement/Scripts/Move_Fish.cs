using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Fish : MonoBehaviour
{
    public float scrollSpeed;
    public Vector2 initPosition = new Vector2(5, -5);
    public float appearTime = 3.0f;
    public float jumpPower = 10.0f;
    public float gravity = 1.0f;
    public float appearTimeCounter = 0.0f;


    private float vy;
    private bool jumpFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = initPosition;
    }

    void FixedUpdate()
    {
        appearTimeCounter += Time.deltaTime;


        if (appearTimeCounter >= appearTime)
        {
            if (jumpFlag == false)
            {
                Jump();
            }
            else if (jumpFlag == true)
            {
                Vector2 nextPosition = this.transform.position;
                nextPosition.y += vy;
                this.transform.position = nextPosition;

                vy -= gravity;
            }
        }

    }

    void Jump()
    {
        jumpFlag = true;
        vy += jumpPower;
    }

}
