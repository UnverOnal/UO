using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UHInput
{
    public static bool IsPointerDown { get; set; }
    public static bool IsPointerUp { get; set; }
    public static bool IsPointerHold { get; set; }
    
    public static Vector2 Input { get; set; }
    public static Vector3 DeltaPosition => PointerPosition - PointerPreviousPosition;
    public static Vector3 PointerPreviousPosition { get; set; }
    public static Vector3 PointerPosition => UnityEngine.Input.mousePosition;
    public static Vector3 PointerDownPosition { get; set; }

    private static Vector2 GetDragInput(float sensitivity)
    {
        Vector2 dragInput = new Vector2();
        dragInput.x = GetDragOnSingleAxis(Vector3.right, sensitivity);
        dragInput.y = GetDragOnSingleAxis(Vector3.up, sensitivity);

        return dragInput;
    }

    private static float GetDragOnSingleAxis(Vector3 axis, float sensitivity)
    {
        float input = Vector3.Dot(axis, UHInput.DeltaPosition) * sensitivity / Screen.width;
        return input;
    }
}
