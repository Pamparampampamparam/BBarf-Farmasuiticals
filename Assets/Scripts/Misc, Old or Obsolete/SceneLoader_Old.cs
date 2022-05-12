using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneLoader_Old : MonoBehaviour
{
    public UnityEvent onScenesLoaded;
    private Animator transitionAnimator;
    public float progress { get; private set; }

    private void Awake() {
        transitionAnimator = GetComponentInChildren<Animator>();
    }

    // Also automatically loads BaseScene
    public void LoadGameplayScene(string sceneName) {
        StartCoroutine(LoadSceneCoroutine(sceneName, true));
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneCoroutine(sceneName, false));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName, bool loadBaseScene) {
        yield return null;

        transitionAnimator.Play("Hide");
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => transitionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1);

        AsyncOperation sceneLoadOperation;

        if (loadBaseScene) {
            sceneLoadOperation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            while (!sceneLoadOperation.isDone) {
                progress = sceneLoadOperation.progress / 2;
                yield return null;
            }
        }

        sceneLoadOperation = SceneManager.LoadSceneAsync(sceneName, loadBaseScene ? LoadSceneMode.Additive : LoadSceneMode.Single);
        while (!sceneLoadOperation.isDone) {
            progress = loadBaseScene ? (sceneLoadOperation.progress + 1) / 2 : sceneLoadOperation.progress;
            yield return null;
        }

        yield return null;

        onScenesLoaded.Invoke();

        transitionAnimator.Play("Show");
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => transitionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1);
    }
}
