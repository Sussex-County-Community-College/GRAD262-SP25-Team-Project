using UnityEngine;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
    public int currentSpin = 0;
    public int maxSpin = 4;

    public Sprite[] SpinLevels;
    public Image SpinLevel; // Reference to the UI Image whose sprite will change

    // once the button is pressed, the sprite will change to the next Spin level
    public void OnButtonPress()
    {
        currentSpin++;
        if (currentSpin >= maxSpin)
        {
            currentSpin = 0;
        }
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
        SpinLevel.sprite = SpinLevels[0];
    }

}
