using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is the basic user interface. This UI will pause the game and can be able to switch between 3 menus, Stats, Equip, and Options.
/// </summary>
public class UserInterface : MonoBehaviour
{
    public GameObject PlayerUIPrefab; // Reference to the UI prefab
    private GameObject instantiatedUI; // Reference to the instantiated UI object
    public GameObject statScreen; // Reference to the Stat Screen Game Object
    public GameObject equipScreen; // Reference to the Equip Screen Game Object

    private bool statScreenActive = false; // Flag to check if the Stat Screen is active
    private bool equipScreenActive = false; // Flag to check if the Equip Screen is active

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (instantiatedUI == null)
            {
                // Instantiate the UI prefab if it doesn't exist
                instantiatedUI = Instantiate(PlayerUIPrefab, transform);
                Debug.Log("UI instantiated and active");
            }
            else
            {
                // Destroy the UI if it exists
                Destroy(instantiatedUI);
                ScreensOff(); // Ensure Stat and Equip screens are also deactivated
                Debug.Log("UI destroyed");
            }
        }
    }

    public void StatScreenOn()
    {
        if (!statScreenActive || equipScreenActive)
        {
            equipScreen.SetActive(false);
            equipScreenActive = false;
            Debug.Log("Equip Screen destroyed");

            // Instantiate or activate the Stat Screen
            statScreen = Instantiate(statScreen, transform);
            statScreen.SetActive(true);
            statScreenActive = true;
            Debug.Log("Stat Screen instantiated and active");
        }
    }

    public void EquipScreenOn()
    {
        if (!equipScreenActive || statScreenActive)
        {
            statScreen.SetActive(false);
            statScreenActive = false;
            Debug.Log("Stat Screen destroyed");

            // Instantiate or activate the Equip Screen
            equipScreen = Instantiate(equipScreen, transform);
            equipScreen.SetActive(true);
            equipScreenActive = true;
            Debug.Log("Equip Screen instantiated and active");
        }
    }

    public void ScreensOff()
    {
        // Deactivate or destroy the Stat and Equip screens
        if (statScreen != null)
        {
            statScreen.SetActive(false);
            statScreenActive = false;
            Debug.Log("Stat Screen destroyed");
        }

        if (equipScreen != null)
        {
            equipScreen.SetActive(false);
            equipScreenActive = false;
            Debug.Log("Equip Screen destroyed");
        }
    }
}
