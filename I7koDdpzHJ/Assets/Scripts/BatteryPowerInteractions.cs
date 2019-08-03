﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPowerInteractions : MonoBehaviour
{
    [SerializeField] private float power, maxPower, powerRechargeAmount, powerRechargeRate, powerTransferRate;
    private GameObject connectedTo;

    private void Start()
    {
        power = maxPower * 0.5f;
    }

    private void Update()
    {
        if(connectedTo.tag.Equals("BatteryStation"))
        {
            Invoke("charge", powerRechargeRate);
        }
    }

    private void changePower(float amount)
    {
        power += amount;
    }

    public void setPower(float amount)
    {
        power = amount;
    }
    
    public float getPower() { return power; }

    public ResourceSystem getConnectedMachine()
    {
        return new ResourceSystem();
        return null;
    }

    public bool charge()
    {
        if (power < maxPower)
        {
            power += powerRechargeRate;
            return true;
        }
        return false;
    }

    public float drainPower()
    {
        if(power > 0.0f)
        {
            power -= powerTransferRate;
            return powerTransferRate;
        }
        return 0;
    }

    public bool batteryConnected()
    {
        return connectedTo != null;
    }

}
