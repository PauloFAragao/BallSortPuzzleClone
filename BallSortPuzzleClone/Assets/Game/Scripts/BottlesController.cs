using UnityEngine;

public class BottlesController : MonoBehaviour
{
    //prefab dos recipientes
    [SerializeField] private BottleController bottlePrefab;

    //referencia de todos os recipientes em cena
    private BottleController[] bottles;

    //quantidade de recipientes em tela
    private int bottlesAmount = 0;

    //quantidade de recipientes que já foram instanciados
    private int bottlesIndex = 0;

    //quantidade maxima de recipientes na tela
    private int maxBottlesAmount;

    //quantidade de recipientes cheios necessária para a faze está completa
    private int victoryCondition;

    public void InstantiateBottle(int numberOfColors, int color1, int color2, int color3, int color4)
    {
        var bottle = Instantiate(bottlePrefab, ChooseBottlePosition(bottlesIndex), Quaternion.identity);

        bottle.SetBController(this);

        int[] colors = { color1, color2, color3, color4 };

        bottle.SpawnBalls(numberOfColors, colors);

        bottles[bottlesIndex] = bottle;

        bottlesIndex++;
    }

    //método que vai receber a quantidade de recipientes iniciais da fase
    public void SetBottlesAmount(int bottlesAmount, int vCondition)
    {
        this.bottlesAmount = bottlesAmount;
        maxBottlesAmount = bottlesAmount + 2;
        victoryCondition = vCondition;

        //iniciando o array dos recipientes
        bottles = new BottleController[maxBottlesAmount];//+2 por que vou implementar para poder adicionar até mais 2 recipientes
    }

    public void VerifyIfLevelIsDone()
    {
        int bottlesDone = 0;

        for (int x = 0; x < bottlesAmount; x++)
        {
            if (bottles[x].GetIsDone())
                bottlesDone++;
        }
        
        //verificando se tem a quantidade de bottles necessária para completar a fase
        if (bottlesDone == victoryCondition)
            GameManager.Instance.LoadNextLevel();
    }

