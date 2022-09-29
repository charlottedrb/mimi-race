using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemPreset : ScriptableObject
{
    [Tooltip("The sprite of the item.")]
    public Sprite ItemSprite;
    
    [Tooltip("Is the item a sweet or not ?")]
    public bool IsItemSweet;

    [Tooltip("The name of the item.")]
    public string ItemName;
}
