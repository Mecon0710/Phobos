using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class animals : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;

    Vector3 targetPosition;
    Vector3 towardsTarget;

    float wanderRadius = 10f;

    void RecalculateTargetPosition(){
        targetPosition = transform.position + RandomPointInBounds() * wanderRadius;
         
    }
    // Start is called before the first frame update
    void Start()
    {
        RecalculateTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        towardsTarget = targetPosition - transform.position;
        if(towardsTarget.magnitude < 0.25f)
            RecalculateTargetPosition ();
        
        Quaternion towardsTargetRotation = Quaternion.LookRotation(towardsTarget, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, towardsTargetRotation, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        
        Debug.DrawLine(transform.position, targetPosition, Color.green );
    }

    public Vector3 RandomPointInBounds() {
        Random rnd = new Random();
        int x = rnd.Next(-32, -6);
        int y = rnd.Next(158, 165);
        int z = rnd.Next(-38, 2);
        return new Vector3(x, y, z);
    }
}
