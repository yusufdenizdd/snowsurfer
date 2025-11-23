using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerupSO", menuName = "Scriptable Objects/PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float time;

    public string GetPowerupType()
    {
        return powerupType;
    }

    public float GetPowerupValueChange()
    {
        return valueChange;
    }

    public float GetPowerupTime()
    {
        return time;
    }

}
