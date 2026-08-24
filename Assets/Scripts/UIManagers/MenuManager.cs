using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIManagers
{
    public class MenuManager : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }

    }
}
