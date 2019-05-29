using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutoria : MonoBehaviour
{
#pragma warning disable 649
    enum STATE
    {
        A,B_1,B_2,C,D
    }
    private STATE SceneState = STATE.A;

    public GameObject player;
    private TutorialPlayer playerScript;

    // パートAで使うものs
    public Image Back;
    private float time = 0;
    public float startTime;
    public Text[] texts = new Text[4];
    private int nowNum = 0;
    private bool A_actived = false;

    // パートBで使うものs
    public GameObject stageTitle;
    public GameObject[] InputExplanation = new GameObject[2];
    private bool a = false;
    public GameObject ToNextEnter;


    // パートCで使うものs
    public CameraShake shake;
    public GameObject boar;
    [SerializeField] Vector3 boarGenPos;
    public Text[] texts2 = new Text[3];
    private bool C_actived = false;
    private GameObject go;

    void Start()
    {
        playerScript = player.GetComponent<TutorialPlayer>();
        Invoke("HitorigotoStart", startTime);
    }
    
    void Update()
    {
        switch (SceneState)
        {
            case STATE.A:
                Hitorigoto();
                break;

            case STATE.B_1:
                stageTitle.SetActive(true);
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    ToNextEnter.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.Return) && a)
                {
                    InputExplanation[0].SetActive(false);
                    InputExplanation[1].SetActive(true);
                    playerScript.SetState(2);
                    ToNextEnter.SetActive(false);
                    SceneState = STATE.B_2;
                }

                break;

            case STATE.B_2:
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Space))
                {
                    ToNextEnter.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Return) && a)
                {
                    FinishExplanation();
                    
                }
                    break;
            case STATE.C:
                if (!C_actived)
                {
                    if(go.transform.position.x <= -10f)
                    {
                        Hitorigoto2Start();
                    }
                }
                
                Hitorigoto2();
                break;
        }
        
    }

    void Hitorigoto()
    {
        
        if (A_actived)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextText();
            }
        }

    }

    void HitorigotoStart()
    {
        Back.gameObject.SetActive(true);
        texts[0].gameObject.SetActive(true);
        A_actived = true;
    }

    void TutorialStart()
    {
        
        InputExplanation[0].SetActive(true);
        playerScript.SetState(1);
        a = true;
        
    }

    void NextText()
    {
        if (nowNum == 3)
        {
            FinishText();
        }
        if (nowNum != 3)
        {
            texts[nowNum].gameObject.SetActive(false);
            nowNum++;
            texts[nowNum].gameObject.SetActive(true);
        }
    }

    private void TimeCount()
    {
        time += Time.deltaTime;
    }

    private void FinishText()
    {
        texts[nowNum].gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
        time = 0;
        SceneState = STATE.B_1;
        Invoke("TutorialStart", startTime);

    }

    private void FinishExplanation()
    {
        playerScript.SetState(0);
        SceneState = STATE.C;
        InputExplanation[1].SetActive(false);
        ToNextEnter.SetActive(false);
        Invoke("CallShakeMethod", 2f);
        Invoke("GenerateBoar", 4f);
    }

    private void CallShakeMethod()
    {
        shake.Shake(0.25f, 0.1f);
    }

    private void GenerateBoar()
    {
        go = Instantiate(boar, boarGenPos, Quaternion.identity);
    }

    void Hitorigoto2Start()
    {
        Back.gameObject.SetActive(true);
        texts2[0].gameObject.SetActive(true);
        C_actived = true;
        nowNum = 0;
    }

    void Hitorigoto2()
    {

        if (C_actived)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextText2();
            }
        }

    }

    void NextText2()
    {
        if (nowNum == 2)
        {
            FinishText2();
        }
        if (nowNum != 2)
        {
            texts2[nowNum].gameObject.SetActive(false);
            nowNum++;
            texts2[nowNum].gameObject.SetActive(true);
        }
    }

    private void FinishText2()
    {
        texts2[nowNum].gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
        time = 0;
        SceneManager.LoadScene("MainScene");
    }
}
