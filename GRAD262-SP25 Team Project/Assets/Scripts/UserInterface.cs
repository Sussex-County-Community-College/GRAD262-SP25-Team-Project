using SCCC;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is the basic user interface. This UI will pause the game and can be able to switch between 3 menus, Stats, Equip, and Options.
/// </summary>
public class UserInterface : MonoBehaviour
{
    public GameObject PlayerUIPrefab; // Reference to the UI prefab
    public GameObject statScreen; // Reference to the Stat Screen Game Object
    public GameObject equipScreen; // Reference to the Equip Screen Game Object
    public GameObject Player; // Reference to the Player Game Object

     void Start()
     //get the stats from the Player Script
     {
            Player = GameObject.FindGameObjectWithTag("Player");
            if (PlayerUIPrefab == null)
            {
                Debug.LogError("PlayerUIPrefab is not assigned in the inspector.");
            }     
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerUIPrefab.SetActive(!PlayerUIPrefab.activeSelf);
            if (!PlayerUIPrefab.activeSelf)
            {
                equipScreen.SetActive(false);
                statScreen.SetActive(false);
            }
        }
    }

    public void StatScreenOn()
    {
        statScreen.SetActive(!statScreen.activeSelf);
    }

    public void EquipScreenOn()
    {
        Debug.Log("Equip Screen On");
        equipScreen.SetActive(!equipScreen.activeSelf);
    }


    public void DisplayStats()
    {
     ;
    }
}

