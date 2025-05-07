using System;
using TMPro;
using UnityEngine;
using SCCC;
using UnityEngine.UI;
/// <summary>
/// Enum representing the player's class types.
/// </summary>
public class Class : MonoBehaviour
{
    public enum ClassType
 {
    Knight,
    FrostMage,
    FireMage,
    Jester
 }

    public ClassType classType; // The player's class type


    private SlashButton slash;
    private FreezeButton freeze;
    private BurnButton burn;
    private SpinButton spin;
    public TextMeshProUGUI classText;
    private Player player;
 
 
    public void Awake()
    {
        slash = GetComponent<SlashButton>();
        freeze = GetComponent<FreezeButton>();
        burn = GetComponent<BurnButton>();
        spin = GetComponent<SpinButton>();
        player = GetComponent<Player>();
    }

    public void Update()
    {
        UpdateClass();
    }

    public void UpdateClass()
    {
        if (StatManager.Instance.GetStat("currentFreeze") == 1)
        {
            classType = ClassType.FrostMage;
            StatManager.Instance.SetStat("MaxHealth", 15, true);
            StatManager.Instance.SetStat("CurrentHealth", 15, true);
        }
        else if (StatManager.Instance.GetStat("currentBurn") == 1)
        {
            classType = ClassType.FireMage;
        }

        if (classText)
            classText.text = classType.ToString();
    }

}
