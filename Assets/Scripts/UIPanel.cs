using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    private Image _candySprite;
    private Image _chocolateSprite;
    private Image _licoriceSprite;
    private Image _marshmallowSprite;
    private Image _stickSprite;

    public Image[] icons;
    
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.OnNewItemCollected += ShowItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowItem(string itemName)
    {
        foreach (var icon in icons)
        {
            if (icon.gameObject.name == itemName)
            {
                icon.color = Color.white;
            }
        }
    }
}
