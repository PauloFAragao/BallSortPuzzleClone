using UnityEngine;
using Random = UnityEngine.Random;

public class UiButtons : MonoBehaviour
{
    [SerializeField] private Animator chestAnimator;
    [SerializeField] private GameObject UndoBonus;
    [SerializeField] private GameObject NewBottleBonus;
    private bool chestClose = true;

    public void ReloadLevel()
    {
        //if(!GameManager.Instance.gamePause)
            GameManager.Instance.ReloadLevel();
    }

    public void NextLevelButton()
    {
        GameManager.Instance.LoadNextLevel();
    }

    public void OpenChest()
    {
        if(chestClose)
        {
            chestAnimator.Play("Opening");
            chestClose = false;
            
           if( Random.value > 0.5f)
           {
                UndoBonus.SetActive(true);
                GameManager.Instance.undoQuantify++;
           }
           else
           {
                NewBottleBonus.SetActive(true);
                GameManager.Instance.newBottleQuantify++;
           }
        }
    }

}
