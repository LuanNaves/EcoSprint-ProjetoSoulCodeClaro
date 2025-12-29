using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour {
    private CollectableManager collectableManager;
    private SfxManager sfxManager;
    void Update() {
        collectableManager = FindFirstObjectByType<CollectableManager>();
        sfxManager = FindFirstObjectByType<SfxManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CollectItem();
            Destroy(gameObject);
        }
    }

    private void CollectItem() {
        sfxManager.PlayCollectSfx();
        collectableManager.AddItem(gameObject.layer);
    }
}
