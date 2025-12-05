using UnityEngine;

public class FrictionEffect : MonoBehaviour
{

    [SerializeField] ParticleSystem frictionParticles;

    void playFrictionEffect()
    {
        frictionParticles.Play();
    }

    void stopFrictionEffect()
    {
        frictionParticles.Stop();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        Invoke("playFrictionEffect", 0.5f);

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Invoke("stopFrictionEffect", 0.5f);
    }
}
