using System.Transactions;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3;
    public float obstacleRange = 5.0f;

    private bool _alive;
    // Start is called before the first frame update
    void Start()
    { 
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_alive){
            transform.Translate(0,0, speed*Time.deltaTime);
        }
     transform.Translate(0,0, speed * Time.deltaTime);

     Ray ray = new Ray(transform.position, transform.forward);
     RaycastHit hit;
     if(Physics.SphereCast(ray,0.75f,out hit)){
        if(hit.distance < obstacleRange){
            float angle = UnityEngine.Random.Range(-100,100); 
            transform.Rotate(0, angle,0);
        }
     }   
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
