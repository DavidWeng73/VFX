using UnityEngine;

public class OpacityParticlesTrigger : MonoBehaviour
{
    public Renderer targetRenderer;                 // Renderer con el material
    public string opacityPropertyName = "_OpacityOffset";
    public ParticleSystem particleSystem;

    public float targetValue = 1f;                  // Valor que apaga el sistema
    public float tolerance = 0.001f;                // Por si no llega a ser EXACTAMENTE 1

    void Update()
    {
        if (targetRenderer == null || particleSystem == null) return;

        Material mat = targetRenderer.material;

        if (!mat.HasProperty(opacityPropertyName)) return;

        float currentValue = mat.GetFloat(opacityPropertyName);

        bool isDifferentFrom1 = Mathf.Abs(currentValue - targetValue) > tolerance;

        if (isDifferentFrom1)
        {
            // Mientras sea distinto de 1 → partículas On
            if (!particleSystem.isPlaying)
                particleSystem.Play();
        }
        else
        {
            // Cuando vuelva a 1 → partículas Off
            if (particleSystem.isPlaying)
                particleSystem.Stop();
        }
    }
}
