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
        targetPosition = transform.position + RandomPointInBounds()*wanderRadius;
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
        if (towardsTarget.y < 330 && towardsTarget.y > 328)
            if (towardsTarget.x < -76 && towardsTarget.x > -92)
                if (towardsTarget.z < -64 && towardsTarget.z > -50) 
                        //timer.Interval = 5000;
                        RecalculateTargetPosition();
                        //timer.Start();
        
        Debug.DrawLine(transform.position, targetPosition, Color.green );
    }

    public Vector3 RandomPointInBounds() {
        Random rnd = new Random();
        // int x = rnd.Next(-92, -76);
        // int y = rnd.Next(328, 330);
        // int z = rnd.Next(-64,-50);
        int x = rnd.Next(-34, -30);
        int y = rnd.Next(0, 1);
        int z = rnd.Next(-10,-10);
        Debug.Log("x"+x);
        Debug.Log("y"+y);
        Debug.Log("z"+z);
        return new Vector3(x, y, z);
    }
}
