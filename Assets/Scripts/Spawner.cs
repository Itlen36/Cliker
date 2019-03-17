using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _RedBall;
    [SerializeField] private GameObject _GreenBall;
    [SerializeField] private GameObject _FrostBall;
    [SerializeField] private GameObject _LiveBall;
    [SerializeField] private GameObject _DestroyBall;
    [SerializeField] private GameManager _gm;
    private float _dTime = 0;
    private GameObject _SpawnObject;

    // Update is called once per frame
    void Update()
    {
        if (_gm.play)
        {
            _dTime += Time.deltaTime;
            if (_dTime >= 1 - Mathf.Pow(Time.time - _gm.timeStart, 0.25f) / 5.4f)
            {
                Spawn(Random.Range(0, 100));
                _dTime = 0;
            }
        }
    }

    void Spawn(int type)
    {
        if (type < 35)
            _SpawnObject = Instantiate(_RedBall, new Vector3(Random.Range(-7, 7), 6, 0), Quaternion.identity);
        else if (type < 85)
            _SpawnObject = Instantiate(_GreenBall, new Vector3(Random.Range(-7, 7), 6, 0), Quaternion.identity);
        else if (type < 87)
            _SpawnObject = Instantiate(_LiveBall, new Vector3(Random.Range(-7, 7), 6, 0), Quaternion.identity);
        else if (type < 93)
            _SpawnObject = Instantiate(_FrostBall, new Vector3(Random.Range(-7, 7), 6, 0), Quaternion.identity);
        else
            _SpawnObject = Instantiate(_DestroyBall, new Vector3(Random.Range(-7, 7), 6, 0), Quaternion.identity);

        _SpawnObject.GetComponent<Clik>().gm = _gm;
        if (!_gm.isFrost)
            _SpawnObject.GetComponent<Rigidbody>().drag = 4.4f - Mathf.Pow(Time.time - _gm.timeStart, 0.25f);
        else
            _SpawnObject.GetComponent<Rigidbody>().drag = 5;
    }
}
