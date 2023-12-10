using TMPro;
using UnityEngine;

namespace Company.TestTask.Presenter
{
    public class ShopSectionPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;

        public void Init(string title)
        {
            _title.text = title;
            enabled = true;
        }
    }
}
