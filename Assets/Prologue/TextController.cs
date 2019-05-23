﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{
    [SerializeField] private GameObject[] sentences = null;
    [SerializeField] private Text guideText = null;
    PrologueText prologueText;
    private List<string> sentenceList = new List<string>();
    private int index = 0;
    void Start()
    {
        prologueText = Resources.Load("PrologueData") as PrologueText;
        for(int i = 0; i < sentences.Length; i++)
        {
            sentenceList.Add(prologueText.sheets[0].list[i].sentence);
            sentences[i].GetComponent<Text>().text = sentenceList[i];
            sentences[i].SetActive(false);
        }

        sentences[0].SetActive(true);//一行目のみ表示
        sentences[0].GetComponent<TypefaceAnimator>().Play();
        guideText.text = "スペースキーで次へ";
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && index < sentenceList.Count - 1)
        {
            index++;
            if(sentenceList[index] != null)
            {
                sentences[index].SetActive(true);
                sentences[index].GetComponent<TypefaceAnimator>().Play();
            }
            if(index == sentenceList.Count - 1)//テキストが最後まできたら
            {
                guideText.text = "エンターキーで次へ";
            }
        }
        if(Input.GetKeyDown(KeyCode.Return) && index == sentenceList.Count - 1)
        {
            Debug.Log("チュートリアル画面に遷移");
        }
    }
}
