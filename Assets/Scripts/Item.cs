using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemPreset Preset;
    public MeshRenderer BodyMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        if (this.BodyMesh != null)
            this.BodyMesh.material = this.Preset.ItemMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        this.Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        this.Disapear();
        this.transform.GetComponent<MeshCollider>().isTrigger = false;
    }

    void Rotate()
    {
        float angle = 20;
        float dt = Time.deltaTime;
        angle *= dt;
        this.transform.Rotate(Vector3.up, angle, Space.Self);
    }

    void Disapear()
    {
        if (this.BodyMesh != null)
            this.BodyMesh.enabled = false;
    }
}
