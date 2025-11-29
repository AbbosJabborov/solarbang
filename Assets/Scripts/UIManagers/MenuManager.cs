using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIManagers
{
    public class MenuManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D) )
            {
                SceneManager.LoadScene(sceneBuildIndex: 1);
            }
        }
    }
}
