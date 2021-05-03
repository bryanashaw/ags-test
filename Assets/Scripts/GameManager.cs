using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action DisplayTryAgain;
    private int _actionCounter;
    
    private void OnEnable()
    {
        ActivateButton.ActivateRotation += IncreaseCounter;
        Lever.LeverPulled += IncreaseCounter;
    }

    private void OnDisable()
    {
        ActivateButton.ActivateRotation -= IncreaseCounter;
        Lever.LeverPulled -= IncreaseCounter;
    }

    //Whenever the activate button or lever is used, this method is called.
    
    private void IncreaseCounter()
    {
        _actionCounter++;
        ActionCounterChecker();
    }

    //This method checks if the action counter has reached or exceeded 10
    private void ActionCounterChecker()
    {
        if (_actionCounter >= 10)
        {
            //display try again screen
            DisplayTryAgain?.Invoke();
        }
    }
}