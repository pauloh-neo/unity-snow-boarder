using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUpSO powerUpSO;
    [SerializeField] bool isPowerUpActive = false;
    PlayerController playerController;
    SpriteRenderer spriteRenderer;
    float timeLeft = 0;
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerUpSO.GetTime();

    }

    void Update()
    {
        CountDownTimer();   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            spriteRenderer.enabled = false;
            playerController.ActivatePowerUp(powerUpSO);
            
        }
    }

    void CountDownTimer()
    {

        if (timeLeft > 0 && !spriteRenderer.enabled)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                playerController.DeactivatePowerUp(powerUpSO);
                print("Deactivated!");
            }
        }
    }
    
}
