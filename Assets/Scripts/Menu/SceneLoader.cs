using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Scenes
{
    MENUSCENE,
    GAMEPLAYSCENE,
    CREDITSSCENE
}
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private float loadingBarDelay;
    private IEnumerator loadScene;
    

    public void LoadScene(int levelIndex)
    {
        loadScene = WaitForLoad(levelIndex);
        StopCoroutine(loadScene);
        StartCoroutine(loadScene);
    }

    private IEnumerator WaitForLoad(int levelIndex)
    {
        yield return new WaitForSeconds(loadingBarDelay);
        StartCoroutine(LoadSceneAsynchronusly(levelIndex));
    }

    private IEnumerator LoadSceneAsynchronusly(int levelIndex)
    {
        AsyncOperation operation =  SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
}