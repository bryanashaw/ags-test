using System;
using UnityEngine;
using UnityEngine.UI;

public class ActivateButton : MonoBehaviour
{
    public static Action ActivateRotation;

    [SerializeField] private Text textCounter;

    private int _timesClicked;


    //On start, the text above the button is set to 0.
    void Start()
    {
        UpdateTextNumber();
    }


    //When clicked, the number of times clicked goes up, the number above the button is updated,
    //and the object in the center is rotated.
    public void ButtonClicked()
    {
        _timesClicked++;
        UpdateTextNumber();
        ActivateRotation?.Invoke();
    }

    //This method updates the counter above the button
    private void UpdateTextNumber()
    {
        textCounter.text = _timesClicked.ToString();
    }
}