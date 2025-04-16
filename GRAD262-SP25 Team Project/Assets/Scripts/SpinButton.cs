using UnityEngine;
using UnityEngine.UI;
using SCCC;

public class SpinButton : MonoBehaviour
{
    public int currentSpin = 0;
    public int maxSpin = 4;

    public Sprite[] SpinLevels;
    public Image SpinLevel; // Reference to the UI Image whose sprite will change
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

        // Check if "currentSpin" exists in StatManager
        if (statManager.GetStat("currentSpin") >= 0)
        {
            currentSpin = statManager.GetStat("currentSpin");
        }
        else
        {
            // If no value exists, initialize it in StatManager
            statManager.SetStat("currentSpin", currentSpin, true);
        }

        // Initialize the maxSpin stat in StatManager
        statManager.SetStat("maxSpin", maxSpin, true);

        // Update the sprite to reflect the loaded value
        UpdateSprite();
    }

    public void OnButtonPress()
    {
        currentSpin++;
        if (currentSpin >= maxSpin)
        {
            currentSpin = 0;
        }

        // Save the updated value to StatManager
        statManager.SetStat("currentSpin", currentSpin, true);

        UpdateSprite();
    }

    public void OnButtonRightClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentSpin--;
            if (currentSpin < 0)
            {
                currentSpin = maxSpin - 1;
            }

            // Save the updated value to StatManager
            statManager.SetStat("currentSpin", currentSpin, true);

            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        if (SpinLevel != null)
        {
            SpinLevel.sprite = SpinLevels[currentSpin];
        }
        else
        {
            Debug.LogError("Image component is missing.");
        }
    }

    public void ResetSprite()
    {
        currentSpin = 0;

        // Save the reset value to StatManager
        statManager.SetStat("currentSpin", currentSpin, true);

        SpinLevel.sprite = SpinLevels[0];
    }
}
