using UnityEngine;

public class BottleController : MonoBehaviour
{
    //prefab da bolinha
    [SerializeField] private BallController ballPrefab;

    //cores da palheta normal
    [SerializeField] private Color[] NormalColorsPallet;
    //pateta com as cores para pessoas com protanopia
    [SerializeField] private Color[] protanopiaColorsPallet;

    //bolas dentro do recipiente
    private BallController[] balls;

    //quantidade de bolinhas dentro do recipiente
    private int ballsAmount = 0;

    //posições onde as bolinhas dentro do recipiente
    [SerializeField] private Transform[] positions;

    //se esse recipiente está completo
    private bool isDone;

    //referencia ao bottlesController
    private BottlesController bottlesController;

    private void Awake()
    {
        balls = new BallController[4];
    }

    //spawna as bolinhas dentro do recipiente
    public void SpawnBalls(int quantify, int[] selectedColors)
    {
        for (int x = 0; x < quantify; x++)
        {
            var ball = Instantiate(ballPrefab, positions[x].position, Quaternion.identity);

            //ball.SetColor(NormalColorsPallet[selectedColors[x]], selectedColors[x]);

            ball.SetColor(protanopiaColorsPallet[selectedColors[x]], selectedColors[x]);

            balls[ballsAmount] = ball;

            ballsAmount++;
        }
    }

    //seleciona a bolinha do topo
    public void SelectBall()
    {
        if (ballsAmount > 0)
            balls[ballsAmount - 1].Select(positions[4].position, 0.2f);
    }

    //desseleciona a bolinha e manda ela de volta para o seu lugar
    public void UnselectBall()
    {
        balls[ballsAmount - 1].Unselect(positions[ballsAmount - 1].position, 0.2f);
    }

    //método que vai ser chamado para transferir a bolinha para o outro recipiente
    public BallController TransferBall()
    {
        ballsAmount--;
        return balls[ballsAmount];
    }

    //método que vai receber a referencia da bolinha que vai ser transferida para esse recipiente e vai mover ela 
    public void ReceiveBall(BallController ball)
    {
        ball.MoveBall(positions[4].position, 0.2f);

        ball.SetUnselectCommand(positions[ballsAmount].position);

        balls[ballsAmount] = ball;

        ballsAmount++;

        //verificando se este recipiente está completo
        VerifyIfIsDone();

    }

    //limpa a referencia da bolinha que foi mandada para o outro recipiente
    public void ClearReference()
    {
        balls[ballsAmount] = null;
    }

    //verifica se tem alguma bolinha desse recipiente se movendo
    public bool AnyBallIsMoving()
    {
        for (int x = 0; x < ballsAmount; x++)
        {
            if (balls[x].GetAnimated())
                return true;
        }

        return false;
    }

    //verifica se o recipiente está com todas as cores iguais
    private void VerifyIfIsDone()
    {
        if (ballsAmount == 4)
        {
            int firstBallColorIndex = balls[0].GetColorIndex();

            for (int x = 1; x < 4; x++)
            {
                if (balls[x].GetColorIndex() != firstBallColorIndex)
                {
                    isDone = false;
                    return;
                }
            }
            isDone = true;

            //mandando verificar se o level está concluído
            bottlesController.VerifyIfLevelIsDone();
        }
        else
            isDone = false;
    }

    //=========================================  Sets e Gets  =========================================
    public void SetBController(BottlesController bController)
    {
        bottlesController = bController;
    }

    public bool GetIsDone()
    {
        return isDone;
    }

    public int GetTopColor()
    {
        if (ballsAmount > 0)
            return balls[ballsAmount - 1].GetColorIndex();
        else
            return -1;
    }

    public int GetBallsAmount()
    {
        return ballsAmount;
    }
}
