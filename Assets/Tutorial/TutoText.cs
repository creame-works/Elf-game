using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoText : MonoBehaviour
{
#pragma warning disable 649
    private Text text;
    [SerializeField] float initAlpha;
    private float a;

    void Start()
    {
        a = initAlpha;
        text = GetComponent<Text>();
        text.color = new Color(255f, 255f, 255f, initAlpha);
    }

    
    void Update()
    {
        text.color = new Color(255f, 255f, 255f, a);
        a += 0.01f;
    }

}
