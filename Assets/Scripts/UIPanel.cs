using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameController.Instance.OnNewItemCollected += ShowItem;
    }

    public void ShowItem(string itemName)
    {
        
    }
}