using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UO.Extensions;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    private void Start() 
    {
        Debug.Log(InputManager.instance.isFingerDown);
    }
}
