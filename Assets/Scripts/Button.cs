using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject snake;
    public Sprite pauseButton;
    public Sprite playButton;
    SpriteRenderer spriteRender;
    Crash snakeStatus;
    // public Color32 playbutton = new Color32(1,1,1,1);
    // public Color32 pausebutton = new Color32(1,1,1,1);
    public bool play = false;

    void Start()
    {
       spriteRender = GetComponent<SpriteRenderer>();
       snakeStatus= snake.GetComponent<Crash>();
       Time.timeScale=0f;

    }

    void Update()
    {   
        if(Input.GetKey(KeyCode.Z) && play==false && snakeStatus.die==false){
            play=true;
            //spriteRender.color= playbutton;
            spriteRender.sprite=pauseButton;
            Time.timeScale=1f;
            
        }
        else if(Input.GetKey(KeyCode.X) && play==true && snakeStatus.die==false){
            play=false;
            //spriteRender.color= pausebutton;
            spriteRender.sprite=playButton;
            Time.timeScale=0f;
        }
    }
}
