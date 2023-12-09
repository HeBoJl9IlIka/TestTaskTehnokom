using Company.TestTask.Model;
using Company.TestTask.Presenter;
using UnityEngine;

namespace Company.TestTask.Factory
{
    public class SliderFactory : MonoBehaviour
    {
        [SerializeField] private DaysProgressBarPresenter _template;

        public void Create(DailyReward dailyReward, Transform sliderContainer)
        {
            DaysProgressBarPresenter slider = Instantiate(_template, sliderContainer);
            slider.Init(dailyReward);
        }
    }
}
