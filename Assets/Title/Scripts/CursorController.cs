using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{

    public Image cursor;   // カーソルのインスタンスを格納
    public int menuNum;   // メニューの数
    public float moveDistance;   // カーソルの移動幅

    private Vector3 initPos;   // カーソルの初期位置
    private Vector3 cursorPos;   // カーソルの現在位置
    private int nowSelectNum = 0;   // 現在の選択中のメニューナンバー


    void Start()
    {
        initPos = cursor.transform.position;   // カーソルの初期位置を取得
        cursorPos = initPos;
    }


    void Update()
    {
        Cursor();
    }

    private void Cursor()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            nowSelectNum++;
            cursorPos.y = initPos.y - nowSelectNum % menuNum * moveDistance;
            cursor.transform.position = cursorPos;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nowSelectNum += (menuNum - 1);
            cursorPos.y = initPos.y - nowSelectNum % menuNum * moveDistance;
            cursor.transform.position = cursorPos;
        }
    }
}
