using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class PinkBallWASD : MonoBehaviour {
   

    // Movement parameters
    public float moveSpeed = 5f;   // movement speed along X/Z plane
    

    
   
    void Start() {
        
    }
    void Update() {
        // --- WASD input ---
        float h = Input.GetAxis("Horizontal"); // A,D or Left,Right
        float v = Input.GetAxis("Vertical");   // W,S or Up,Down

        
        //pos += new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(h, 0, v) * moveSpeed;
        
        
        
    }
}