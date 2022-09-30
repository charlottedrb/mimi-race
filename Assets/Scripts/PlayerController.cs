using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance = null;
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

    private int _finalPosition = 195;
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
        if(_isBegan)
            if(this.transform.localPosition.z < this._finalPosition)
                this.transform.localPosition += new Vector3(0, 0, GameController.Instance.Speed * 0.1f);
        this.transform.localPosition = new Vector3(0, this.transform.localPosition.y, this.transform.localPosition.z);
        this.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }

    public void Jump()
    {
        if (this.transform.localPosition.y < 3.5f && this.transform.localPosition.y > 0f)
            this.transform.localPosition += new Vector3(0, this.transform.localPosition.y + _jumpPosition , 0);
    }
}
