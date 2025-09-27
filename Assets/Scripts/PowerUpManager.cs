using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUpSO powerUpSO;
    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            playerController.ActivatePowerUp(powerUpSO);
        }
    }
}
