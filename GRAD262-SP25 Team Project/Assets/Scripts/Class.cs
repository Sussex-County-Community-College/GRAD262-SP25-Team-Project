using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SCCC;

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
    private StatManager statManager;
    private Player player;


    public void Awake()
    {
        slash = GetComponent<SlashButton>();
        freeze = GetComponent<FreezeButton>();
        burn = GetComponent<BurnButton>();
        spin = GetComponent<SpinButton>();
        statManager = GetComponent<StatManager>();
        player = GetComponent<Player>();
   
    }


    public void UpdateClass()
{
    statManager.GetStat("CurrentClass"); // Default class

    // Determine the class based on the highest current value
    if (slash.currentSlash >= 0)
    {
        statManager.SetStat("CurrentClass", (int)ClassType.Knight, true);
        statManager.SetStat("CurrentHealth" , 20, true);

        Debug.Log("Knight");
    }
}
    
    public void UpdateFreeze()
{
    // Logic for updating freeze
    StatManager statManager = FindObjectOfType<StatManager>();
    if (statManager != null)
    if (statManager.GetStat("currentFreeze") >= 1)
    {
        // Example: Increase attack and decrease defense when freeze is active
        int currentAttack = statManager.GetStat("Attack");
        int currentDefense = statManager.GetStat("Defense");
        statManager.SetStat("Attack", currentAttack + 2, true);
        statManager.SetStat("Defense", currentDefense - 2, true);
    }
    else if (statManager.GetStat("currentFreeze") == 0)
    {
        // Example: Decrease attack and increase defense when freeze is active
        int currentAttack = statManager.GetStat("Attack");
        int currentDefense = statManager.GetStat("Defense");
        statManager.SetStat("Attack", currentAttack - 2, true);
        statManager.SetStat("Defense", currentDefense + 2, true);
    }
    else
    {
        Debug.LogError("StatManager not found in the scene.");
    }
}
}
