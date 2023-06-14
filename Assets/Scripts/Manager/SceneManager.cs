using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    private LoadingUI loadUI;
    private BaseScene curScene;

    public BaseScene CurScene
    {
        get
        { 
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();

            return curScene;
        }
    }

    private void Awake()
    {
        LoadingUI ui = Resources.Load<LoadingUI>("UI/LoadingUI");
        loadUI = Instantiate(ui);
        loadUI.transform.SetParent(transform);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        loadUI.FadeOut();
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 0f;
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);

        while(!oper.isDone)
        {
            loadUI.SetProgress(Mathf.Lerp(0f, 0.5f, oper.progress));
            yield return null;
        }

        CurScene.LoadAsync();
            while (CurScene.progress < 1f)
            {
                loadUI.SetProgress(Mathf.Lerp(0.5f, 1.0f, CurScene.progress));
                yield return null;
            }
        

        Time.timeScale = 1f;
        loadUI.FadeIn();
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
