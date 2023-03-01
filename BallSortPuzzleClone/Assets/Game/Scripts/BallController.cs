using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //referencia ao sprite render 
    [SerializeField] private SpriteRenderer ballColor;

    [SerializeField] private Animator animator;

    //para fazer a bolinha ir para a posição correta dentro do recipiente
    private bool unselectCommand;
    private Vector2 endPosition;

    //se a bolinha está se movendo
    private bool animated;

    private int colorIndex;

    //=========================================  Sets e Gets  =========================================
    public void SetColorIndex(int value)
    {
        colorIndex = value;
    }

    public void SetColor(Color color, int cIndex)
    {
        ballColor.color = color;
        colorIndex = cIndex;
    }

    public void SetUnselectCommand(Vector2 pos)
    {
        animated = true;
        unselectCommand = true;
        endPosition = pos;
    }

    public int GetColorIndex()
    {
        return colorIndex;
    }

    public bool GetAnimated()
    {
        return animated;
    }

    //==========================================  ANIMAÇÕES  ==========================================
    public void MoveBall(Vector3 finalPosition, float duration)
    {
        StartCoroutine(MoveAnimation(finalPosition, duration));
    }
    
    public void Select(Vector3 finalPosition, float duration)
    {
        StartCoroutine(MoveAnimation(finalPosition, duration));

        animator.Play("Selected");
    }

    public void Unselect(Vector3 finalPosition, float duration)
    {
        StartCoroutine(MoveAnimation(finalPosition, duration));

        animator.Play("Unselected");
    }

    //animação de movimentação
    private IEnumerator MoveAnimation(Vector3 finalPosition, float duration)
    {
        Vector3 inicialPosition = transform.position;

        float t = 0;

        while (t <= duration)
        {
            transform.position = Vector3.Lerp(inicialPosition, finalPosition, (t / duration));

            t += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.position = finalPosition;

        //indicando que a bolinha não está mais se movendo
        animated = false;

        //se a bolinha deve ir para a posição dela no fim dessa animação
        if (unselectCommand)
        {
            animated = true;
            unselectCommand = false;
            StartCoroutine(MoveAnimation(endPosition, 0.2f));

            animator.Play("Unselected");
        }
    }

}
