using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{

    [SerializeField] public float speed;
    
   
    void Update()
    {
        transform.position += new Vector3(-speed, 0, 0);
        if(transform.position.x <= -22f)
        {
            Destroy(gameObject);
        }
    }
    
}
