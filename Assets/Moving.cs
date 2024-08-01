using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed=10f;

    // Update is called once per frame
    void Update()
    {
        float moveX=Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        float moveY=Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        transform.Translate(moveX, moveY,0);

 
      
    }
}