    private Vector3 ChooseBottlePosition(int bottle)
    {
        switch (bottlesAmount)
        {
            case 2:
                //bottle 0
                if (bottle == 0) return new Vector3(-0.4f, 0, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(0.4f, 0, 0);
                break;

            case 3:
                //bottle 0
                if (bottle == 0) return new Vector3(-0.8f, 0, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(0, 0, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(0.8f, 0, 0);
                break;

            case 4:
                //bottle 0
                if (bottle == 0) return new Vector3(-0.9f, 0, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.3f, 0, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(0.3f, 0, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.9f, 0, 0);
                break;

            case 5:
                //bottle 0
                if (bottle == 0) return new Vector3(-1f, 0, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.5f, 0, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(0, 0, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.5f, 0, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(1f, 0, 0);
                break;

            case 6:
                //bottle 0
                if (bottle == 0) return new Vector3(-1.25f, 0, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.75f, 0, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(-0.25f, 0, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.25f, 0, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(0.75f, 0, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(1.25f, 0, 0);
                break;

            case 7:
                //bottle 0
                if (bottle == 0) return new Vector3(-0.9f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.3f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(0.3f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.9f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(-0.8f, -0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(0f, -0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(0.8f, -0.7f, 0);
                break;

            case 8:
                //bottle 0
                if (bottle == 0) return new Vector3(-0.9f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.3f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(0.3f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.9f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(-0.9f, -0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(-0.3f, -0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(0.3f, -0.7f, 0);
                //bottle 7
                if (bottle == 7) return new Vector3(0.9f, -0.7f, 0);
                break;

            case 9:
                //bottle 0
                if (bottle == 0) return new Vector3(-1f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.5f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(0, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.5f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(1f, 0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(-0.9f, -0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(-0.3f, -0.7f, 0);
                //bottle 7
                if (bottle == 7) return new Vector3(0.3f, -0.7f, 0);
                //bottle 8
                if (bottle == 8) return new Vector3(0.9f, -0.7f, 0);
                break;

            case 10:
                //bottle 0
                if (bottle == 0) return new Vector3(-1f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.5f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(0f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.5f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(1f, 0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(-1f, -0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(-0.5f, -0.7f, 0);
                //bottle 7
                if (bottle == 7) return new Vector3(0f, -0.7f, 0);
                //bottle 8
                if (bottle == 8) return new Vector3(0.5f, -0.7f, 0);
                //bottle 9
                if (bottle == 9) return new Vector3(1f, -0.7f, 0);
                break;

            case 11:
                //bottle 0
                if (bottle == 0) return new Vector3(-1.25f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.75f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(-0.25f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.25f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(0.75f, 0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(1.25f, 0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(-1f, -0.7f, 0);
                //bottle 7
                if (bottle == 7) return new Vector3(-0.5f, -0.7f, 0);
                //bottle 8
                if (bottle == 8) return new Vector3(0f, -0.7f, 0);
                //bottle 9
                if (bottle == 9) return new Vector3(0.5f, -0.7f, 0);
                //bottle 10
                if (bottle == 10) return new Vector3(1f, -0.7f, 0);
                break;

            case 12:
                //bottle 0
                if (bottle == 0) return new Vector3(-1.25f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.75f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(-0.25f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0.25f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(0.75f, 0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(1.25f, 0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(-1.25f, -0.7f, 0);
                //bottle 7
                if (bottle == 7) return new Vector3(-0.75f, -0.7f, 0);
                //bottle 8
                if (bottle == 8) return new Vector3(-0.25f, -0.7f, 0);
                //bottle 9
                if (bottle == 9) return new Vector3(0.25f, -0.7f, 0);
                //bottle 10
                if (bottle == 10) return new Vector3(0.75f, -0.7f, 0);
                //bottle 11
                if (bottle == 11) return new Vector3(1.25f, -0.7f, 0);
                break;

            case 13:
                //bottle 0
                if (bottle == 0) return new Vector3(-1.2f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.8f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(-0.4f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(0.4f, 0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(1.8f, 0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(1.2f, 0.7f, 0);
                //bottle 7
                if (bottle == 7) return new Vector3(-1.25f, -0.7f, 0);
                //bottle 8
                if (bottle == 8) return new Vector3(-0.75f, -0.7f, 0);
                //bottle 9
                if (bottle == 9) return new Vector3(-0.25f, -0.7f, 0);
                //bottle 10
                if (bottle == 10) return new Vector3(0.25f, -0.7f, 0);
                //bottle 11
                if (bottle == 11) return new Vector3(0.75f, -0.7f, 0);
                //bottle 12
                if (bottle == 12) return new Vector3(1.25f, -0.7f, 0);
                break;

            case 14:
                //bottle 0
                if (bottle == 0) return new Vector3(-1.2f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-0.8f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(-0.4f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(0f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(0.4f, 0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(0.8f, 0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(1.2f, 0.7f, 0);

                //bottle 7
                if (bottle == 7) return new Vector3(-1.2f, -0.7f, 0);
                //bottle 8
                if (bottle == 8) return new Vector3(-0.8f, -0.7f, 0);
                //bottle 9
                if (bottle == 9) return new Vector3(-0.4f, -0.7f, 0);
                //bottle 10
                if (bottle == 10) return new Vector3(0f, -0.7f, 0);
                //bottle 11
                if (bottle == 11) return new Vector3(0.4f, -0.7f, 0);
                //bottle 12
                if (bottle == 12) return new Vector3(0.8f, -0.7f, 0);
                //bottle 13
                if (bottle == 13) return new Vector3(1.2f, -0.7f, 0);
                break;

            case 15:
                //bottle 0
                if (bottle == 0) return new Vector3(-1.4f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-1f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(-0.6f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(-0.2f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(0.2f, 0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(0.6f, 0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(1f, 0.7f, 0);
                //bottle 7
                if (bottle == 7) return new Vector3(1.4f, 0.7f, 0);
                //bottle 8
                if (bottle == 8) return new Vector3(-1.2f, -0.7f, 0);
                //bottle 9
                if (bottle == 9) return new Vector3(-0.8f, -0.7f, 0);
                //bottle 10
                if (bottle == 10) return new Vector3(-0.4f, -0.7f, 0);
                //bottle 11
                if (bottle == 11) return new Vector3(0f, -0.7f, 0);
                //bottle 12
                if (bottle == 12) return new Vector3(0.4f, -0.7f, 0);
                //bottle 13
                if (bottle == 13) return new Vector3(0.8f, -0.7f, 0);
                //bottle 14
                if (bottle == 14) return new Vector3(1.2f, -0.7f, 0);
                break;

            case 16:
                //bottle 0
                if (bottle == 0) return new Vector3(-1.4f, 0.7f, 0);
                //bottle 1
                if (bottle == 1) return new Vector3(-1f, 0.7f, 0);
                //bottle 2
                if (bottle == 2) return new Vector3(-0.6f, 0.7f, 0);
                //bottle 3
                if (bottle == 3) return new Vector3(-0.2f, 0.7f, 0);
                //bottle 4
                if (bottle == 4) return new Vector3(0.2f, 0.7f, 0);
                //bottle 5
                if (bottle == 5) return new Vector3(0.6f, 0.7f, 0);
                //bottle 6
                if (bottle == 6) return new Vector3(1f, 0.7f, 0);
                //bottle 7
                if (bottle == 7) return new Vector3(1.4f, 0.7f, 0);
                //bottle 8
                if (bottle == 8) return new Vector3(-1.4f, -0.7f, 0);
                //bottle 9
                if (bottle == 9) return new Vector3(-1f, -0.7f, 0);
                //bottle 10
                if (bottle == 10) return new Vector3(-0.6f, -0.7f, 0);
                //bottle 11
                if (bottle == 11) return new Vector3(-0.2f, -0.7f, 0);
                //bottle 12
                if (bottle == 12) return new Vector3(0.2f, -0.7f, 0);
                //bottle 13
                if (bottle == 13) return new Vector3(0.6f, -0.7f, 0);
                //bottle 14
                if (bottle == 14) return new Vector3(1f, -0.7f, 0);
                //bottle 15
                if (bottle == 15) return new Vector3(1.4f, -0.7f, 0);
                break;
        }

        return new Vector3(0, 0, 0);
    }

    // ================================ Métodos públicos para instanciar os recipientes ================================
    public void SpawnBottle(int color1, int color2, int color3, int color4)
    {
        InstantiateBottle(4, color1, color2, color3, color4);
    }

    public void SpawnBottle(int color1, int color2, int color3)
    {
        InstantiateBottle(3, color1, color2, color3, 0);
    }

    public void SpawnBottle(int color1, int color2)
    {
        InstantiateBottle(2, color1, color2, 0, 0);
    }

    public void SpawnBottle(int color1)
    {
        InstantiateBottle(1, color1, 0, 0, 0);
    }

    public void SpawnBottle()
    {
        InstantiateBottle(0, 0, 0, 0, 0);
    }

}
