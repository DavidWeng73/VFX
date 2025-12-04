using UnityEngine;

public class OpacityParticlesTrigger : MonoBehaviour
{
    public Renderer targetRenderer;                
    public string opacityPropertyName = "_OpacityOffset";
    public ParticleSystem particleSystem;

    public float targetValue = 1f;                
    public float tolerance = 0.001f;                

    void Update()
    {
        if (targetRenderer == null || particleSystem == null) return;

        Material mat = targetRenderer.material;

        if (!mat.HasProperty(opacityPropertyName)) return;

        float currentValue = mat.GetFloat(opacityPropertyName);

        bool isDifferentFrom1 = Mathf.Abs(currentValue - targetValue) > tolerance;

        if (isDifferentFrom1)
        {
            if (!particleSystem.isPlaying)
                particleSystem.Play();
        }
        else
        {
            if (particleSystem.isPlaying)
                particleSystem.Stop();
        }
    }
}
