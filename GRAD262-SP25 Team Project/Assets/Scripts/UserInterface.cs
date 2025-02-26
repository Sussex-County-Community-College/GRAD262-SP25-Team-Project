using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public GameObject PlayerUI;
   
    // Start is called before the first frame update
    void Start()
    {
        PlayerUI.SetActive(false);
    }

    private void CallUI()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayerUI.SetActive(true);
            Debug.Log("UI is active");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
