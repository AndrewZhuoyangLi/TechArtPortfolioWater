using UnityEngine;

[System.Serializable]
public class SimpleSpring
{
    [HideInInspector]
    public float currentPosition;   // Current position of the spring
    [HideInInspector]
    public float currentVelocity;   // Current velocity
    [HideInInspector]
    public float targetPosition;    // Desired rest position

    [Tooltip("How fast the spring moves toward the target (Hz)")]
    public float frequency;    // Frequency in Hertz — higher = snappier

    [Tooltip("How much the spring resists overshoot (1 = critically damped)")]
    [Range(0f, 2f)]
    public float dampingRatio; // 1 = no overshoot, <1 = bouncy, >1 = sluggish

    public SimpleSpring(float startPosition = 0f, float frequency = 2f, float dampingRatio = 0.5f)
    {
        this.currentPosition = startPosition;
        this.targetPosition = startPosition;
        this.frequency = frequency;
        this.dampingRatio = dampingRatio;
        this.currentVelocity = 0f;
    }

    public void Simulate(float deltaTime)
    {
        // Convert intuitive params to physical constants
        float k = Mathf.Pow(2f * Mathf.PI * frequency, 2f);  // stiffness
        float c = 2f * dampingRatio * Mathf.Sqrt(k);         // damping coefficient

        // Classic semi-implicit Euler integration
        float acceleration = -k * (currentPosition - targetPosition) - c * currentVelocity;
        currentVelocity += acceleration * deltaTime;
        currentPosition += currentVelocity * deltaTime;
    }
}