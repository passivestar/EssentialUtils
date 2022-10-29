using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EssentialUtils
{
    /*
        Search for game objects in any scene or relative to any game object
        and cache the result by path. This will also return inactive objects
    */

    public static class FindOnce
    {
        static Dictionary<string, GameObject> globalPaths = new();
        static Dictionary<GameObject, Dictionary<string, GameObject>> relativePaths = new();

        public static GameObject InScene(string gameObjectPath, string sceneName = null)
        {
            sceneName ??= SceneManager.GetActiveScene().name;

            var fullPath = $"//{sceneName}/{gameObjectPath}";

            // Check the cache first
            if (globalPaths.TryGetValue(fullPath, out var foundGameObject))
            {
                return foundGameObject;
            }

            var scene = SceneManager.GetSceneByName(sceneName);

            if (scene.IsValid())
            {
                var rootGameObjects = scene.GetRootGameObjects();

                GameObject currentGameObject = null;

                var path = Regex.Split(gameObjectPath, @"\s*\/\s*");

                // Find a root game object
                foreach (var gameObject in rootGameObjects)
                {
                    if (gameObject.name == path[0])
                    {
                        currentGameObject = gameObject;
                        break;
                    }
                }

                // Find a game object in the root game object
                if (currentGameObject && path.Length > 1)
                {
                    foreach (var pathPart in path[1..])
                    {
                        currentGameObject = currentGameObject.transform.Find(pathPart)?.gameObject;
                        if (currentGameObject == null)
                        {
                            break;
                        }
                    }
                }

                if (currentGameObject != null)
                {
                    globalPaths.Add(fullPath, currentGameObject);
                    return currentGameObject;
                }
                else
                {
                    Debug.LogWarning($"GameObject \"{gameObjectPath}\" can't be found");
                }
            }

            Debug.LogWarning($"Scene \"{sceneName}\" can't be found");
            return null;
        }
 
        static GameObject Locally(GameObject gameObject, string gameObjectName, bool ancestor)
        {
            var fullPath = $"{(ancestor ? "^" : "")}{gameObjectName}";

            // Check the cache first
            if (relativePaths.TryGetValue(gameObject, out var paths))
            {
                if (paths.TryGetValue(gameObjectName, out var foundGameObject))
                {
                    return foundGameObject;
                }
            }

            var currentGameObject = gameObject;
            GameObject result = null;

            if (ancestor)
            {
                while (currentGameObject != null && currentGameObject.name != gameObjectName)
                {
                    currentGameObject = currentGameObject.transform.parent?.gameObject;
                    if (currentGameObject?.name == gameObjectName)
                    {
                        result = currentGameObject;
                        break;
                    }
                }
            }
            else
            {
                result = gameObject.transform.Find(gameObjectName)?.gameObject;
            }

            if (result != null)
            {
                if (paths == null)
                {
                    paths = new Dictionary<string, GameObject>();
                    relativePaths.Add(gameObject, paths);
                }
                paths.Add(gameObjectName, result);
                return result;
            }
            else
            {
                Debug.LogWarning($"GameObject \"{gameObjectName}\" can't be found");
            }
            return null;
        }

        public static GameObject InChildren(GameObject gameObject, string gameObjectPath)
        {
            return Locally(gameObject, gameObjectPath, false);
        }

        public static GameObject InAncestors(GameObject gameObject, string gameObjectName)
        {
            return Locally(gameObject, gameObjectName, true);
        }
    }
}