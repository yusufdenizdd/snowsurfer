using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float invokeTime = 1f;
    void ReloadScene()
    {
        SceneManager.LoadScene(0);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag("Player"))
        // {
        //     print("bitti");
        // }

        int layerIndex = LayerMask.NameToLayer("Player"); // 6
        if (other.gameObject.layer == layerIndex)
        {
            print("çizgiyi geçtin, kazandın");
            //SceneManager.LoadScene(0);
            Invoke("ReloadScene", invokeTime);
        }

    }



}

