using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject _Destination;
    GameObject _Player;

    private void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.tag == "Player")
        {
            _Player.transform.position = _Destination.transform.TransformPoint(Vector3.right);
        }
    }
}
