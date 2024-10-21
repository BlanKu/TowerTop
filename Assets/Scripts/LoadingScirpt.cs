using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScirpt : MonoBehaviour
{
    public GameObject LoadingScreen;
    public AudioSource _audioSource;
    public SceneVariables _sceneVariables;

    float _timeWait = 1f;
    void Start()
    {
        StartCoroutine(EndLoading());
    }

    public IEnumerator EndLoading()
    {
        GameObject Loading = GameObject.Instantiate(LoadingScreen);
        Loading.GetComponent<Animator>().Play("GameEndLoading");
        _audioSource.Play();
        yield return new WaitForSeconds(_timeWait);
        Destroy(Loading);
    }

    public IEnumerator LoadingGameOver()
    {
        yield return new WaitForSeconds(_timeWait);
        GameObject Loading = GameObject.Instantiate(LoadingScreen);
        Loading.GetComponent<Animator>().Play("GameLoading");
        _audioSource.Play();
        yield return new WaitForSeconds(_timeWait);
        //Destroy(Loading);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator Loading()
    {
        yield return new WaitForSeconds(_timeWait);
        GameObject Loading = GameObject.Instantiate(LoadingScreen);
        Loading.GetComponent<Animator>().Play("GameLoading");
        _audioSource.Play();
        yield return new WaitForSeconds(_timeWait);
        //Destroy(Loading);
        SceneManager.LoadScene(_sceneVariables.nextLevelName);
    }
}
