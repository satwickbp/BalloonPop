using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonSpawner : MonoBehaviour
{
    public float MinX,MaxX;
    public GameObject[] Balloons;
    public float MaxTime = 1;
    float CurrentTime = 0;
    public Timer t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (t.TimerValue <= 10)
        {
            MaxTime = 0.7f;
        }    
        else if(t.TimerValue <= 20)
        {
            MaxTime = 0.5f;
        }
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= MaxTime)
        { 
            CurrentTime = 0;
            Instantiate(Balloons[Random.Range(0,Balloons.Length)], 
            new Vector3(Random.Range(MinX,MaxX ),this.transform.position.y,0),Quaternion.identity);
        }
    }
}
