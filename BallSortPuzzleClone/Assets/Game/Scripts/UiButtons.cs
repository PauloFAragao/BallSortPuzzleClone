using UnityEngine;

public class UiButtons : MonoBehaviour
{
    
    public void ReloadLevel()
    {
        //if(!GameManager.Instance.gamePause)
            GameManager.Instance.ReloadLevel();
    }

}
