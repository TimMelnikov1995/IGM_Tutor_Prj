using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tutor
{
    public class SceneLoader
    {
        public int CurrentSceneIndex
        {
            get
            {
                if (SceneManager.loadedSceneCount > 1)
                    return SceneManager.GetSceneAt(1).buildIndex;
                else
                    return 0;
            }
        }

        public static int MaximumLevel = 20;

        public event Action EOn_StartLoad;
        public event Action EOn_EndLoad;

        IEnumerator LoadAsync(string name)
        {
            if(SceneManager.loadedSceneCount > 1)
            {
                AsyncOperation unloadAync = SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1).buildIndex);
                yield return unloadAync;
            }

            EOn_StartLoad?.Invoke();

            AsyncOperation loadAync = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

            yield return loadAync;

            EOn_EndLoad?.Invoke();
        }

        IEnumerator LoadAsync(int index)
        {
            if (SceneManager.loadedSceneCount > 1)
            {
                AsyncOperation unloadAync = SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1).buildIndex);
                yield return unloadAync;
            }

            EOn_StartLoad?.Invoke();

            AsyncOperation loadAync = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            yield return loadAync;

            EOn_EndLoad?.Invoke();
        }

        IEnumerator UnloadAsync()
        {
            if (SceneManager.loadedSceneCount > 1)
            {
                AsyncOperation unloadAync = SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1).buildIndex);
                yield return unloadAync;
            }
        }

        IEnumerator RestartAsync()
        {
            if (SceneManager.loadedSceneCount > 1)
            {
                int currentIndex = SceneManager.GetSceneAt(1).buildIndex;
                AsyncOperation loadAync = SceneManager.UnloadSceneAsync(currentIndex);

                yield return loadAync;

                LoadScene(currentIndex);
            }
        }

        public void LoadScene(string name)
        {
            UpdateService.startCoroutine(LoadAsync(name));
        }

        public void LoadScene(int index)
        {
            if(index > MaximumLevel)
                index = MaximumLevel;

            UpdateService.startCoroutine(LoadAsync(index));
        }

        public void UnloadCurrentLevel()
        {
            UpdateService.startCoroutine(UnloadAsync());
        }

        public void RestartCurrentLevel()
        {
            UpdateService.startCoroutine(RestartAsync());
        }

        public void LoadNextLevel()
        {
            if(CurrentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                //Debug.Log(CurrentSceneIndex);
                //Debug.Log(SceneManager.sceneCountInBuildSettings - 1);
                UpdateService.startCoroutine(LoadAsync(CurrentSceneIndex + 1));
            }
            else
            {
                UpdateService.startCoroutine(LoadAsync(1));
            }
        }
    }
}