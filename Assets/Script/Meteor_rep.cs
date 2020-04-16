using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_rep : MonoBehaviour
{
    private GameObject[] Holder;
    public float Min, Max;
    private float distance=4f;
    private float lastMeteorX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        Holder = GameObject.FindGameObjectsWithTag("MeteorHolder");
        for (int i = 0; i < Holder.Length; i++)
        {
            Vector3 temp = Holder[i].transform.position;
            temp.y = Random.Range(Min,Max);
            Holder[i].transform.position = temp;
        }
        lastMeteorX = Holder[0].transform.position.x;
        for (int i = 1; i < Holder.Length; i++)
        {
            if (lastMeteorX<Holder[i].transform.position.x)
            {
                lastMeteorX = Holder[i].transform.position.x;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D hedef)
    {
        if (hedef.tag=="MeteorHolder")
        {
            Vector3 temp = hedef.transform.position;
            temp.x = lastMeteorX + distance;
            temp.y = Random.Range(Min, Max);
            hedef.transform.position = temp;
            lastMeteorX = temp.x; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
