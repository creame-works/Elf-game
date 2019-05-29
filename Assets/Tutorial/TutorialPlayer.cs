using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{
#pragma warning disable 649

    public enum STATE
    {
        CANNOT_INPUT,ONLY_MOVE,CAN_ALL
    }
    public STATE PlayerState;

    private Vector3 playerPos;
    [SerializeField] float force;
    private Rigidbody2D rb;
    [SerializeField] float jumpPower;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        switch (PlayerState)
        {
            case STATE.CANNOT_INPUT:
                break;

            case STATE.ONLY_MOVE:
                Move();
                break;

            case STATE.CAN_ALL:
                Move();
                Jump();
                break;
        }
        Clamp();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(x, 0).normalized;
        rb.position += dir * force;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpPower));
        }
    }

    void Clamp()
    {
        playerPos = transform.position; //プレイヤーの位置を取得

        playerPos.x = Mathf.Clamp(playerPos.x, -9f, 9f); //x位置が常に範囲内か監視

        transform.position = new Vector2(playerPos.x, playerPos.y); //範囲内であれば常にその位置がそのまま入る
    }

    public void SetState(int num)
    {
        switch (num)
        {
            case 0:
                PlayerState = STATE.CANNOT_INPUT;
                break;
            case 1:
                PlayerState = STATE.ONLY_MOVE;
                break;
            case 2:
                PlayerState = STATE.CAN_ALL;
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            rb.AddForce(new Vector2(500f, 1200f));
        }
    }
}
