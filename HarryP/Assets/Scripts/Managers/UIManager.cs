// @Description:
// This script is responsible for all major game events, such as
// quitting the game or loading a scene whenever the Player clicks
// on a button on the XR Menu.
// OBS! No singleton is required. Just modify the XR Menu on each scene
// and the scene name on the inspector.

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project_Master.Scripts.Managers
{
    //-------------------------------------------------------------------------
    public class UIManager : MonoBehaviour
    {
        #region Private Serializable Fields

        [Header("Configuration")]
        [SerializeField] private string _menuScene = "Menu_Scene";
        [SerializeField] private string _carnivalScene = "Carnival_Scene";

        #endregion
        
        
        #region Private Methods

        //-------------------------------------------------
        private void LoadScene(string sceneName)
        {
            if (sceneName != string.Empty)
                SceneManager.LoadScene(sceneName: sceneName);
            else
                Debug.LogError("Scene Name is Empty.");
        }

        #endregion
        

        #region Public Methods

        //-------------------------------------------------
        public void OnEnterWorldClicked()
        {
            LoadScene(sceneName: _carnivalScene);
        }
        
        //-------------------------------------------------
        public void OnMenuClicked()
        {
            LoadScene(sceneName: _menuScene);
        }
        
        //-------------------------------------------------
        public void OnQuitClicked()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }

        #endregion
    }
}
