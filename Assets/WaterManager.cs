using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class WaterManager : MonoBehaviour
{
    public Texture2D noiseTex;
    public Material waterMaterial;
    
    public float initialHeight;
    public float waveSpeed = 0.796f;
    public float waveAmount = 0.608f;
    public float waveHeight = 0.2f;
    
    public float SampleNoiseTexture(Vector2 uv) {
        Color c = noiseTex.GetPixelBilinear(uv.x, uv.y);
        //Debug.Log($"color={c.r}");
        return c.r;
    }
    
    public float WaterHeightAt(float x, float z, float t) {
        // Simple placeholder: match your shader math here

        Vector2 uv = (new Vector2(x, z)) * -0.1f + Vector2.one * 0.5f;
        float noiseSample = SampleNoiseTexture(uv * 0.4f); //
        //REFERENCE: worldPosition.y += sin(_Time.y*2 * _Speed + (worldPosition.x * worldPosition.z * _Amount * Tex)) * _Height;//movement
        float waterOffset = Mathf.Sin(t * 2f * waveSpeed + (x * z * waveAmount * noiseSample)) * waveHeight;
        return initialHeight+waterOffset;
    }
    
    void UpdateShaderParams(){
        float t = Time.time;
        waterMaterial.SetFloat("_Time", t);
        waterMaterial.SetFloat("_Height", waveHeight);
        waterMaterial.SetFloat("_Speed", waveSpeed);
        waterMaterial.SetFloat("_Amount", waveAmount);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        initialHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateShaderParams();
    }
}
