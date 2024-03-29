using UnityEngine;
using UnityEngine.UI;
using Game.LevelManagement;

public class UIButtonLevelUnlocker : MonoBehaviour
{

    [SerializeField]
    private Button _button = null;

    [SerializeField]
    private int levelIndex = 1;
    
    private void OnEnable()
    {
        
        if (_button == null)
        {
            return;
        }

        _button.interactable = levelIndex <= PlayerPrefs.GetInt(LevelManager.getLevelsUnlockedKey());

    }

}