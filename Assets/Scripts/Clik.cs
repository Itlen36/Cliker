using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clik : MonoBehaviour
{
    public GameManager gm;
    public Text textScore;
    public Text textLives;
    public Text textCountFrost;
    public Text textCountDestroyer;
    private void OnMouseDown()
    {
        if (gm.play)
        {
            if (this.gameObject.tag == "GreenBall")
            {
                gm.Score++;
                textScore.text = "Score: " + gm.Score;
            }
            else if (this.gameObject.tag == "RedBall")
            {
                gm.Lives--;
                textLives.text = "Lives: " + gm.Lives;
            }
            else if (this.gameObject.tag == "FrostBall")
            {
                gm.CountFrost++;
                textCountFrost.text = gm.CountFrost.ToString();
            }
            else if (this.gameObject.tag == "Destroyer")
            {
                gm.CountDestroyer++;
                textCountDestroyer.text = gm.CountDestroyer.ToString();
            }
            else if (this.gameObject.tag == "Live")
            {
                gm.Lives++;
                textLives.text = "Lives: " + gm.Lives;
            }
        Destroy(this.gameObject);
        }
    }
}
