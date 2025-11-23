using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 7000f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    bool canControlPlayer = true;
    float previousRotation;
    float currentRotation;
    float totalRotation;
    int flipCount = 0;
    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    Vector2 moveVector;
    ScoreManager scoreManager;
    void Start()
    {

        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();

    }

    void Update()
    {
        if (canControlPlayer)
        {

            RotatePlayer();
            BoostPlayer();

        }
        CalculateFlips();
    }

    void RotatePlayer()
    {

        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount * Time.deltaTime);
        }
        else if (moveVector.x > 0)
        {
            myRigidbody2D.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }

    void BoostPlayer()
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

    void CalculateFlips()
    {
        currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (totalRotation >= 340 || totalRotation <= -340)
        {
            flipCount += 1;
            totalRotation = 0;
            Debug.Log(flipCount);
            scoreManager.AddScore(100);

        }
        previousRotation = currentRotation;
    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed += powerup.GetPowerupValueChange();
            boostSpeed += powerup.GetPowerupValueChange();

        }
        if (powerup.GetPowerupType() == "torque")
        {
            torqueAmount += powerup.GetPowerupValueChange();

        }
    }
}
