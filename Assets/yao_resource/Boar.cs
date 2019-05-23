using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour
{

    bool on_dush = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            on_dush = true;
        }
        if (on_dush)
        {
            transform.Translate(new Vector2(-0.1f, 0), Space.World);
        }
    }
}
