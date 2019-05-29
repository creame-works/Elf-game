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
    public float startTime;
    public Text[] texts = new Text[4];
    private int nowNum = 0;
    private bool A_actived = false;

    // パートBで使うものs
    public GameObject stageTitle;
    public GameObject[] InputExplanation = new GameObject[2];
    private bool stageCalled = false;
    public GameObject toNextEnter;
    private bool B1_actived = false;


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
                if (!B1_actived)
                {
                    stageTitle.SetActive(true);
                    B1_actived = true;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    toNextEnter.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.Return) && stageCalled)
                {
                    InputExplanation[0].SetActive(false);
                    InputExplanation[1].SetActive(true);
                    playerScript.SetState(2);
                    toNextEnter.SetActive(false);
                    SceneState = STATE.B_2;
                }
                break;

            case STATE.B_2:
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Space))
                {
                    toNextEnter.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    FinishExplanation();
                }
                    break;
            case STATE.C:
                if (!C_actived && boar.transform.position.x <= -10f)
                {
                    Hitorigoto2Start();
                }
                
                Hitorigoto2();
                break;
        }
        
    }

    

    void HitorigotoStart()
    {
        Back.gameObject.SetActive(true);
        texts[0].gameObject.SetActive(true);
        A_actived = true;
    }

    void Hitorigoto()
    {
        if (A_actived)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextText(3);
            }
        }
    }

    void NextText(int num)
    {
        if (nowNum == num)
        {
            FinishText();
        }
        if (nowNum != num)
        {
            texts[nowNum].gameObject.SetActive(false);
            nowNum++;
            texts[nowNum].gameObject.SetActive(true);
        }
    }

    private void FinishText()
    {
        texts[nowNum].gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
        SceneState = STATE.B_1;
        Invoke("TutorialStart", 5);
    }

    void TutorialStart()
    {
        InputExplanation[0].SetActive(true);
        playerScript.SetState(1);
        stageCalled = true;
    }
    
    private void FinishExplanation()
    {
        playerScript.SetState(0);
        SceneState = STATE.C;
        InputExplanation[1].SetActive(false);
        toNextEnter.SetActive(false);
        Invoke("CallShakeMethod", 2f);
        Invoke("GenerateBoar", 4f);
    }

    // 画面を揺らすメソッド
    private void CallShakeMethod()
    {
        shake.Shake(0.25f, 0.1f);
    }

    // イノシシを生成するメソッド
    private void GenerateBoar()
    {
        boar.SetActive(true);
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
        SceneManager.LoadScene("MainScene");
    }
}
