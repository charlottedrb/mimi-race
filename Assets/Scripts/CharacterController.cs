using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private static CharacterController _instance = null;
    public static CharacterController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<CharacterController>();
            return _instance;
        }
        private set => _instance = value;
    }

    private int _finalPosition = 70;
    private int _jumpPosition = 3;
    
    [Tooltip("Speed of the character.")]
    public float speed = 10;

    [Tooltip("Character to move.")]
    public GameObject character; 
    // Start is called before the first frame update
    void Start()
    {
        InputController.Instance.onJumpEvent += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.character.transform.localPosition.z < this._finalPosition)
            this.character.transform.localPosition += new Vector3(0, 0, this.speed * 0.1f);
    }

    public void Jump()
    {
        this.character.transform.localPosition += new Vector3(0, this.character.transform.localPosition.y + _jumpPosition , 0);
            
    }
}
