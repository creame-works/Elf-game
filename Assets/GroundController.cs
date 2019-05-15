using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] GameObject ground_element;
    [SerializeField] float speed;

    float elapsed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (elapsed == 20)
        {
            GameObject ground_ = Instantiate(ground_element, new Vector3(), new Quaternion());
            ground_.GetComponent<MovingGround>().speed = speed;
            elapsed = 0;
        }
        else
        {
            elapsed+=1;
        }

    }
}
