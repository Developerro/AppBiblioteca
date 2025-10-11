using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int pageIndex = 0;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public Button confirmButton;
    public TextMeshProUGUI question;
    public TextMeshProUGUI textA;
    public TextMeshProUGUI textB;
    public TextMeshProUGUI textC;
    public TextMeshProUGUI textD;
    public static string choice;
    public static int classico = 0;
    public static int emotivo = 0;
    public static int curioso = 0;
    public static int intuitivo = 0;
    public List<Dictionary<string, string>> pages = new List<Dictionary<string, string>>();
    Dictionary<string, string> pageNow;
    Dictionary<string, string> options1;
    Dictionary<string, string> options2;
    Dictionary<string, string> options3;
    Dictionary<string, string> options4;
    Dictionary<string, string> options5;

    void Start()
    {
        confirmButton.interactable = false;

        options1 = new Dictionary<string, string>
        {
            { "A", "Um enredo profundo, com reflexões filosóficas ou sociais" },
            { "B", "Emoções intensas e personagens com histórias marcantes" },
            { "C", "Mistérios, enigmas e reviravoltas inesperadas" },
            { "D", "Temas sobre autoconhecimento, espiritualidade ou mudanças de vida" },
            { "question", "O que mais te atrai ao escolher um livro?" }
        };
        pages.Add(options1);

        options2 = new Dictionary<string, string>
        {
            { "A", "Inspirado(a) a pensar mais criticamente sobre o mundo" },
            { "B", "Emocionado(a), como se tivesse vivido aquela história" },
            { "C", "Motivado(a) a pesquisar mais sobre o tema ou autor" },
            { "D", "Transformado(a), como se tivesse aprendido algo sobre si mesmo(a)" },
            { "question", "Como você se sente ao terminar uma boa leitura" }
        };
        pages.Add(options2);

        options3 = new Dictionary<string, string>
        {
            { "A", "“1984” – George Orwell / Clássicos da literatura mundial" },
            { "B", "“A Culpa é das Estrelas” – John Green / Romances intensos" },
            { "C", "“O Código Da Vinci” – Dan Brown / Ficção investigativa" },
            { "D", "O Poder do Agora” – Eckhart Tolle / Desenvolvimento pessoal" },
            { "question", "Qual desses livros (ou estilos) mais te chama a atenção?" }
        };
        pages.Add(options3);

        options4 = new Dictionary<string, string>
        {
            { "A", "Literatura clássica ou não-ficção filosófica" },
            { "B", "Romance, drama ou fantasia com foco emocional" },
            { "C", "Suspense, ficção científica ou thrillers" },
            { "D", "Autoajuda, espiritualidade ou psicologia." },
            { "question", "Você está em uma livraria. Para onde vai primeiro?" }
        };
        pages.Add(options4);

        options5 = new Dictionary<string, string>
        {
            { "A", "Um livro que me faça refletir sobre a sociedade e os valores humanos" },
            { "B", "Uma história envolvente, para eu me emocionar e viajar na imaginação" },
            { "C", "Um enredo cheio de pistas e mistérios que estimule meu raciocínio" },
            { "D", "Uma leitura que me ajude a crescer como pessoa e repensar minha vida" },
            { "question", "Que tipo de leitura mais combina com seu momento atual?" }
        };
        pages.Add(options5);

        ChangeTexts();
    }

    public void setNormal()
    {
        textA.color = Color.white;
        textB.color = Color.white;
        textC.color = Color.white;
        textD.color = Color.white;
    }

    public void ChangeTexts()
    {
        if (pageIndex >= pages.Count)
        {
            SceneManager.LoadScene(1);
            return;
        }

        pageNow = pages[pageIndex];
        textA.text = pageNow["A"];
        textB.text = pageNow["B"];
        textC.text = pageNow["C"];
        textD.text = pageNow["D"];
        question.text = pageNow["question"];
        pageIndex++;
        setNormal();
        confirmButton.interactable = false;
        choice = null;
    }

    public void OptionA() { choice = "a"; setNormal(); textA.color = Color.green; confirmButton.interactable = true; }
    public void OptionB() { choice = "b"; setNormal(); textB.color = Color.green; confirmButton.interactable = true; }
    public void OptionC() { choice = "c"; setNormal(); textC.color = Color.green; confirmButton.interactable = true; }
    public void OptionD() { choice = "d"; setNormal(); textD.color = Color.green; confirmButton.interactable = true; }

    public void Confirm()
    {
        if (choice == "a") { classico++; }
        else if (choice == "b") { emotivo++; }
        else if (choice == "c") { curioso++; }
        else if (choice == "d") { intuitivo++; }
        ChangeTexts();
    }
}
