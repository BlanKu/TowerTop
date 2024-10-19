using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButoonScript : MonoBehaviour
{
    public string sceneName;
    public GameObject GameLoading;

    public void ButtonClick()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        GameObject loading = GameObject.Instantiate(GameLoading, transform.position, Quaternion.identity);
        loading.GetComponent<Animator>().Play("GameLoading");
        yield return new WaitForSeconds(0.99f);
        SceneManager.LoadScene(sceneName);

    }



}
