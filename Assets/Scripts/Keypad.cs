using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    private List<int> buttonsEntered;
    public KeypadBackground Background;
    private Combination combination;
    // Start is called before the first frame update
    void Start()
    {
        combination = new Combination();
        ResetButtonEnters();
    }

    public void RegisterButtonClick(int ButtonValue)
    {
        buttonsEntered.Add(ButtonValue);
        print(String.Join(", ", buttonsEntered)); //in order to print out the list
    }

    public void TryToUnlock()//always a verb
    {
        if (IsCorrectCombonation())
        {
            Unlock();
        }
        else
        {
            FailToLock();
        }

        ResetButtonEnters(); //clears the list
    }

    private bool IsCorrectCombonation()
    {
        if (HaveNoButtonsBeenClicked())
        {
            return false;
        }

        if (HaveWrongNumberOfButtonsBeenClicked())
        {
            return false;
        }
        
        return CheckCombination();
    }

    private bool HaveNoButtonsBeenClicked()
    {
        if (buttonsEntered.Count == 0)
        {
            return true;
        }

        return false;
    }

    private bool HaveWrongNumberOfButtonsBeenClicked()
    {
        if (buttonsEntered.Count == combination.GetCombinationLength())
        {
            return false;
        }

        return true;
    }
    

    private bool CheckCombination()
    {
        for (int buttonsIndex = 0; buttonsIndex < buttonsEntered.Count; buttonsIndex++)
        {
            if (IsCorrectButton(buttonsIndex) == false)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsCorrectButton(int buttonsIndex)
    {
        if (IsWrongEntry(buttonsIndex))
        {
            return false;
        }

        return true;
    }

    private bool IsWrongEntry(int buttonsIndex)
    {
        if (buttonsEntered[buttonsIndex] == combination.GetCombinationDigit(buttonsIndex))
        {
            return false;
        }

        return true;
    }
    
    private void Unlock()
    {
        Background.HideUnlockButton();
        Background.ChangeToSuccessColor();
    }

    private void FailToLock()
    {
        Background.ChangeToFailedColor();
        StartCoroutine(ResetBackgroundColor()); //runs another thread
    }

    private IEnumerator ResetBackgroundColor()
    {
        yield return new WaitForSeconds(0.25f);//wait for this amount of seconds and then go on
        Background.ChangeToDefaultColor();
    }
    
    private void ResetButtonEnters() //created because we had a duplicate code
    {
        buttonsEntered = new List<int>(); 
    }
}
