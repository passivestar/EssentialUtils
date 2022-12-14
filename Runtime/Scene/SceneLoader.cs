using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EssentialUtils
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        public enum LoadingMode
        {
            ByIndex,
            ByName
        }

        public static ActivationMethod loadingScreenActivationMethod = ActivationMethod.SetActive;

        public static GameObject LoadingScreen { get; private set; }
        public static bool IsLoading { get; private set; }

        public static float DelayBeforeLoading { get; set; }
        public static float MinLoadingDuration { get; set; }

        // TODO: Handle the case with unloading a single loaded scene

        public static bool UnloadActiveSceneBeforeLoading { get; set; } = true;

        static GameObject loadingScreenCamera = null;

        static string sceneName;
        static int sceneIndex;

        public static void Load(string name)
        {
            sceneName = name;
            Coroutine.Run(StartLoading(LoadingMode.ByName));
        }

        public static void Load(int index)
        {
            sceneIndex = index;
            Coroutine.Run(StartLoading(LoadingMode.ByIndex));
        }

        static IEnumerator StartLoading(LoadingMode mode)
        {
            IsLoading = true;
            loadingScreenCamera = null;

            if (LoadingScreen != null)
            {
                loadingScreenCamera = LoadingScreen.transform.Find("Camera")?.gameObject;
                LoadingScreen.SetActive(true, loadingScreenActivationMethod);
            }

            yield return new WaitForSeconds(DelayBeforeLoading);

            if (UnloadActiveSceneBeforeLoading)
            {
                var asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                asyncUnload.completed += _ =>
                {
                    Coroutine.Run(FinishLoading(mode));
                };
            }
            else
            {
                Coroutine.Run(FinishLoading(mode));
            }
        }

        static IEnumerator FinishLoading(LoadingMode mode)
        {
            if (loadingScreenCamera != null)
            {
                loadingScreenCamera.SetActive(true);
            }

            AsyncOperation asyncLoad = null;
            if (mode == LoadingMode.ByName)
            {
                asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
            else
            {
                asyncLoad = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            }

            var routine = new Coroutine();
            asyncLoad.completed += _ => routine.Finish();

            yield return Coroutine.WhenAll(new Coroutine[]
            {
                routine,
                Coroutine.WaitForSeconds(MinLoadingDuration)
            });

            Resources.UnloadUnusedAssets();
            if (LoadingScreen != null)
            {
                LoadingScreen.SetActive(false, loadingScreenActivationMethod);
            }

            if (loadingScreenCamera != null)
            {
                loadingScreenCamera.SetActive(false);
            }

            var scene = mode == LoadingMode.ByName
                ? SceneManager.GetSceneByName(sceneName)
                : SceneManager.GetSceneByBuildIndex(sceneIndex);
            SceneManager.SetActiveScene(scene);
            IsLoading = false;
        }

        public static void SetLoadingScreen(GameObject loadingScreen)
        {
            if (LoadingScreen != null)
            {
                Destroy(LoadingScreen);
            }
            LoadingScreen = UnityEngine.Object.Instantiate(loadingScreen);
            DontDestroyOnLoad(LoadingScreen);
        }
    }
}