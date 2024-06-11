using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public bool ChangeGravity = false;
    public int amp = 1;

    private void Update()
    {
        if (ChangeGravity)
        {
            Physics.gravity = new Vector3(Mathf.Cos(Time.time) * amp, Mathf.Sin(Time.time) * amp, 0); 
        }
        else
        {
            if(Physics.gravity != -Vector3.up)
            {
                Physics.gravity = -Vector3.up;
            }
        }
    }
}
