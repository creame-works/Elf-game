using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] GameObject boar;

    [SerializeField] Vector3 genPos;
    [SerializeField] float span;
    private float time;


    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= span)
        {
            time = 0;
            Instantiate(boar, genPos, Quaternion.identity);
        }
    }
}
