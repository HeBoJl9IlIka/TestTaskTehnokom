using Company.TestTask.Model;
using Company.TestTask.Presenter;
using System.Collections.Generic;
using UnityEngine;

namespace Company.TestTask.Factory
{
    public class RewardFactory : MonoBehaviour
    {
        [SerializeField] private List<RewardPresenter> _rewards;

        public Reward[] Create(Transform[] rewardsContainers)
        {
            Reward[] rewards = new Reward[_rewards.Count];

            for (int i = 0; i < _rewards.Count; i++)
            {
                rewards[i] = new Reward(_rewards[i].Item, _rewards[i].Amount, _rewards[i].DayNumber);

                if (i < rewardsContainers.Length)
                {
                    RewardPresenter newRewardPresenter = Instantiate(_rewards[i], rewardsContainers[i].transform);
                    newRewardPresenter.Init(rewards[i]);
                }
            }

            return rewards;
        }
    }
}