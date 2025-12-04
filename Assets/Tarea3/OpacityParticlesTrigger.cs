using UnityEngine;

public class OpacityParticlesTrigger : MonoBehaviour
{
    public Material targetMaterial;
    public string floatProperty = ("_OpacityOffset");

    [Range(-1f, 1f)]
    public float value = 1f;

    [Header("Particle Settings")]
    public ParticleSystem particleSystem;



    void Update()
    {
        targetMaterial.SetFloat(floatProperty, value);

        if (value >= 1 || value <= -1)
        {
            particleSystem.Stop();
        }
        else
        {
            particleSystem.Play();
        }
    }
}
