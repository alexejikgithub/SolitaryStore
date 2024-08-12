using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D) )]
public class CursorPoint : MonoBehaviour
{
    public event Action<Collider2D> TriggerEnter;
    public event Action<Collider2D> TriggerExit;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       TriggerEnter?.Invoke(other);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        TriggerExit?.Invoke(other);
    }
}
