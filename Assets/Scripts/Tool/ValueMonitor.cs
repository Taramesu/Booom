using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MonitorValueChange
{
    private float myValue;
    public float MyValue
    {
        get { return myValue; }
        set
        {
            if (value != myValue)
            {
                ValueChanging();
            }
            myValue = value;
        }
    }
    public delegate void MyValueChanged(object sender, EventArgs e);
    public event MyValueChanged OnValueChanged;
    private void ValueChanging()
    {
        if (OnValueChanged != null)
        {
            OnValueChanged(this, null);

        }
    }

}
