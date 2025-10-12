using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Perfis
{
    Classico,
    Intuitivo,
    Curioso,
    Emotivo,
    ClassicoIntuitivo,
    ClassicoCurioso,
    ClassicoEmotivo,
    IntuitivoCurioso,
    IntuitivoEmotivo,
    CuriosoEmotivo
}

public class Perfil : MonoBehaviour
{
    public Image perfilIconImage;
    public List<Sprite> perfilIcons;

    private Dictionary<Perfis, Sprite> _icons = new Dictionary<Perfis, Sprite>();

    private void Awake()
    {
        foreach (Perfis perf in Enum.GetValues(typeof(Perfis)))
        {
            var icon = perfilIcons.FirstOrDefault();
            _icons.Add(perf, icon);
            perfilIcons.Remove(icon);
        }
    }

    void Start()
    {
        int maiorValor = Mathf.Max(GameController.classico, GameController.emotivo, GameController.curioso,
            GameController.intuitivo);

        List<Perfis> perfisPossiveis = new List<Perfis>();
        if (GameController.classico == maiorValor) perfisPossiveis.Add(Perfis.Classico);
        if (GameController.intuitivo == maiorValor) perfisPossiveis.Add(Perfis.Intuitivo);
        if (GameController.curioso == maiorValor) perfisPossiveis.Add(Perfis.Curioso);
        if (GameController.emotivo == maiorValor) perfisPossiveis.Add(Perfis.Emotivo);

        Perfis perfilFinal;
        if (perfisPossiveis.Count > 1)
        {
            perfilFinal = (Perfis)Enum.Parse(typeof(Perfis), string.Join("", perfisPossiveis));
        }
        else
        {
            perfilFinal = perfisPossiveis[0];
        }
        
        perfilIconImage.sprite = _icons[perfilFinal];
        Debug.Log(perfilFinal);
    }

    public void Reset()
    {
        GameController.OnRuntimeMethodLoad();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
