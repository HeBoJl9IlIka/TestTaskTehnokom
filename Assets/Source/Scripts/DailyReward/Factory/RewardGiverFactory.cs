using Company.TestTask.Model;
using Company.TestTask.Presenter;
using UnityEngine;

namespace Company.TestTask.Factory
{
    public class RewardGiverFactory : MonoBehaviour
    {
        [SerializeField] private RewardGiverPresenter _template;

        public void Create(DailyReward dailyReward)
        {
            RewardGiverPresenter rewardGiver = Instantiate(_template);
            rewardGiver.Init(dailyReward);
        }
    }
}
