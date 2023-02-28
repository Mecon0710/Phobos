using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Timers;
public class animals : MovingEntity
{
    public Vector3 targetPosition;
    public Vector3 towardsTarget;
    float wanderRadius = 2f;
    
    void RecalculateTargetPosition(){
        
        targetPosition = transform.position + RandomPointInBounds(); 
    }

    void Start()
    {
        RecalculateTargetPosition();
    }

    void Update()
    {
        
        //var timer = new Timer(5000);
        towardsTarget = targetPosition - transform.position;
        MoveTowards(towardsTarget.normalized);
        if(towardsTarget.z %0.4 ==0 || towardsTarget.y %0.1 ==0 || towardsTarget.x %0.3 ==0
        ){
                        RecalculateTargetPosition();
                        Debug.Log("y"+towardsTarget.y);
                        Debug.Log("x"+towardsTarget.x);
                        Debug.Log("z"+towardsTarget.z);
        }
        // if (towardsTarget.y < 172 && towardsTarget.y > 0)

        //     if (towardsTarget.x < 20 && towardsTarget.x > -60)
        //         if (towardsTarget.z < 10 && towardsTarget.z > -5) 
        //                 //timer.Start();
        
        Debug.DrawLine(transform.position, targetPosition, Color.green );
    }

    public Vector3 RandomPointInBounds() {
        Random rnd = new Random();
        // int x = rnd.Next(-92, -76);
        // int y = rnd.Next(328, 330);
        // int z = rnd.Next(-64,-50);
        int x = rnd.Next(-2, 5);
        int y = rnd.Next(-1, 2);
        int z = rnd.Next(-2, 5);
        // Debug.Log("x"+x);
        // Debug.Log("y"+y);
        // Debug.Log("z"+z);
        return new Vector3(x, y, z);
    }
}