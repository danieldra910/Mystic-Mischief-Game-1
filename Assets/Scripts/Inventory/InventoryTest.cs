using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryTest : MonoBehaviour
{
    public bool HasKey = false;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame) HasKey = !HasKey;
    }
}
