using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScirpt : MonoBehaviour
{
    public GameObject LoadingScreen;
    public AudioSource _audioSource;
    void Start()
    {
        StartCoroutine(EndLoading());
    }

    public IEnumerator EndLoading()
    {
        GameObject Loading = GameObject.Instantiate(LoadingScreen);
        Loading.GetComponent<Animator>().Play("GameEndLoading");
        _audioSource.Play();
        yield return new WaitForSeconds(0.99f);
        Destroy(Loading);
    }

    public IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.99f);
        GameObject Loading = GameObject.Instantiate(LoadingScreen);
        Loading.GetComponent<Animator>().Play("GameLoading");
        _audioSource.Play();
        yield return new WaitForSeconds(0.99f);
        //Destroy(Loading);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
