using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundScript : MonoBehaviour
{
    public PlayerScript _playerScript;
    public bool _checkGround;
    public bool _checkLeft;
    public bool _checkRight;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Ground" && _checkGround)
        {
            _playerScript.playerCanJump = true;
        }
        if (collision != null && collision.tag == "Ground" && _checkLeft)
        {
            _playerScript.playerCanGoLeft = false;
        }
        if (collision != null && collision.tag == "Ground" && _checkRight)
        {
            _playerScript.playerCanGoRight = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Ground" && _checkLeft)
        {
            _playerScript.playerCanGoLeft = true;
        }
        if (collision != null && collision.tag == "Ground" && _checkRight)
        {
            _playerScript.playerCanGoRight = true;
        }
    }
}
