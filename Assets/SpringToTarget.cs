using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpringToTarget : MonoBehaviour
{
    public Texture2D noiseTex;
    public Material waterMaterial;
    public float waveSpeed = 0.796f;
    public float waveAmount = 0.608f;
    public float waveHeight = 0.2f;
    public Transform target;
    public SimpleSpring spring;

    float WaterHeightAt(float x, float z, float t) {
        
        Vector2 uv = (new Vector2(x, z)) * -0.1f + Vector2.one * 0.5f;
        float noiseSample = SampleNoiseTexture(uv * 0.4f); 
        return Mathf.Sin(t * 2f * waveSpeed + (x * z * waveAmount * noiseSample)) * waveHeight;
    }
    float SampleNoiseTexture(Vector2 uv) {
        Color c = noiseTex.GetPixelBilinear(uv.x, uv.y);
        Debug.Log($"color={c.r}");
        return c.r;
    }
    private void Start()
    {
        //set spring initial state
        spring.currentPosition = transform.position.y;
    }

    private void Update() {
        // //update spring params
        // spring.targetPosition = WaterHeightAt;
        //
        // //simulate spring 
        // spring.Simulate(Time.deltaTime);
        //
        // //apply simulation result
        // transform.position = new Vector3(transform.position.x, spring.currentPosition, transform.position.z);
    }
}
