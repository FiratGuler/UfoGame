using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScript : MonoBehaviour
{
    private GameObject[] Background;
    private GameObject[] Ground;

    private float lastBGX;
    private float lastGroundX;

    void Awake()
    {
        Background = GameObject.FindGameObjectsWithTag("Background");
        Ground = GameObject.FindGameObjectsWithTag("Cube");

        lastBGX = Background[0].transform.position.x;
        lastGroundX = Ground[0].transform.position.x;

        for (int i = 1; i < Background.Length; i++)
        {
            if (lastBGX<Background[i].transform.position.x)
            {
                lastBGX = Background[i].transform.position.x;
            }
        }
        for (int i = 1; i < Ground.Length; i++)
        {
            if (lastGroundX < Ground[i].transform.position.x)
            {
                lastGroundX = Ground[i].transform.position.x;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.tag == "Background")
        {
            Vector3 temp = Target.transform.position;
            float width = ((BoxCollider2D)Target).size.x;
            temp.x = width + lastBGX;
            Target.transform.position = temp;
            lastBGX = temp.x;
        }
        else if (Target.tag == "Cube")
        {
            Vector3 temp = Target.transform.position;
            float width = ((BoxCollider2D)Target).size.x;
            temp.x = width + lastGroundX;
            Target.transform.position = temp;
            lastGroundX = temp.x;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
