using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Tooltip("UI view at the beginning of the game.")]
    public GameObject startUI;
    [Tooltip("UI view at the ending of the game.")]
    public GameObject endUI;
    [Tooltip("UI toolbar at left of the screen.")]
    public GameObject uiPanel;
    public delegate void SpeedEvent(float newSpeed);
    public event SpeedEvent OnSpeedChange;
    public delegate void NewItemEvent(string itemName);
    public event NewItemEvent OnNewItemCollected;
    public delegate void BeginEvent();
    public event BeginEvent OnBeginEvent;
    public delegate void CheckResultEvent(bool isWon);
    public event CheckResultEvent OnCheckResultEvent;
    
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameController>();
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    private float _speed = 4f;
    public float Speed
    {
        get => _speed;
        set
        {
            if (value != this._speed)
                this.OnSpeedChange?.Invoke(value);
            _speed = value;
        }
    }
    // List of taken items
    List<string> _itemsTakenList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        // Set UI 
        this.startUI.SetActive(true);
        this.endUI.SetActive(false);
        this.uiPanel.SetActive(false);
        
        // Event Listeners
        InputController.Instance.OnStartEvent += SetGameStart;
        PlayerController.Instance.OnGameEnd += SetGameEnd;
    }

    // Add boost from item to global speed
    public void SetSpeedWithBoost(float boost)
    {
        this.Speed += boost;
    }
    
    // Add taken item to the list
    public void AddItemTaken(string itemName)
    {
        _itemsTakenList.Add(itemName);
        
        // Send event to UIPanel to update our inventory.
        this.OnNewItemCollected?.Invoke(itemName);
    }
    
    // Set UI on game start.
    private void SetGameStart()
    {
        // Show/hide UI views. 
        this.startUI.SetActive(false);
        this.uiPanel.SetActive(true);
        
        // Send event to PlayerController to launch the movement.
        this.OnBeginEvent?.Invoke();
        
        // Start running animation.
        AnimationController.Instance.ToggleAnimation("isRunning");
    }

    // Set UI on game over.
    private void SetGameEnd()
    {
        // Checking the result to see what we are going to show.
        this.CheckResult();
        
        // Stopping the running animation.
        AnimationController.Instance.ToggleAnimation("isRunning");
    }

    // Check if the player wins or loose.
    private void CheckResult()
    {
        if (_itemsTakenList.Contains("Broccoli") ||
            _itemsTakenList.Contains("Mushroom") ||
            _itemsTakenList.Count < 5)
            this.OnCheckResultEvent?.Invoke(false);
        else 
            this.OnCheckResultEvent?.Invoke(true);
        
        this.endUI.SetActive(true);
    }
}
