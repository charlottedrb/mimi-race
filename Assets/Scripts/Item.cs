using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemPreset Preset;
    public MeshRenderer BodyMesh;
    public Light Light;
    // Has the item already been touched
    private bool _hasAlreadyTriggered = false;

    // Update is called once per frame
    void Update()
    {
        this.Rotate();
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the item hasn't been touched already
        if (_hasAlreadyTriggered == false)
        {
            // Switch state to touched
            _hasAlreadyTriggered = true;
            // It becomes invisible
            this.Disappear();
            // It can't be triggered again
            this.transform.GetComponent<MeshCollider>().isTrigger = false;
            this.SpreadTakeEvent();
            this.UseBoost();
        }
    }

    // Transfer itself to GameController to notify its taking
    private void SpreadTakeEvent()
    {
        GameController.Instance.AddItemTaken(this.Preset.ItemName);
    }

    // Constant rotation
    private void Rotate()
    {
        float angle = 20;
        float dt = Time.deltaTime;
        angle *= dt;
        this.transform.Rotate(Vector3.up, angle, Space.Self);
    }

    // We disable all visible thing
    private void Disappear()
    {
        if (this.BodyMesh != null)
            this.BodyMesh.enabled = false;
        if (this.Light != null)
            this.Light.enabled = false;
    }

    // Fires boost from item
    private void UseBoost()
    {
        GameController.Instance.SetSpeedWithBoost(this.Preset.ItemBoost);
    }
}
