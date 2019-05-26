using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyPlayerController : MonoBehaviour
{
#pragma warning disable 649

    // プレイヤーの状態
    private enum STATE
    {
        ON_GROUND,ON_JUMP
    }
    private STATE state = STATE.ON_GROUND;
    

    // プレイヤーのパラメータ
    [SerializeField] float force;
    [SerializeField] float jumpPower;
    [SerializeField] float knockBack_x, knockBack_y;
    private float HP = 1;


    public Slider slider;
    private Rigidbody2D rb;
    private SpriteRenderer s_renderer;
    private float damageTime = 0;
    private Vector3 player_pos;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        s_renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Clamp();
        OnDamage();
        switch (state)
        {
            case STATE.ON_GROUND:
                Move();
                Jump();
                break;

            case STATE.ON_JUMP:
                Move();
                break;

        }

        
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
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower));
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            KnockBack();
            Damaged(col);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            state = STATE.ON_GROUND;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            state = STATE.ON_JUMP;
        }
    }

    private void KnockBack()
    {
        rb.AddForce(new Vector2(-knockBack_x, knockBack_y));
    }

    private void Damaged(Collision2D col)
    {
        HP -= col.gameObject.GetComponent<EnemyDamage>().GetAttack();
        slider.value = HP;
        gameObject.layer = 12;
        s_renderer.color -= new Color(0, 0, 0, 0.5f);
        
    }

    private void OnDamage()
    {
        if(gameObject.layer == 12)
        {
            damageTime += Time.deltaTime;
        }

        if(damageTime >= 1.5f)
        {
            damageTime = 0;
            s_renderer.color += new Color(0, 0, 0, 0.5f);
            gameObject.layer = 9;
        }
    }

    void Clamp()
    {
        player_pos = transform.position; //プレイヤーの位置を取得

        player_pos.x = Mathf.Clamp(player_pos.x, -9f, 9f); //x位置が常に範囲内か監視

        transform.position = new Vector2(player_pos.x, player_pos.y); //範囲内であれば常にその位置がそのまま入る
    }

    void JudgeDeath()
    {
        if(HP <= 0 || transform.position.y <= -6)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
