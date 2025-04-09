using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public GameObject PlayerUIPrefab; // Reference to the UI prefab
    private GameObject instantiatedUI; // Reference to the instantiated UI

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
                Debug.Log("UI destroyed");
            }
        }
    }
}
