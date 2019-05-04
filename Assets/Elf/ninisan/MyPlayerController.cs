using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    CharacterController controller;
    Rigidbody2D rigidbody;

    [SerializeField] float force;
    [SerializeField] float gravity;
    [SerializeField] float jumpPower;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector2(0, -gravity));
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, 0).normalized;

        //rigidbody.velocity = dir * force;
        rigidbody.AddForce(dir * force);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, jumpPower));
        }

    }
}
