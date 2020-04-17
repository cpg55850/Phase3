using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public Light sunLight;

    public void Update() {
        sunLight.transform.Rotate(0.01f,0,0);
	}
    
}
