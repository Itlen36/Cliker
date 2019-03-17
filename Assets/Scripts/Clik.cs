using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clik : MonoBehaviour
{
    public GameManager gm;
    private void OnMouseDown()
    {
        if (gm.play)
        {
            if (this.gameObject.tag == "GreenBall")
                gm.Score++;
            else if (this.gameObject.tag == "RedBall")
                gm.Lives--;
            else if (this.gameObject.tag == "FrostBall")
                gm.CountFrost++;
            else if (this.gameObject.tag == "Destroyer")
                gm.CountDestroyer++;
            else if (this.gameObject.tag == "Live")
                gm.Lives++;
            Destroy(this.gameObject);
        }
    }
}
