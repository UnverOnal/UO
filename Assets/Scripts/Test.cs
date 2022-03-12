using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UO.Extensions;
using UO.InputSystem;

public class Test : MonoBehaviour
{
    

    void Start()
    {
    }

    void Update()
    {
        InputData.Update();

        Vector3 targetPosition = this.transform.position + Vector3.up * InputData.input.y * 100f;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime);
    }
}
