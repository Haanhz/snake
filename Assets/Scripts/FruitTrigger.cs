using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitTrigger : MonoBehaviour
{
    public GameObject snake;
    public GameObject winScreenPanel;
    public float restartTime = 3f;
    public bool fruitOut = false;
    public bool snakeGrow = false;

    float point = 0f;
    System.Random rnd = new System.Random();

    public AudioClip eatSound;
    public AudioClip winSound;

    void Start()
    {
        winScreenPanel.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && snake.GetComponent<Crash>().die == false)
        {
            Debug.Log("Point:" + (point += 10f));
            snakeGrow=true;
            GetComponent<AudioSource>().PlayOneShot(eatSound);
            ScoreBoard.scoreValue += 10;
            Transform();
        }
        else {      Invoke("Transform", 5f);}


        if (ScoreBoard.scoreValue == 200)
        {
            fruitOut=true;
            GetComponent<AudioSource>().PlayOneShot(winSound);
            winScreenPanel.SetActive(true);
            Debug.Log("YOU WIN!");
            Invoke("Restart", restartTime);
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void Transform(){
        transform.position = new Vector3(rnd.Next(-9, 9), rnd.Next(-4, 4), transform.position.z);
    }
}
