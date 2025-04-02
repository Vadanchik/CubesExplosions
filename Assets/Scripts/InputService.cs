using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public event Action ObjectClicked;

    private void OnMouseDown()
    {
        ObjectClicked?.Invoke();
    }
}
