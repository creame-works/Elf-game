using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    private float time = 0;
    public float span;
    public GameObject _ground;
    public Vector3 genPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if(time >= span)
        {
            time = 0;
            Instantiate(_ground,genPos,Quaternion.identity);
        }
    }

    public void Generate()
    {
        GameObject go = Instantiate(_ground, genPos, Quaternion.identity);
        
    }
}
