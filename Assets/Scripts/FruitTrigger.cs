using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitTrigger : MonoBehaviour
{
    public GameObject snake;
    public GameObject winScreenPanel;
    public float restartTime = 3f;

    float point=0f;
    System.Random rnd = new System.Random();
    
     void Start(){
      winScreenPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player" && snake.GetComponent<Crash>().die==false){
            Debug.Log("Point:"+ (point+=10f));
            ScoreBoard.scoreValue+=10;
            transform.position= new Vector3(rnd.Next(-9,9), rnd.Next(-4,4),transform.position.z);
        }

        if (ScoreBoard.scoreValue == 200){
        winScreenPanel.SetActive(true);     
        Debug.Log("YOU WIN!");
        Invoke("Restart", restartTime);
      }
       
    }

    void Restart(){
        SceneManager.LoadScene(0);
    }
}
