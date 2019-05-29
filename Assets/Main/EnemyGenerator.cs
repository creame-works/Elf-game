using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] GameObject boar;
    [SerializeField] GameObject momonga;


    [SerializeField] Vector3 boar_GenPos;
    [SerializeField] Vector3 momonga_GenPos;

    [SerializeField] float span;
    private float time = 0;
    
    void Update()
    {
        time += Time.deltaTime;
        if(time >= span)
        {
            time = 0;
            RandomGenerate();
        }
    }

    private void RandomGenerate()
    {
        int n = Random.Range(0, 2);

        switch (n) {
            case 0:
                GenerateBoar();
                break;

            case 1:
                GenerateMomonga();
                break;
        }
    }

    private void GenerateBoar()
    {
        Instantiate(boar, boar_GenPos, Quaternion.identity);
    }

    private void GenerateMomonga()
    {
        Instantiate(momonga, momonga_GenPos, Quaternion.identity);
    }
}
