using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public float _timeBetweenShot;
    public float _bulletSpeed;
    public GameObject _SpawnPoint;
    public GameObject _BulletPrefab;
    public Animator _CannonAnimator;

    private Vector2 _BulletVector2;
    private Vector3 _GameObjectRotation;

    private void Start()
    {
        _SpawnPoint.SetActive(false);

        if (gameObject.transform.rotation.eulerAngles.z == 0)
        {
            _BulletVector2.Set(0, -_bulletSpeed);
            Debug.Log("Bullet Vector set to: " + _BulletVector2.ToString());
        }
        else if (gameObject.transform.rotation.eulerAngles.z == 90)
        {
            _BulletVector2.Set(_bulletSpeed, 0);
            Debug.Log("Bullet Vector set to: " + _BulletVector2.ToString());
        }
        else if (gameObject.transform.rotation.eulerAngles.z == 180)
        {
            _BulletVector2.Set(0, _bulletSpeed);
            Debug.Log("Bullet Vector set to: " + _BulletVector2.ToString());
        }
        else if (gameObject.transform.rotation.eulerAngles.z == 270)
        {
            _BulletVector2.Set(-_bulletSpeed, 0);
            Debug.Log("Bullet Vector set to: " + _BulletVector2.ToString());
        }

        StartCoroutine(ShotBullet());
    }

    public IEnumerator ShotBullet()
    {
        GameObject Bullet = Instantiate(_BulletPrefab, _SpawnPoint.transform.position, gameObject.transform.rotation);
        Debug.Log("Creating Bullet");
        Bullet.GetComponent<Rigidbody2D>().velocity = _BulletVector2;
        _CannonAnimator.Play("CannonAnimation");
        yield return new WaitForSeconds(_timeBetweenShot);
        StartCoroutine(ShotBullet());
    }
}
