using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour {
    public int itemID;
    public bool isCollectable = true;
    public float rotateSpeed = 3;
    float rotateAmount = 0;
    float originalX, originalZ;
	// Use this for initialization
	void Start () {
        var collider = gameObject.GetComponent<MeshCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();

        }
        
        collider.convex = true;
        collider.isTrigger = true;
        originalX = transform.eulerAngles.x;
        originalZ = transform.eulerAngles.z;
	}


    
	// Update is called once per frame
	void Update () {
        rotateAmount += rotateSpeed;
        transform.rotation = Quaternion.Euler(originalX, rotateAmount, originalZ);
	}
}
