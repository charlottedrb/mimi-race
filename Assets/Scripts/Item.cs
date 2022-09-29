using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemPreset Preset;
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetComponent<SpriteRenderer>().sprite = this.Preset.ItemSprite;
    }

    // Update is called once per frame
    void Update()
    {
        this.Rotate();
    }
    
    void Rotate()
    {
        float angle = 5;
        float dt = Time.deltaTime;
        angle *= dt;
        this.transform.Rotate(Vector3.up, angle, Space.Self);
    }

    void Disapear()
    {
        this.transform.GetComponent<MeshRenderer>().enabled = false;
    }
}
