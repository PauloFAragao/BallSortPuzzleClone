using UnityEngine;

public class GameController : MonoBehaviour
{
    public BottleController FirstBottle;
    public BottleController SecondBottle;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<BottleController>() != null)
                {
                    if (FirstBottle == null)
                    {
                        FirstBottle = hit.collider.GetComponent<BottleController>();

                        //condições para n seleção
                        if (FirstBottle.AnyBallIsMoving() || FirstBottle.GetBallsAmount() == 0)
                        {
                            FirstBottle = null;
                            return;
                        }

                        //animação de bolinha selecionada
                        FirstBottle.SelectBall();
                    }
                    else
                    {
                        if (FirstBottle == hit.collider.GetComponent<BottleController>())
                        {
                            FirstBottle.UnselectBall();
                            FirstBottle = null;
                        }
                        else
                        {
                            SecondBottle = hit.collider.GetComponent<BottleController>();
                            
                            //verificando se pode fazer a transferência
                            if ( SecondBottle.GetBallsAmount() == 4 ||
                            (FirstBottle.GetTopColor() != SecondBottle.GetTopColor() && SecondBottle.GetBallsAmount() != 0) )
                            {
                                FirstBottle.UnselectBall();

                                FirstBottle = null;
                                SecondBottle = null;

                                return;
                            }
                            else
                            {
                                //transferência
                                SecondBottle.ReceiveBall(FirstBottle.TransferBall());

                                //limpando a referencia da bolinha no primeiro recipiente
                                FirstBottle.ClearReference();

                                FirstBottle = null;
                                SecondBottle = null;
                            }


                        }
                    }
                }
            }

        }
    }

}
