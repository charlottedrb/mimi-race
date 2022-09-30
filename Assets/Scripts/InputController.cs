using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private static InputController _instance = null;
    public static InputController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<InputController>();
            return _instance;
        }
        private set => _instance = value;
    }
    
    public delegate void JumpEvent();
    
    public event JumpEvent OnJumpEvent;
    public delegate void StartEvent();
    
    public event StartEvent OnStartEvent;

    // Update is called once per frame
    void Update()
    {
        // Fires OnJumpEvent when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
            this.OnJumpEvent?.Invoke();

        // Fires OnStartEvent when enter is pressed
        if (Input.GetKeyDown(KeyCode.Return))
            this.OnStartEvent?.Invoke();
    }
}
