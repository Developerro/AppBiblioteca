using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Perfil : MonoBehaviour
{
    public TextMeshProUGUI perfil;
    void Start()
    {
        List<string> perfis = new List<string>();
        int maiorValor = Mathf.Max(GameController.classico, GameController.emotivo, GameController.curioso, GameController.intuitivo);

        if (GameController.classico == maiorValor) perfis.Add("Clássico");
        if (GameController.emotivo == maiorValor) perfis.Add("Emotivo");
        if (GameController.curioso == maiorValor) perfis.Add("Curioso");
        if (GameController.intuitivo == maiorValor) perfis.Add("Intuitivo");

        perfil.text = string.Join(" e ", perfis);
    }
}
