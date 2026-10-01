using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControls : MonoBehaviour
{
    public void RunGame()
    {
        SceneManager.LoadScene(3);
    }
}
