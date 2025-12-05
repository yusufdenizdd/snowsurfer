using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 7000f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;

    [SerializeField] ParticleSystem powerupParticle;
    [SerializeField] ScoreManager scoreManager;
    bool canControlPlayer = true;
    float previousRotation;
    float currentRotation;
    float totalRotation;
    int flipCount = 0;
    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    Vector2 moveVector;
    int activePowerupCount = 0;
    void Start()
    {

        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();


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
        powerupParticle.Play();
        activePowerupCount += 1;
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

    public void DeactivatePowerup(PowerupSO powerup)
    {
        activePowerupCount -= 1;
        if (activePowerupCount == 0)
        {
            powerupParticle.Stop();
        }
        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed -= powerup.GetPowerupValueChange();
            boostSpeed -= powerup.GetPowerupValueChange();
        }
        if (powerup.GetPowerupType() == "torque")
        {
            torqueAmount -= powerup.GetPowerupValueChange();
        }


    }
}
