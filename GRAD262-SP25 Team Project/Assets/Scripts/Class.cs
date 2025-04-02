using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a script that assigns a class to the player based on the number of slash, burn, freeze and spin equips they have.
/// </summary>
public enum ClassType
{
    Knight,
    FrostMage,
    FireMage,
    Jester
}
public class Class : MonoBehaviour
{
    public SlashButton slash;
    public FreezeButton freeze;
    public BurnButton burn;
    public SpinButton spin;
    public TextMeshProUGUI classText;


    public void Awake()
    {
        slash = GetComponent<SlashButton>();
        freeze = GetComponent<FreezeButton>();
        burn = GetComponent<BurnButton>();
        spin = GetComponent<SpinButton>();
    }


    public void UpdateClass()
{
    ClassType selectedClass = ClassType.Knight; // Default class

    // Determine the class based on the highest current value
    if (slash.currentSlash >= 0)
    {
        selectedClass = ClassType.Knight;
        Debug.Log("Knight");
    }
    if (freeze.currentFreeze >= 1)
    {
        selectedClass = ClassType.FrostMage;
        Debug.Log("Frost Mage");
    }
    if (burn.currentBurn >= 1)
    {
        selectedClass = ClassType.FireMage;
        Debug.Log("Fire Mage");
    }
    if (spin.currentSpin >= 1)
    {
        selectedClass = ClassType.Jester;
        Debug.Log("Jester");
    }

    // Update the class text in the UI
    classText.text = selectedClass.ToString();
}
}
