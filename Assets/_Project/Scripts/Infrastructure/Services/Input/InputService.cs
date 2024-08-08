using Assets.Scripts.Infrastructure.Services.Input;
using UnityEngine;

public class InputService : IInputService
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private Vector2 _axis;

    public Vector2 Axis
    {
        get
        {
            _axis = UnityAxis();
            return _axis;
        }
    }

    private static Vector2 UnityAxis() =>
        new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

    public Vector3? GetMouseClickPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return Input.mousePosition;
        }

        return null;
    }
}