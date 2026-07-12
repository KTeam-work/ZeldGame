using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void OpenSampler()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void QuitMenu()
    {
        Application.Quit();
    }
}
