using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitCheckWindow: MonoBehaviour
{
    // ウィンドウのサイズに関するフィールド値
    public float initSize;   // 最初のサイズ
    public float maxSize;   // Maxのサイズ
    public float expandSpeed;   // 拡大するスピード
    private float onExpandSize;   // 拡大している途中のサイズ
    private bool expandFlg = false;   // 拡大中フラグ
    private bool shrinkFlg = false;   // 縮小中フラグ

    // カーソルの移動に関するフィールド値
    private int nowSelectNum = 0;   // 現在の選択肢
    private bool cursorFlg;

    // シーン上のChoicesのインスタンスとそのスクリプト
    public GameObject _choiceis;
    private MenusController MCScript;

    // カーソルを格納する配列
    public GameObject[] _cursor = new GameObject[2];


    void Start()
    {
        onExpandSize = initSize;   // 初期サイズ
        transform.localScale = new Vector3(initSize, initSize, initSize);   // 初期サイズに変更
        MCScript = _choiceis.GetComponent<MenusController>();
    }


    void Update()
    {
        Expand();
        Cursor();
        InputEnterKey();
        Shrink();
    }

    // ウィンドウを拡大するメソッド
    private void Expand()
    {
        if (expandFlg)
        {
            onExpandSize += expandSpeed;
            transform.localScale = new Vector3(onExpandSize, onExpandSize, 1f);

            if (onExpandSize > maxSize)
            {
                expandFlg = false;
                cursorFlg = true;
            }
        }


    }

    // カーソルのコントローラー
    private void Cursor()
    {
        if (cursorFlg)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _cursor[nowSelectNum % 2].SetActive(false);
                nowSelectNum++;
                _cursor[nowSelectNum % 2].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _cursor[nowSelectNum % 2].SetActive(false);
                nowSelectNum++;
                _cursor[nowSelectNum % 2].SetActive(true);
            }
        }
    }

    // Enterキーを押したときの処理
    private void InputEnterKey()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (nowSelectNum % 2)
            {
                // はいを選択したとき
                case 0:
                    //UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit();
                    break;

                // いいえを選択したとき
                case 1:
                    shrinkFlg = true;
                    break;
            }
        }
    }

    // ウィンドウを縮小する処理
    private void Shrink()
    {
        if (shrinkFlg)
        {
            onExpandSize -= expandSpeed;
            transform.localScale = new Vector3(onExpandSize, onExpandSize, 0);

            if (onExpandSize <= initSize)
            {
                shrinkFlg = false;
                gameObject.SetActive(false);
            }
        }

    }

    // アクティブ化したとき
    void OnEnable()
    {
        expandFlg = true;
        onExpandSize = initSize;
        transform.localScale = new Vector3(initSize, initSize, initSize);
        nowSelectNum = 0;
        _cursor[0].SetActive(true);
        _cursor[1].SetActive(false);
    }

    // 非アクティブ化したとき
    void OnDisable()
    {
        MCScript.SetPopupFlg(false);
    }
}
