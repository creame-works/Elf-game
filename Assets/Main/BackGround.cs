using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] public float limit_x;
    [SerializeField] public float speed;
    [SerializeField] Vector3 new_pos;

    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(new Vector3(-speed, 0, 0));

        if(transform.position.x <= limit_x)
        {
            transform.position = new_pos;
        }
    }


}
