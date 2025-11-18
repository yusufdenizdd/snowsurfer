using UnityEngine;

public class FinishLine : MonoBehaviour
{

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
        }
    }


}

