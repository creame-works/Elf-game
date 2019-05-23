using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Boar : MonoBehaviour
{
    public float scrollSpeed;
    public Vector2 initPosition = new Vector2(20, -5);
    public float speed = 0.2f;

    private Vector2 speedVector;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = initPosition;

        speedVector = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-speedVector);
    }
}
