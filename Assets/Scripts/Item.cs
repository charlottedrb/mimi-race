using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemPreset Preset;
    public MeshRenderer BodyMesh;
    private bool _hasAlreadyTriggered = false;
    
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
        if (_hasAlreadyTriggered == false)
        {
            _hasAlreadyTriggered = true;
            this.Disappear();
            this.transform.GetComponent<MeshCollider>().isTrigger = false;
            this.SpreadTakeEvent();
            this.UseBoost();
        }
    }

    private void SpreadTakeEvent()
    {
        GameController.Instance.AddItemTaken(this.Preset.ItemName);
    }

    private void Rotate()
    {
        float angle = 20;
        float dt = Time.deltaTime;
        angle *= dt;
        this.transform.Rotate(Vector3.up, angle, Space.Self);
    }

    private void Disappear()
    {
        if (this.BodyMesh != null)
            this.BodyMesh.enabled = false;
    }

    private void UseBoost()
    {
        GameController.Instance.SetSpeedWithBoost(this.Preset.ItemBoost);
    }
}
