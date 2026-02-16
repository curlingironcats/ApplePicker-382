using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float     bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // get reference to the applepicker component of maincamera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // call the public AppleMissed() method of apscript
            apScript.AppleMissed();
        }
    }
}
