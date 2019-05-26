using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] float clearDistance;
    [SerializeField] float addValue;
    private float disCount = 0;


    public Image barPoint;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = barPoint.GetComponent<RectTransform>();
    }

    void Update()
    {
        CountDistance();
        BarPoint();
        JudgeClear();
    }

    private void CountDistance()
    {
        disCount += addValue;
    }

    private void JudgeClear()
    {
        if(disCount >= clearDistance)
        {
            SceneManager.LoadScene("Clear");
        }
    }
    

    void BarPoint()
    {
        rectTransform.position += new Vector3(200f / (clearDistance / addValue), 0, 0);
        
    }
}
