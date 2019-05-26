using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Nohashi : MonoBehaviour
{
    public float scrollSpeed;
    public float jumpPower = 3.0f;
    public float gravity = 0.3f;

    private bool jumpFlag;
    private bool isGrab;

    private float originalPosition_Y;
    private float vy;


    // Start is called before the first frame update
    void Start()
    {
        jumpFlag = false;
        isGrab = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpFlag == true)
            Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            jumpFlag = true;
        }

    }
    void Jump()
    {
        if (isGrab == true)
        {
            isGrab = false;
            vy = jumpPower;
            originalPosition_Y = this.transform.position.y;

            Vector2 nextPosition = this.transform.position;
            nextPosition.y += vy;
            this.transform.position = nextPosition;
        }
        else if (isGrab == false)
        {
            if (originalPosition_Y < this.transform.position.y)
            {
                vy -= gravity;
                Vector2 nextPosition = this.transform.position;
                nextPosition.y += vy;
                this.transform.position = nextPosition;
            }
            else
            {
                Vector2 nextPosition = this.transform.position;
                nextPosition.y = originalPosition_Y;
                this.transform.position = nextPosition;

                jumpFlag = false;
                isGrab = true;
            }
        }
    }
}
