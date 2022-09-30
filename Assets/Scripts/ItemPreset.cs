using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemPreset : ScriptableObject
{
    [Tooltip("The sprite of the item.")]
    public Material ItemMaterial;

    [Tooltip("The name of the item.")]
    public string ItemName;
    
    [Tooltip("The speed boost that the item gives to the user.")]
    public float ItemBoost;
}
