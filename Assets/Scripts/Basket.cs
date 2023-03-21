using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Settings")]
    public Text scoreText;

    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreText = scoreGO.GetComponent<Text>();
        scoreText.text = "0";
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        //mousePos2D.z to report how far away 
        //the camera is from the point mousePos3D
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            int score = int.Parse(scoreText.text);
            score += 1;
            scoreText.text = score.ToString();

            if(score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
