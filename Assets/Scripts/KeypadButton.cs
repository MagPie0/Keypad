using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
   public int ButtonValue; //public value is pascual capitalization
   public Keypad Keypad;
   public void OnClick() //tells the keypad the button was clicked
   {
      //print("Clicked " + ButtonValue);
      Keypad.RegisterButtonClick(ButtonValue);
   }
}

/*
 * to prevent freezing from happening along a task, we use parallel processing within the thread
 * coroutines are in unity, very important in game dev
 * 
 */
