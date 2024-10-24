using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject _Destination;
    GameObject _Player;
    Animator _PlayerAnimator;
    PlayerScript _PlayerScript;

    private void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _PlayerAnimator = _Player.GetComponent<Animator>();
        _PlayerScript = _Player.GetComponent<PlayerScript>();
        _Destination.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.tag == "Player")
        {
            StartCoroutine(PlayerTeleport());
        }
    }

    private IEnumerator PlayerTeleport()
    {
        _PlayerScript.playerCanMove = false;
        _PlayerAnimator.Play("PlayerTeleport");
        yield return new WaitForSeconds(0.5f);
        _Player.transform.position = _Destination.transform.TransformPoint(new Vector3(0,0,0));
        _PlayerAnimator.Play("PlayerTeleportReverse");
        yield return new WaitForSeconds(0.5f);
        _PlayerScript.playerCanMove = true;

    }
}
