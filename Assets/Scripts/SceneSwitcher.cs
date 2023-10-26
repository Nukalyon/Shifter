using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScenes(int sceneIndex)
    {
        GameManager.instance.GoToScene(sceneIndex);
    }
}
