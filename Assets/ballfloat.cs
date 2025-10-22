using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballfloat : MonoBehaviour
{
    public Texture2D noiseTex;
    public Material waterMaterial;
    // Water wave parameters (must match shader)
    public float waveSpeed = 0.796f;
    public float waveAmount = 0.608f;
    public float waveHeight = 0.2f;
    public float initialHeight;
    float WaterHeightAt(float x, float z, float t) {
        // Simple placeholder: match your shader math here

        Vector2 uv = (new Vector2(x, z)) * -0.1f + Vector2.one * 0.5f;
        float noiseSample = SampleNoiseTexture(uv * 0.4f); //这里加的0.4纯为了调效果
        //REFERENCE: worldPosition.y += sin(_Time.y*2 * _Speed + (worldPosition.x * worldPosition.z * _Amount * Tex)) * _Height;//movement
        return Mathf.Sin(t * 2f * waveSpeed + (x * z * waveAmount * noiseSample)) * waveHeight;
    }
    float SampleNoiseTexture(Vector2 uv) {
        Color c = noiseTex.GetPixelBilinear(uv.x, uv.y);
        Debug.Log($"color={c.r}");
        return c.r;
    }
    void Start()
    {
        initialHeight = transform.position.y;

    }

   
    void Update()
    {
        
        Vector3 pos = gameObject.GetComponent<Rigidbody>().position;
        float t = Time.time;
        waterMaterial.SetFloat("_Time", t);
        pos.y = initialHeight + WaterHeightAt(pos.x, pos.z, t);
        gameObject.GetComponent<Rigidbody>().position = pos;
    }
}
