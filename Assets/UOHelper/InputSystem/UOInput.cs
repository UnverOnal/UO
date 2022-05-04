using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UO.Singleton;

public static class UOInput
{
    public static bool IsPointerDown { get; set; }
    public static bool IsPointerUp { get; set; }
    public static bool IsPointerHold { get; set; }
    
    public static Vector2 Input { get; set; }
    public static Vector3 DeltaPosition => PointerPosition - PointerPreviousPosition;
    public static Vector3 PointerPreviousPosition { get; set; }
    public static Vector3 PointerPosition => UnityEngine.Input.mousePosition;
    public static Vector3 PointerDownPosition { get; set; }

    public static bool CanSwipe { get; set; }


    [RuntimeInitializeOnLoadMethod]
    private static void InitializeCalculation()
    {
        InputCalculator.instance = Singleton.GetInstance<InputCalculator>();
    }

    public static Vector2 GetDragInput(float sensitivity)
    {
        Vector2 dragInput = new Vector2();
        dragInput.x = GetDragOnSingleAxis(Vector3.right, sensitivity);
        dragInput.y = GetDragOnSingleAxis(Vector3.up, sensitivity);

        return dragInput;
    }

    private static float GetDragOnSingleAxis(Vector3 axis, float sensitivity)
    {
        float input = Vector3.Dot(axis, UOInput.DeltaPosition) * sensitivity / Screen.width;
        return input;
    }

    public static int GetSwipe(float sensitivity, bool requireRelease = true)
    {
        if (requireRelease && !CanSwipe)
            return 0;

        float input = Vector3.Dot(Vector3.right, PointerPosition - PointerDownPosition) * sensitivity / Screen.width;

        var swipeInput = (int)Mathf.Clamp(input, -1.1f, 1.1f);
        if (swipeInput != 0)
            CanSwipe = false;
        
        return swipeInput;
    }
}
