using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //referencia ao sprite render 
    [SerializeField] private SpriteRenderer ballColor;

    [SerializeField] private Animator animator;

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

    public int GetColorIndex()
    {
        return colorIndex;
    }

    public bool GetAnimated()
    {
        return animated;
    }

    public void setIdleAnimation()
    {
        animator.Play("Idle");
    }

    //==========================================  ANIMAÇÕES  ==========================================
    
    public void Select(Vector3 finalPosition)
    {
        StartCoroutine(MoveAnimation(finalPosition));

        animator.Play("Selected");
    }

    public void Unselect(Vector3 finalPosition)
    {
        StartCoroutine(MoveAnimation(finalPosition));

        animator.Play("Unselected");
    }

    //animação de movimentação
    private IEnumerator MoveAnimation(Vector3 finalPosition)
    {
        Vector3 inicialPosition = transform.position;

        float t = 0;

        while (t <= 0.2f)
        {
            transform.position = Vector3.Lerp(inicialPosition, finalPosition, (t / 0.2f));

            t += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.position = finalPosition;

        //indicando que a bolinha não está mais se movendo
        animated = false;
    }

    public void MoveBall(Vector3 bottlePosition, Vector3 endPosition)
    {
        StartCoroutine(ChangeBottleAnimation(bottlePosition, endPosition));
    }

    private IEnumerator ChangeBottleAnimation(Vector3 bottlePosition, Vector3 endPosition)
    {
        Vector3 inicialPosition = transform.position;
        float t = 0;

        //movendo para a posição do outro recipiente
        while (t <= 0.2f)
        {
            transform.position = Vector3.Lerp(inicialPosition, bottlePosition, (t / 0.2f));

            t += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        transform.position = bottlePosition;

        //animação da bolinha kicando
        animator.Play("Unselected");

        //movendo para a posição dentro do recipiente
        inicialPosition = transform.position;
        t = 0;
        while (t <= 0.2f)
        {
            transform.position = Vector3.Lerp(inicialPosition, endPosition, (t / 0.2f));

            t += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        transform.position = endPosition;

        //indicando que a bolinha não está mais se movendo
        animated = false;
    }

}
