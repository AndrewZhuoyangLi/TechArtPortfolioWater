using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ballfloat : MonoBehaviour
{
    // Water wave parameters (must match shader)
    public WaterManager watermanager;
    public SimpleSpring spring;
    public float offsetFromWater;
    
    private Rigidbody _rb;
    
    void Start()
    {
        offsetFromWater = transform.position.y - watermanager.initialHeight;
        _rb = gameObject.GetComponent<Rigidbody>();
        spring.currentPosition = transform.position.y;
    }
    void Update()
    {
        Vector3 pos = _rb.position;
        float target = offsetFromWater + watermanager.WaterHeightAt(pos.x, pos.z, Time.time);
        
        //position.y is a spring that follows the targret
        spring.currentPosition = pos.y;
        spring.targetPosition = target;
        spring.Simulate(Time.deltaTime);
        pos.y = spring.currentPosition;
        _rb.position = pos;
    }
}
