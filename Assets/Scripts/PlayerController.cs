using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 15f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] bool canControlPlayer = true;
    [SerializeField] ParticleSystem powerUpEffect;

    [SerializeField] int activePowerUpCount;
    float previousRotation;
    float totalRotation;
    //int flipCount;
    Vector2 moveVector;
    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] ScoreManager scoreManager;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        
    }


    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostSpeed();
            CalculateFlips();
        }
    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x < 0)
        {

            myRigidBody2D.AddTorque(torqueAmount);
        }
        else if (moveVector.x > 0)
        {
            myRigidBody2D.AddTorque(-torqueAmount);
        }
    }
    void BoostSpeed()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if (totalRotation > 340 || totalRotation < -340)
        {
            //flipCount += 1;
            scoreManager.AddScore(100);
            totalRotation = 0;

        }

        previousRotation = currentRotation;

    }

    public void ActivatePowerUp(PowerUpSO powerUp)
    {
        powerUpEffect.Play();
        activePowerUpCount += 1;

        if (powerUp.GetPowerUpType() == "speed")
        {
            baseSpeed += powerUp.GetValueChange();
            boostSpeed += powerUp.GetValueChange();
        }

        else if (powerUp.GetPowerUpType() == "torque")
        {
            torqueAmount += powerUp.GetValueChange();
        }
    }

    public void DeactivatePowerUp(PowerUpSO powerUp)
    {
        activePowerUpCount -= 1;

        if (activePowerUpCount == 0)
        {
            powerUpEffect.Stop();
        }
        if (powerUp.GetPowerUpType() == "speed")
        {
            baseSpeed -= powerUp.GetValueChange();
            boostSpeed -= powerUp.GetValueChange();
        }

        else if (powerUp.GetPowerUpType() == "torque")
        {
            torqueAmount -= powerUp.GetValueChange();
        }
    }
}
