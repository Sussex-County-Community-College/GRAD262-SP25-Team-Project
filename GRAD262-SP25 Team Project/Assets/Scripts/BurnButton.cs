using UnityEngine;
using UnityEngine.UI;
using SCCC;

public class BurnButton : MonoBehaviour
{
    public int currentBurn = 0;
    public int maxBurn = 4;

    public Sprite[] BurnLevels;
    public Image BurnLevel; // Reference to the UI Image whose sprite will change
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

        // Check if "currentBurn" exists in StatManager
        if (statManager.GetStat("currentBurn") >= 0)
        {
            currentBurn = statManager.GetStat("currentBurn");
        }
        else
        {
            // If no value exists, initialize it in StatManager
            statManager.SetStat("currentBurn", currentBurn, true);
        }

        // Initialize the maxBurn stat in StatManager
        statManager.SetStat("maxBurn", maxBurn, true);

        // Update the sprite to reflect the loaded value
        UpdateSprite();
    }

    public void OnButtonPress()
    {
        currentBurn++;
        if (currentBurn >= maxBurn)
        {
            currentBurn = 0;
        }

        // Save the updated value to StatManager
        statManager.SetStat("currentBurn", currentBurn, true);

        UpdateSprite();
    }

    public void OnButtonRightClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentBurn--;
            if (currentBurn < 0)
            {
                currentBurn = maxBurn - 1;
            }

            // Save the updated value to StatManager
            statManager.SetStat("currentBurn", currentBurn, true);

            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        if (BurnLevel != null)
        {
            BurnLevel.sprite = BurnLevels[currentBurn];
        }
        else
        {
            Debug.LogError("Image component is missing.");
        }
    }

    public void ResetSprite()
    {
        currentBurn = 0;

        // Save the reset value to StatManager
        statManager.SetStat("currentBurn", currentBurn, true);

        BurnLevel.sprite = BurnLevels[0];
    }
}
