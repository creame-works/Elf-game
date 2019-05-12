using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Wolf : MonoBehaviour
{
    public Vector2 initPosition = new Vector2(10.0f, -3.0f);
    public float speed = 0.5f;          //狼の足の速さ
    public float jumpPower = 3.0f;      //どのぐらいの高さジャンプするか
    public float jumpWaitTime = 1.0f;   //ジャンプ終わりから次のジャンプまでの時間

    private Vector2 jumpVector;
    private bool isGround;
    private float jumpWaitTimeCounter = 0.0f;

    private Rigidbody2D rb;             //Rigidbodyを使わないコード書くのがめんどかったので許して・・・

    // Start is called before the first frame update
    void Start()
    {
        jumpVector = new Vector2(0, jumpPower);
        this.transform.position = initPosition;
        isGround = false;

        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        SetPosition();

        if(isGround == true)
        {
            if(jumpWaitTimeCounter < jumpWaitTime)
            {
                jumpWaitTimeCounter += Time.deltaTime;
            }
            else if(jumpWaitTimeCounter >= jumpWaitTime)
            {
                Jump();
                jumpWaitTimeCounter = 0.0f;
            }
        }
    }

    void SetPosition()
    {
        Vector2 nextPosition = this.transform.position;
        nextPosition.x -= speed;
        this.transform.position = nextPosition;

    }

    void Jump()
    {
        rb.AddForce(jumpVector, ForceMode2D.Impulse);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
