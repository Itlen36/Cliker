using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GreenBall" && gm.play)
            gm.Lives--;
        Destroy(other.gameObject);
    }
}
