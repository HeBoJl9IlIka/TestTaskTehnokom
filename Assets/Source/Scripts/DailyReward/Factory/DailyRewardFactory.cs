using Company.TestTask.Presenter;
using UnityEngine;

namespace Company.TestTask.Factory
{
    public class DailyRewardFactory : MonoBehaviour
    {
        [SerializeField] private DailyRewardPresenter _template;

        public DailyRewardPresenter Create()
        {
            DailyRewardPresenter newDailyReward = Instantiate(_template);

            return newDailyReward;
        }
    }
}
