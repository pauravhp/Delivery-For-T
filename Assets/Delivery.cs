using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer; 

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [SerializeField] float delayDestroy = 0.25f;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("MOVE OUT OF THE WAY!");
    }
 
    void OnTriggerEnter2D(Collider2D other) {
        //If the thing that is triggered is a package
        if (other.tag == "Food" && !hasPackage){
            hasPackage = true;
            Destroy(other.gameObject, delayDestroy);
            spriteRenderer.color = hasPackageColor;
            Debug.Log("FOOD!!");
        }
        if (other.tag == "Customer" && hasPackage){
            hasPackage = false; 
            spriteRenderer.color = noPackageColor;
            Debug.Log("Got the Food, Thank you!");
        }
    }
}
