using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticles;
    [SerializeField] AudioSource collisionAudio;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float collisionCooldown = 1f;
    CinemachineImpulseSource impulseSource;

    float collisionTimer = 0f;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collisionTimer < collisionCooldown) return;

        FireImpulse();
        CollisionFX(collision);
        collisionTimer = 0f;
    }

    void FireImpulse()
    {
        float distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        float shakeIntensity = Mathf.Clamp(1 / distance * shakeModifier, 0.1f, 1f);

        impulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contact = other.contacts[0];
        
        collisionParticles.transform.position = contact.point;
        collisionParticles.Play();
        collisionAudio.Play();
        
    }
}
