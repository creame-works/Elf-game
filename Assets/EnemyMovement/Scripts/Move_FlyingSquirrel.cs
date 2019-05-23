using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move_FlyingSquirrel : MonoBehaviour
{
    public Vector2 initPosition = new Vector2(11.5f, 4.5f);
    public Vector2 firstPoint = new Vector2(5, 3);
    public Vector2 middlePoint = new Vector2(0, 0);
    public Vector2 finishPoint = new Vector2(-5, 3);

    private Vector3[] orbit = new Vector3[3];

    public float appearTime = 1.0f;
    public float waitTime = 1.0f;       //最初に画面端で待っている時間
    public float moveTime = 1.0f;      //どのぐらいの時間で移動するか

    // Start is called before the first frame update
    void Start()
    {
        orbit[0] = firstPoint;
        orbit[1] = middlePoint;
        orbit[2] = finishPoint;

        Sequence fadeInSequence = DOTween.Sequence()
        .OnStart(() =>
        {
            this.transform.position = this.initPosition;
        })
        .Append(this.transform.DOMove(orbit[0], duration: appearTime));

        Sequence fadeOutSequence = DOTween.Sequence()
            .Append(this.transform.DOPath(orbit, duration: moveTime, PathType.CatmullRom));

        Sequence sequence = DOTween.Sequence()
            .Append(fadeInSequence)
            .AppendInterval(waitTime)
            .Append(fadeOutSequence);

        sequence.Play();

    }


}
