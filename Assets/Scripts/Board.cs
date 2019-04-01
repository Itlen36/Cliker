using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Text _textLives;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GreenBall" && gm.play)
        {
            gm.Lives--;
            _textLives.text = "Lives: " + gm.Lives;
        }
        Destroy(other.gameObject);
    }
}
