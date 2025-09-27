using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Vector2 moveVector;
    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    SurfaceEffector2D surfaceEffector2D;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }


    void Update()
    {
        RotatePlayer();
        BoostSpeed();
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
}
