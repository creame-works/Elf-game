using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{
    [SerializeField]TypefaceAnimator typefaceAnimator;    
    PrologueText prologueText;
    List<string> sentenceList = new List<string>();
    [SerializeField] private Text sentence = null;
    [SerializeField] private Text guideText = null;
    private int index = 0;
    private int maxSentence = 5;
    void Start()
    {
        guideText.text = "スペースキーで次へ";
    
        prologueText = Resources.Load("PrologueData") as PrologueText;
        for(int i = 0; i < prologueText.sheets[0].list.Count; i++)
        {
            sentenceList.Add(prologueText.sheets[0].list[i].sentence);
        }
        sentence.text = sentenceList[index];
        typefaceAnimator.Play();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && index < sentenceList.Count - 1)
        {
            index++;
            if(sentenceList[index] != null)
            {
                sentence.text = sentenceList[index];
                typefaceAnimator.Play();

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
