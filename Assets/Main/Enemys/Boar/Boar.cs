using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] float speed;
    
    void Update()
    {
        transform.Translate(new Vector2(speed, 0), Space.World);
    }
    
}
