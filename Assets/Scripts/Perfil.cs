using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perfil : MonoBehaviour
{
    public TextMeshProUGUI perfil;
    void Start()
    {
        int maiorValor = Mathf.Max(GameController.classico, GameController.emotivo, GameController.curioso, GameController.intuitivo);

        if (maiorValor == GameController.classico)
        {
            perfil.text = "Clássico";
        }
        else if (maiorValor == GameController.emotivo)
        {
            perfil.text = "Emotivo";
        }
        else if (maiorValor == GameController.curioso)
        {
            perfil.text = "Curioso";
        }
        else if (maiorValor == GameController.intuitivo)
        {
            perfil.text = "Intuitivo";
        }
    }
}
