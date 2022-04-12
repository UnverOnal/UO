using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UO.Singleton;

public class InputCalculator : MonoBehaviour
{
    public static InputCalculator instance;

    private Vector2 pointerPosition;

    private void Awake() 
    {
        instance = Singleton.GetInstance<InputCalculator>();
    }

    private void Update() 
    {    
        UHInput.IsPointerDown = Input.GetMouseButtonDown(0);
        UHInput.IsPointerUp = Input.GetMouseButtonUp(0);
        UHInput.IsPointerHold = Input.GetMouseButton(0);

        if (UHInput.IsPointerDown)
        {
            pointerPosition = UHInput.PointerPosition;
            UHInput.PointerPreviousPosition = pointerPosition;
            UHInput.PointerDownPosition = pointerPosition;
            return;
        }

        UHInput.PointerPreviousPosition = pointerPosition;
        pointerPosition = UHInput.PointerPosition;
    }
}
