using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [Tooltip("Array of images which contains the icons in the toolbar.")]
    public Image[] icons;
    
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.OnNewItemCollected += ChangeItemAlpha;
    }

    // Change the alpha of collected item's image.
    private void ChangeItemAlpha(string itemName)
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
