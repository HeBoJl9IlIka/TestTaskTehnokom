using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteAllSave : MonoBehaviour
{
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
