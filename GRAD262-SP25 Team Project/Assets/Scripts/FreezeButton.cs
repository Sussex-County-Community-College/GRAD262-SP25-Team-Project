using UnityEngine;
using UnityEngine.UI;

public class FreezeButton : MonoBehaviour
{
    public int currentFreeze = 0;
    public int maxFreeze = 4;

    public Sprite[] FreezeLevels;
    public Image FreezeLevel; // Reference to the UI Image whose sprite will change

    // once the button is pressed, the sprite will change to the next Freeze level
    public void OnButtonPress()
    {
        currentFreeze++;
        if (currentFreeze >= maxFreeze)
        {
            currentFreeze = 0;
        }
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
        FreezeLevel.sprite = FreezeLevels[0];
    }

}
