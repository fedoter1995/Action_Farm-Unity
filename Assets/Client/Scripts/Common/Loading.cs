using CustomTools;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading
{
    private const int DEFAULT_LOADING_TIME = 2;
    private string sceneName;
    private AsyncOperation loading;
    private float progress = 0;

    public event Action<float> OnFrameOverEvent;
    public int LoadingPercent => Mathf.RoundToInt(loading.progress * 100);
    public float LoadingProgress => loading.progress;
    public Loading(string SceneName)
    {
        sceneName = SceneName;
    }
    public void StartNewGame()
    {
        loading = SceneManager.LoadSceneAsync(sceneName);
        loading.allowSceneActivation = false;
        Coroutines.Start(LoadingOverRoutine());
        Coroutines.Start(LoadingRoutine());
    }
    private IEnumerator LoadingOverRoutine()
    {
        yield return new WaitForSeconds(DEFAULT_LOADING_TIME);
        loading.allowSceneActivation = true;               
    }
    private IEnumerator LoadingRoutine()
    {
        while(true)
        {
            yield return null;
            progress += 0.05f;
            OnFrameOverEvent?.Invoke(progress);
            if(progress >=1)
            {
                progress = 0;
                yield break;
            }
        }

    }
}
