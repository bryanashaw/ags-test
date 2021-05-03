using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private bool _isRotating;

    private bool _isClockwise;

    private float _rotationZ;

    private float rotationSpeed = 90;

    private void OnEnable()
    {
        ActivateButton.ActivateRotation += EnableRotation;
        Lever.LeverPulled += ChangeRotation;
    }

    private void OnDisable()
    {
        ActivateButton.ActivateRotation -= EnableRotation;
        Lever.LeverPulled -= ChangeRotation;
    }

    //This changes whether the object is rotating or not
    private void EnableRotation()
    {
        _isRotating = !_isRotating;
    }

    //This changes the rotation of the object (clockwise or counterclockwise)
    private void ChangeRotation()
    {
        _isClockwise = !_isClockwise;
    }

    //This method checks if the object is rotating, if it isn't, then the rest of the code isn't executed.
    //If the object is rotating it checks which direction and rotates based on that.
    void Update()
    {
        if (!_isRotating) return;

        if (_isClockwise)
        {
            _rotationZ -= Time.deltaTime * rotationSpeed;
        }
        else
        {
            _rotationZ += Time.deltaTime * rotationSpeed;
        }

        transform.eulerAngles = Vector3.forward * _rotationZ;
    }
}