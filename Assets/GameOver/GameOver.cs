using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject[] menus = new GameObject[2];   // 選択肢を格納する配列
    public int menuNum;   // メニューの数
    public float moveDistance;
    public GameObject[] checkwindows = new GameObject[2];


    public Canvas canvas;

    private int nowSelectNum = 0;   // 現在選択しているメニュー

    private bool onWindowFlg = false;   // ポップアップウィンドウが出てるかのフラグ

    public GameObject[] selectBackColor = new GameObject[2];
    

    void Update()
    {
        Shift();
        PopCheckWindow();

    }

    // 矢印上下キーを押したら選択肢が左右にずれる処理
    private void Shift()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            menus[nowSelectNum % menuNum].transform.Translate(new Vector3(-moveDistance, 0, 0));
            selectBackColor[nowSelectNum % menuNum].SetActive(false);
            nowSelectNum++;
            menus[nowSelectNum % menuNum].transform.Translate(new Vector3(moveDistance, 0, 0));
            selectBackColor[nowSelectNum % menuNum].SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            menus[nowSelectNum % menuNum].transform.Translate(new Vector3(-moveDistance, 0, 0));
            selectBackColor[nowSelectNum % menuNum].SetActive(false);
            nowSelectNum += (menuNum - 1);
            menus[nowSelectNum % menuNum].transform.Translate(new Vector3(moveDistance, 0, 0));
            selectBackColor[nowSelectNum % menuNum].SetActive(true);
            
        }
    }


    // 選択したらポップアップウィンドウが出現する処理
    private void PopCheckWindow()
    {
        if (!onWindowFlg && Input.GetKeyDown(KeyCode.Return))
        {
           
            switch (nowSelectNum % menuNum)
            {
                case 0:
                    checkwindows[0].SetActive(true);
                    SetPopupFlg(true);
                    break;
                case 1:
                    checkwindows[1].SetActive(true);
                    SetPopupFlg(true);
                    break;
                case 2:
                    checkwindows[2].SetActive(true);
                    SetPopupFlg(true);
                    break;
            }

        }
    }

    public void SetPopupFlg(bool flg)
    {
        onWindowFlg = flg;
    }


}
