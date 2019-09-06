using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround1 : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] float speed;
    [SerializeField] float xPoint;
    [SerializeField] Vector3 newPos;
    
    void Update()
    {
        transform.Translate(-speed, 0, 0);

        if(transform.position.x <= xPoint)
        {
            transform.position = newPos;
        }
    }
}
