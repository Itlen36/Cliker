using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject ps;

    private void OnMouseDown()
    {
        if (gm.play && gm.CountDestroyer > 0 )
        {
            gm.CountDestroyer--;
            gm.isFrost = true;
            Clik[] allObj = GameObject.FindObjectsOfType<Clik>();
            foreach (Clik Obj in allObj)
            {
                GameObject _ps = Instantiate(ps, new Vector3(Obj.transform.position.x, Obj.transform.position.y, 0), Quaternion.identity);
                Destroy(Obj.gameObject);
                Destroy(_ps, 1f);
            }
        }
    }
}
