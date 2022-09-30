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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            this.OnJumpEvent?.Invoke();

        if (Input.GetKeyDown(KeyCode.Return))
            this.OnStartEvent?.Invoke();
    }
}
