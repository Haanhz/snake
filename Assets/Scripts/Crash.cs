using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    public Sprite looseSprite;
    SpriteRenderer spriteRender;
    Rigidbody2D rigid;
    public float restartTime = 3f;
    public bool die = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();

    }
    void OnCollisionEnter2D(Collision2D other) {
    {
        if (other.gameObject.tag == "wall" && die==false )
        {
            die = true;
            Debug.Log("YOU LOOSE!");
            spriteRender.sprite = looseSprite;
            rigid.gravityScale = 5f;
            Invoke("Restart", restartTime);
        }
    }
    }

    // void OnTriggerEnter2D(Collider2D other) {
    //     if (other.tag == "Player")
    //     {
    //         die = true;
    //         Debug.Log("YOU LOOSE!");
    //         spriteRender.sprite = looseSprite;
    //         rigid.gravityScale = 5f;
    //         Invoke("Restart", restartTime);
    //     }
    // }

    //p.s của tác giả: thân rắn để on collision hay on trigger thì đều làm con rắn chết tươi ngay khi nó grow
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
