﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move_FlyingSquirrel : MonoBehaviour
{
    public GameObject Player;
    public float scrollSpeed;
    public float flyXPosition;
    public Vector2 initPosition = new Vector2(11.5f, 4.5f);
    //public Vector2 middlePoint;
    private Vector2 middlePoint;
    public Vector2 finishPoint = new Vector2(-20, 4);

    private Vector3[] orbit = new Vector3[3];

    public float moveTime = 1.0f;      //どのぐらいの時間で移動するか

    enum State
    {
        STAY,
        START,
        FINISH,
    }

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.STAY;
        this.transform.position = initPosition;

    }

    private void FixedUpdate()
    {

        switch (state)
        {
            case State.STAY:
                Scroll();
                JudgePosition();
                break;
            case State.START:
                StartMove();
                break;
            case State.FINISH:
                break;
        }

    }

    void StartMove()
    {
        orbit[0] = this.transform.position;
        orbit[1] = Player.transform.position;
        orbit[2] = finishPoint;

        Sequence fadeInSequence = DOTween.Sequence();

        Sequence fadeOutSequence = DOTween.Sequence()
            .Append(this.transform.DOPath(orbit, duration: moveTime, PathType.CatmullRom));

        Sequence sequence = DOTween.Sequence()
            .Append(fadeOutSequence);

        sequence.Play();

        state = State.FINISH;

    }

    void Scroll()
    {
        this.transform.Translate(-scrollSpeed, 0, 0);
    }

    void JudgePosition()
    {
        if (this.transform.position.x <= flyXPosition)
            state = State.START;
    }
}
