using Company.TestTask.Factory;
using Company.TestTask.Model;
using UnityEngine;

[RequireComponent(typeof(ButtonsOpenLevelFactory))]
public class LevelsMenuCompositeRoot : MonoBehaviour
{
    private ButtonsOpenLevelFactory _buttonsOpenLevelFactory;
    private IDataKeeper<int> _levelsKeeper;
    private LevelsMenu _levelsMenu;

    public void Init(IDataKeeper<int> levelsKeeper)
    {
        _levelsKeeper = levelsKeeper;
        _buttonsOpenLevelFactory = GetComponent<ButtonsOpenLevelFactory>();
        ButtonOpenLevel[] buttonsOpenLevel = _buttonsOpenLevelFactory.Create();
        _levelsMenu = new LevelsMenu(_levelsKeeper, buttonsOpenLevel);
        enabled = true;
    }

    private void OnEnable()
    {
        _levelsMenu.Enable();
    }

    private void OnDisable()
    {
        _levelsMenu.Disable();
    }
}
