using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public GameObject PlayerUI;
    private bool uiActive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerUI.SetActive(!PlayerUI.activeSelf);
            Debug.Log("UI is active");
        }
    }
}
