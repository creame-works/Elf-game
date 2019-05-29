using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] float speed;
    [SerializeField] float knockBack_x, KnockBack_y;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        transform.Translate(new Vector2(speed, 0), Space.World);
        if(transform.position.x <= -15f)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            rb.AddForce(new Vector2(-knockBack_x, KnockBack_y));
        }
    }
}
