using UnityEngine;
using UnityEditor;
using System.Linq;
using U.Universal.Scenes;
using System.IO;

namespace U.Universal.Scenes.Editor
{
    public class TestDBMenuButton : EditorWindow
    {

        [MenuItem("Universal/Scenes/Test")]
        public static void ShowWindow()
        {

            // Check if the transition scene exists
            var findTransitionScene = File.Exists(Application.dataPath + SceneMonitor.TransitionScenePath.Remove(0, 6));
            if (!findTransitionScene) Debug.LogError("UniversalScenes: Please create a scene named _Transition in Assets/Scenes/");

            var isInBuild = EditorBuildSettings.scenes.Where(s => s.path == SceneMonitor.TransitionScenePath && s.enabled == true).FirstOrDefault() != null;
            if (!isInBuild) Debug.LogError("UniversalScenes: Assets/Scenes/_Transition scene is not in the build list or is disabled");

            if (findTransitionScene && isInBuild)
                Debug.Log("UniversalScenes: Successful test");
            else
                Debug.LogError("UniversalScenes: Failed test");

        }
    }
}