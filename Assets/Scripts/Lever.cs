using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Lever : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Action LeverPulled;

    [SerializeField] private Text textCounter;

    [SerializeField] private Sprite downLeverSprite;
    [SerializeField] private Sprite upLeverSprite;
    private Image _currentImage;

    private Vector2 _mouseStartData;
    private Vector2 _mouseEndData;

    private bool _dragged;

    private int _timesDragged;

    //On start, this method gets the image component on the game object.
    //Then it sets the image to the lever down image.
    //Lastly, the number above the lever is set to 0.
    void Start()
    {
        _currentImage = gameObject.GetComponent<Image>();

        _currentImage.sprite = downLeverSprite;

        UpdateTextNumber();
    }

    //This updates the text above the lever based on how many times it was used.
    private void UpdateTextNumber()
    {
        textCounter.text = _timesDragged.ToString();
    }

    //When you start the drag, it gets your starting position.
    public void OnBeginDrag(PointerEventData eventData)
    {
        _mouseStartData = eventData.pressPosition;
    }

    //When you finish dragging, it gets your end position and compares it to the start.
    //If the user dragged up, then the rest of the method will execute.
    public void OnEndDrag(PointerEventData eventData)
    {
        _mouseEndData = eventData.position;

        if (!(_mouseEndData.y > _mouseStartData.y)) return;
        if (_dragged)
        {
            return;
        }

        _timesDragged++;
        UpdateTextNumber();
        LeverPulled?.Invoke();
        StartCoroutine(UpdateImage());
    }

    //This changes the lever image, then sets a delay before changing back the image, and allowing
    //the user to use the lever again.
    private IEnumerator UpdateImage()
    {
        _currentImage.sprite = upLeverSprite;

        var timer = 3;

        while (timer > 0)
        {
            _dragged = true;

            yield return new WaitForSeconds(1f);

            timer--;
        }

        _currentImage.sprite = downLeverSprite;
        _dragged = false;
    }

    //This I believe is needed for the OnBegin and OnEnd drag to fire.
    public void OnDrag(PointerEventData eventData)
    {
    }
}