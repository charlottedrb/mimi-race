using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance = null;
    // Has the game started
    private bool _isBegan = false;
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<PlayerController>();
            return _instance;
        }
        private set => _instance = value;
    }

    // Position of the finish line
    private int _finalPosition = 195;
    // Height of the jump
    private int _jumpPosition = 3;

    // Start is called before the first frame update
    void Start()
    {
        InputController.Instance.OnJumpEvent += Jump;
        GameController.Instance.OnBeginEvent += () => _isBegan = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        // If the game has started
        if(_isBegan)
            // If the player hasn't reach the finish line
            if(this.transform.localPosition.z < this._finalPosition)
                // The player moves forward
                this.transform.localPosition += new Vector3(0, 0, GameController.Instance.Speed * dt);
        
        // We prevent the character from having side effects when jumping (losing right direction or rotation)
        this.transform.localPosition = new Vector3(0, this.transform.localPosition.y, this.transform.localPosition.z);
        this.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }

    public void Jump()
    {
        // If the player is not currently jumping two times in a row
        if (this.transform.localPosition.y < 3.5f && this.transform.localPosition.y > 0f)
            // He jumps
            this.transform.localPosition += new Vector3(0, this.transform.localPosition.y + _jumpPosition , 0);
    }
}
