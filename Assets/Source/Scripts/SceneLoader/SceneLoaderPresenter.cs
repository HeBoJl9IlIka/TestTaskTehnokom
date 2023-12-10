using Company.TestTask.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Company.TestTask.Presenter
{
    public class SceneLoaderPresenter : MonoBehaviour
    {
        public void Load(int number)
        {
            IDataKeeper<int> levelsKeeper = new LevelsKeeper();
            levelsKeeper.Save(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(number);
        }
    }
}
