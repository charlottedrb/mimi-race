using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public delegate void SpeedEvent(float newSpeed);
    public event SpeedEvent OnSpeedChange;
    
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

    private float _speed = 0.1f;
    public float Speed
    {
        get => _speed;
        set
        {
            if (this.OnSpeedChange != null && value != this._speed)
                this.OnSpeedChange.Invoke(value);
            _speed = value;
            Debug.Log("new speed : " + value);
        }
    }
    
    List<string> _itemsTakenList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeedWithBoost(float boost)
    {
        this.Speed += boost;
    }
    
    public void AddItemTaken(string itemName)
    {
        _itemsTakenList.Add(itemName);
        // Debug.Log("LIST : " + _itemsTakenList);
        Debug.Log("One more to the list");
    }
}
