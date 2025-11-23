using Unity.VisualScripting;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;

    PlayerController player;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            player.ActivatePowerup(powerup);
            spriteRenderer.enabled = false;

        }

    }
}
