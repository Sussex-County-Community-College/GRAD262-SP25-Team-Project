using UnityEngine;
using UnityEngine.UI;
using SCCC;

public class FreezeButton : MonoBehaviour
{
    public int currentFreeze = 0;
    public int maxFreeze = 4;

    public Sprite[] FreezeLevels;
    public Image FreezeLevel; // Reference to the UI Image whose sprite will change
    private StatManager statManager;

    private void Start()
    {
        // Find the StatManager in the scene
        statManager = FindObjectOfType<StatManager>();

        if (statManager == null)
        {
            Debug.LogError("StatManager not found in the scene.");
            return;
        }

        // Check if "currentFreeze" exists in StatManager
        if (statManager.GetStat("currentFreeze") >= 0)
        {
            currentFreeze = statManager.GetStat("currentFreeze");
        }
        else
        {
            // If no value exists, initialize it in StatManager
            statManager.SetStat("currentFreeze", currentFreeze, true);
        }

        // Initialize the maxFreeze stat in StatManager
        statManager.SetStat("maxFreeze", maxFreeze, true);

        // Update the sprite to reflect the loaded value
        UpdateSprite();
    }

    public void OnButtonPress()
    {
        currentFreeze++;
        if (currentFreeze >= maxFreeze)
        {
            currentFreeze = 0;
        }

        // Save the updated value to StatManager
        statManager.SetStat("currentFreeze", currentFreeze, true);

        UpdateSprite();
    }

    public void OnButtonRightClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentFreeze--;
            if (currentFreeze < 0)
            {
                currentFreeze = maxFreeze - 1;
            }

            // Save the updated value to StatManager
            statManager.SetStat("currentFreeze", currentFreeze, true);

            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        if (FreezeLevel != null)
        {
            FreezeLevel.sprite = FreezeLevels[currentFreeze];
        }
        else
        {
            Debug.LogError("Image component is missing.");
        }
    }

    public void ResetSprite()
    {
        currentFreeze = 0;

        // Save the reset value to StatManager
        statManager.SetStat("currentFreeze", currentFreeze, true);

        FreezeLevel.sprite = FreezeLevels[0];
    }
}
