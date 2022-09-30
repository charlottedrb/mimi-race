using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject startUI;
    public GameObject endUI;
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
            if (this.OnSpeedChange != null && value != this._speed)
                this.OnSpeedChange.Invoke(value);
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
        Debug.Log(itemName);
        if (this.OnNewItemCollected != null)
            this.OnNewItemCollected.Invoke(itemName);
    }
    
    // Set UI on game start.
    private void SetGameStart()
    {
        this.startUI.SetActive(false);
        this.uiPanel.SetActive(true);
        this.OnBeginEvent?.Invoke();
        AnimationController.Instance.ToggleAnimation("isRunning");
    }

    // Set UI on game over.
    private void SetGameEnd()
    {
        this.CheckResult();
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
