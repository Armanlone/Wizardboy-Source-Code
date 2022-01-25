using UnityEngine;
using Game;

public class PlayerHasKeySetter : MonoBehaviour
{
    
    [Tooltip("Does the player has the key?")]
    [SerializeField]
    private bool doesPlayerHasKey = false;

    public void Set()
    {
        GameManager.setIsLevelClear(doesPlayerHasKey);
        print("doesPlayerHasKey: " + (GameManager.getIsLevelClear()));
    }

}