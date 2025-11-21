using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeTime = 1f;
    [SerializeField] ParticleSystem crashParticles;

    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerIndex)
        {
            //print("kafanı yere vurdun kaybettin");
            //SceneManager.LoadScene(0);
            crashParticles.Play();
            Invoke("ReloadScene", invokeTime);
            playerController.DisableControls();
        }
    }
}
