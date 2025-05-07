using System;
using TMPro;
using UnityEngine;
using SCCC;
using UnityEngine.UI;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using Unity.PlasticSCM.Editor.WebApi;
using JetBrains.Annotations;
/// <summary>
/// Enum representing the player's class types.
/// </summary>
public class Class : MonoBehaviour
{
    public enum ClassType
 {
    Knight,
    Warrior,
    Champion,
    FrostMage,
    FrostWizard,
    FrostMaster,
    FireMage,
    FireWizard,
    FireMaster,
    Jester,
    DualSlasher,
    SwordMaster,
    Tanker,
    FrostBlade
 }

    public ClassType classType; // The player's class type


    private SlashButton slash;
    private FreezeButton freeze;
    private BurnButton burn;
    private SpinButton spin;
    public TextMeshProUGUI classText;
    private Player player;

    private void Start()
    {
        StatManager.Instance.SetStat("CurrentHealth", 20, true);
    }

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
        if(StatManager.Instance.GetStat("currentSlash") >= 1
            && StatManager.Instance.GetStat("currentFreeze") >= 1 
            || StatManager.Instance.GetStat("currentBurn") >= 1 
            || StatManager.Instance.GetStat("currentSpin") >= 1)
        {
            CombineClass();
        }
    }

    public void UpdateClass()
    {
        //Level 1 Freeze
        if (StatManager.Instance.GetStat("currentFreeze") == 1)
        {
            classType = ClassType.FrostMage;
            StatManager.Instance.SetStat("MaxHealth", 15, true);
            StatManager.Instance.SetStat("AttackStat", 12, true);
            StatManager.Instance.SetStat("DefenseStat", 10, true);
            StatManager.Instance.SetStat("MaxMana", 15, true);
        }
        //Level 2 Freeze
        else if (StatManager.Instance.GetStat("currentFreeze") == 2)
        {
            classType = ClassType.FrostWizard;
            StatManager.Instance.SetStat("MaxHealth", 20, true);
            StatManager.Instance.SetStat("AttackStat", 15, true);
            StatManager.Instance.SetStat("DefenseStat", 12, true);
            StatManager.Instance.SetStat("MaxMana", 15, true);
        }
        //Level 3 Freeze
        else if (StatManager.Instance.GetStat("currentFreeze") == 3)
        {
            classType = ClassType.FrostMaster;
            StatManager.Instance.SetStat("MaxHealth", 25, true);
            StatManager.Instance.SetStat("AttackStat", 20, true);
            StatManager.Instance.SetStat("DefenseStat", 15, true);
            StatManager.Instance.SetStat("MaxMana", 15, true);
        }
        else if (StatManager.Instance.GetStat("currentBurn") == 1)
        {
            classType = ClassType.FireMage;
            StatManager.Instance.SetStat("MaxHealth", 15, true);
            StatManager.Instance.SetStat("AttackStat", 15, true);
            StatManager.Instance.SetStat("DefenseStat", 10, true);
            StatManager.Instance.SetStat("MaxMana", 15, true);
        }
        else if (StatManager.Instance.GetStat("currentBurn") == 2)
        {
            classType = ClassType.FireWizard;
            StatManager.Instance.SetStat("MaxHealth", 18, true);
            StatManager.Instance.SetStat("AttackStat", 20, true);
            StatManager.Instance.SetStat("DefenseStat", 12, true);
            StatManager.Instance.SetStat("MaxMana", 18, true);
        }
        else if (StatManager.Instance.GetStat("currentBurn") == 3)
        {
            classType = ClassType.FireMaster;
            StatManager.Instance.SetStat("MaxHealth", 25, true);
            StatManager.Instance.SetStat("AttackStat", 20, true);
            StatManager.Instance.SetStat("DefenseStat", 15, true);
            StatManager.Instance.SetStat("MaxMana", 22, true);
        }

        else if (StatManager.Instance.GetStat("currentSpin") == 1)
        {
            classType = ClassType.Jester;
            StatManager.Instance.SetStat("MaxHealth", 10, true);
            StatManager.Instance.SetStat("AttackStat", 10, true);
            StatManager.Instance.SetStat("DefenseStat", 10, true);
            StatManager.Instance.SetStat("MaxMana", 0, true);
        }
        else if (StatManager.Instance.GetStat("currentSpin") == 2)
        {
            classType = ClassType.DualSlasher;
            StatManager.Instance.SetStat("MaxHealth", 12, true);
            StatManager.Instance.SetStat("AttackStat", 12, true);
            StatManager.Instance.SetStat("DefenseStat", 12, true);
            StatManager.Instance.SetStat("MaxMana", 0, true);
        }
        else if (StatManager.Instance.GetStat("currentSpin") == 3)
        {
            classType = ClassType.SwordMaster;
            StatManager.Instance.SetStat("MaxHealth", 16, true);
            StatManager.Instance.SetStat("AttackStat", 18, true);
            StatManager.Instance.SetStat("DefenseStat", 14, true);
            StatManager.Instance.SetStat("MaxMana", 0, true);
        }

        else if (StatManager.Instance.GetStat("currentSlash") == 0)
        {
            classType = ClassType.Knight;
            StatManager.Instance.SetStat("MaxHealth", 20, true);
            StatManager.Instance.SetStat("AttackStat", 10, true);
            StatManager.Instance.SetStat("DefenseStat", 10, true);
            StatManager.Instance.SetStat("MaxMana", 0, true);
        }
        else if (StatManager.Instance.GetStat("currentSlash") == 1)
        {
            classType = ClassType.Knight;
            StatManager.Instance.SetStat("MaxHealth", 24, true);
            StatManager.Instance.SetStat("AttackStat", 15, true);
            StatManager.Instance.SetStat("DefenseStat", 12, true);
            StatManager.Instance.SetStat("MaxMana", 0, true);
        }
        else if (StatManager.Instance.GetStat("currentSlash") == 2)
        {
            classType = ClassType.Warrior;
            StatManager.Instance.SetStat("MaxHealth", 26, true);
            StatManager.Instance.SetStat("AttackStat", 20, true);
            StatManager.Instance.SetStat("DefenseStat", 18, true);
            StatManager.Instance.SetStat("MaxMana", 0, true);
        }
        else if (StatManager.Instance.GetStat("currentSlash") == 3)
        {
            classType = ClassType.Champion;
            StatManager.Instance.SetStat("MaxHealth", 30, true);
            StatManager.Instance.SetStat("AttackStat", 25, true);
            StatManager.Instance.SetStat("DefenseStat", 22, true);
            StatManager.Instance.SetStat("MaxMana", 0, true);
        }
    }


    //Combination Classes (Level 1)
    public void CombineClass()
    {
    if (StatManager.Instance.GetStat("currentSlash") == 1 && StatManager.Instance.GetStat("currentFreeze") == 1)
        {
            classType = ClassType.Tanker;
            StatManager.Instance.SetStat("MaxHealth", 30, true);
            StatManager.Instance.SetStat("AttackStat", 20, true);
            StatManager.Instance.SetStat("DefenseStat", 18, true);
            StatManager.Instance.SetStat("MaxMana", 15, true);
        }
    else if (StatManager.Instance.GetStat("currentSlash") == 1 && StatManager.Instance.GetStat("currentFreeze") == 2)
        {
            classType = ClassType.FrostBlade;
            StatManager.Instance.SetStat("MaxHealth", 33, true);
            StatManager.Instance.SetStat("AttackStat", 24, true);
            StatManager.Instance.SetStat("DefenseStat", 20, true);
            StatManager.Instance.SetStat("MaxMana", 18, true);
        }


    
        if(StatManager.Instance.GetStat("CurrentHealth") > StatManager.Instance.GetStat("MaxHealth"))
        {
            StatManager.Instance.SetStat("CurrentHealth", StatManager.Instance.GetStat("MaxHealth"));
        }
    }

}
