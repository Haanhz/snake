using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trigger : MonoBehaviour
{
   // public float destroyTime =2f;
    public GameObject rock;
    float point=0f;
    System.Random rnd = new System.Random();
    Rigidbody2D rigid = new Rigidbody2D();

    private void Start() {
        rigid = GetComponent<Rigidbody2D>();
        
    }
  
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="coin"){
            other.transform.position= new Vector3(rnd.Next(-9,9), rnd.Next(-4,4),other.transform.position.z);
            Debug.Log("Point:"+ (point+=10f));
            rock.transform.position= new Vector3(rnd.Next(-9,9), rnd.Next(-4,4),other.transform.position.z);

        }
        // if (other.tag=="Rock"){
        //     rigid.gravityScale=1f;
        // }
    }

    void OnCollisionEnter2D(Collision2D other) {
        rigid.gravityScale=1f;
        Debug.Log("You died!");
    }
}
