using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class SampleTexture : MonoBehaviour {
    public Texture2D noiseTex;  
    public Vector2 uv = new Vector2(0.25f, 0.75f);
    
    void Start() {
        if (noiseTex == null) {
            Debug.LogError("Please assign a noise texture!");
            return;
        }

        
        Color c = noiseTex.GetPixelBilinear(uv.x, uv.y);

        
        Debug.Log($"Sample at {uv}: color={c}, gray={c.r}");
    }
}
public class FloatAndMove : MonoBehaviour {
    // Water wave parameters (must match shader)
    public float speed = 0.796f;
    public float amount = 0.608f;
    public float heightA = 0.395f;

    public Color c;

    // Movement parameters
    public float moveSpeed = 5f;   // movement speed along X/Z plane
    public float initialHeight;
    
    float WaterHeightAt(float x, float z, float t) {
        // Simple placeholder: match your shader math here
        
       //worldPosition.y += sin(_Time.y * 2 * _Speed + (worldPosition.x * worldPosition.z * _Amount * tex)) * _Height;//movement
        
        return   Mathf.Sin(t * 2f * speed + (x * z * amount * c.a)) * heightA;
    }
    void Start() {
        initialHeight = transform.position.y;
    }
    void Update() {
        // --- WASD input ---
        float h = Input.GetAxis("Horizontal"); // A,D or Left,Right
        float v = Input.GetAxis("Vertical");   // W,S or Up,Down

        Vector3 pos = transform.position;
        pos += new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;

        // --- Snap to water surface ---
        float t = Time.time;
        pos.y = initialHeight + WaterHeightAt(pos.x, pos.z, t);

        transform.position = pos;
    }
}