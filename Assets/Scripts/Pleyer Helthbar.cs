using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthbar : MonoBehaviour
{
    public int PHealth; 
    public Slider PHealthbar;

    private void Update()
    {        
        PHealthbar.value -= PHealth; 
    }

}