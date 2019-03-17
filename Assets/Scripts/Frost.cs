using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    private void OnMouseDown()
    {
        if (gm.play && gm.CountFrost > 0 && !gm.isFrost)
        {
            gm.CountFrost--;
            gm.isFrost = true;
            Clik[] allObj = GameObject.FindObjectsOfType<Clik>();
            foreach (Clik Obj in allObj)
                Obj.GetComponent<Rigidbody>().drag = 5;
            gm.timeFrosr = Time.time;
        }
    }
}
