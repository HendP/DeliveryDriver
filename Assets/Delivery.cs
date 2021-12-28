using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    [SerializeField]float destroyDelay = 0.5f;

    SpriteRenderer spriteRender;

    void Start() {
        spriteRender = GetComponent<SpriteRenderer>();    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRender.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer")
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRender.color = noPackageColor;
        }
    }
}
