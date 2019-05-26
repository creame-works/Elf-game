using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{
    
    private enum State
    {
        AUTOWALK,TAMEIKI,SAYUU,JUMP,QUAKE
    }
    private State STATE = State.AUTOWALK;

    private float moveDistance = 1f;

    void Start()
    {
        
    }

    
    void Update()
    {
        switch (STATE)
        {
            case State.AUTOWALK:
                transform.position += new Vector3(moveDistance, 0, 0);
                moveDistance -= 0.1f;

                if(moveDistance <= 0)
                {
                    STATE = State.TAMEIKI;
                }
                break;
        }
    }
}
