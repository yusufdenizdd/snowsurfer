using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeTime = 1f;
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layerIndex)
        {
            print("kafanı yere vurduni kaybettin");
            //SceneManager.LoadScene(0);
            Invoke("ReloadScene", invokeTime);
        }
    }
}
