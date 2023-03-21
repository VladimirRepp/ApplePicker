using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    private ApplePicker applePicker;

    private void Start()
    {
        applePicker = Camera.main.GetComponent<ApplePicker>();
    }

    void Update()
    {
        if(transform.position.y < bottomY)
        {
            Destroy(this.gameObject);           
            applePicker.AppleDestroyed();
        }
    }
}
