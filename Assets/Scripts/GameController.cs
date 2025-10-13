using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Menu,
    Quiz,
    Final
}

public class GameController : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject quizCanvas;
    public GameObject finalCanvas;
    public GameObject bookCanvas;
    
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
    public Color optionsTextSelectedColor;
    public Image questionIcon;
    public List<Sprite> questionsIcons = new List<Sprite>(5);
    public AutoFlip autoFlipBook;
    public Book book;
    
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
    
    
    private Color _optionsTextDefaultColor;
    private Perfil _perfil;
    private GameState _gameState = GameState.Menu;

    private void Awake()
    {
        _optionsTextDefaultColor = textA.color;
        _perfil = GetComponent<Perfil>();
        
        options1 = new Dictionary<string, string>
        {
            { "A", "Um enredo profundo, com reflexões filosóficas ou sociais;" },
            { "B", "Emoções intensas e personagens com histórias marcantes;" },
            { "C", "Mistérios, enigmas e reviravoltas inesperadas;" },
            { "D", "Temas sobre autoconhecimento, espiritualidade ou mudanças de vida." },
            { "question", "1. O que mais te atrai ao escolher um livro?" }
        };
        pages.Add(options1);

        options2 = new Dictionary<string, string>
        {
            { "A", "Inspirado(a) a pensar mais criticamente sobre o mundo" },
            { "B", "Emocionado(a), como se tivesse vivido aquela história" },
            { "C", "Motivado(a) a pesquisar mais sobre o tema ou autor" },
            { "D", "Transformado(a), como se tivesse aprendido algo sobre si mesmo(a)" },
            { "question", "2. Como você se sente ao terminar uma boa leitura?" }
        };
        pages.Add(options2);

        options3 = new Dictionary<string, string>
        {
            { "A", " “1984” – George Orwell / Clássicos da literatura mundial;" },
            { "B", "“A Culpa é das Estrelas” – John Green / Romances intensos;" },
            { "C", " “O Código Da Vinci” – Dan Brown / Ficção investigativa;" },
            { "D", "“O Poder do Agora” – EckhartTolle / Desenvolvimento pessoal." },
            { "question", "3. Qual desses livros (ou estilos) mais te chama a atenção?" }
        };
        pages.Add(options3);

        options4 = new Dictionary<string, string>
        {
            { "A", "Literatura clássica ou não-ficção filosófica;" },
            { "B", "Romance, drama ou fantasia com foco emocional;" },
            { "C", "Suspense, ficção científica ou thrillers;" },
            { "D", "Autoajuda, espiritualidade ou psicologia." },
            { "question", "4. Você está em uma livraria. Para onde vai primeiro?" }
        };
        pages.Add(options4);

        options5 = new Dictionary<string, string>
        {
            { "A", "Um livro que me faça refletir sobre a sociedade e os valores humanos" },
            { "B", "Uma história envolvente, para eu me emocionar e viajar na imaginação" },
            { "C", "Um enredo cheio de pistas e mistérios que estimule meu raciocínio" },
            { "D", "Uma leitura que me ajude a crescer como pessoa e repensar minha vida" },
            { "question", "5. Que tipo de leitura mais combina com seu momento atual?" }
        };
        pages.Add(options5);
    }

    private void Start()
    {
        _gameState = GameState.Menu;
        
        menuCanvas.SetActive(true);
        quizCanvas.SetActive(false);
        finalCanvas.SetActive(false);
    }

    public void FlipPage()
    {
        StartCoroutine(FlipPagRoutine());
    }
    
    private IEnumerator FlipPagRoutine()
    {
        if (_gameState == GameState.Menu)
        {
            _gameState = GameState.Quiz;
            menuCanvas.SetActive(false);
            finalCanvas.SetActive(false);
        }
        
        if(_gameState == GameState.Quiz)
        {
            if (pageIndex >= pages.Count)
            {
                _gameState = GameState.Final;
                quizCanvas.SetActive(false);
                finalCanvas.SetActive(true);
                var perfil = _perfil.GetPerfil();
                book.bookPages[book.bookPages.Length - 1] = perfil;
            }
            else
            {
                quizCanvas.SetActive(false);
                UpdatteQuestionsPage();
            }
        }
        
        autoFlipBook.FlipRightPage();
        
        yield return new WaitForSeconds(1.5f); // Espera 1 segundo (ajuste conforme necessário)
        
        if(_gameState == GameState.Quiz)
        {
            quizCanvas.SetActive(true);
        }
        
    }

    /*private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ScreenCapture.CaptureScreenshot($"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            Debug.Log("Screenshot taken!");
        }
    }*/

    public void UpdateButtomStatus()
    {
        switch (choice)
        {
            case "a":
                textA.color = optionsTextSelectedColor;
                buttonA.interactable = false;
                
                textB.color = _optionsTextDefaultColor;
                buttonB.interactable = true;
                
                textC.color = _optionsTextDefaultColor;
                buttonC.interactable = true;
                
                textD.color = _optionsTextDefaultColor;
                buttonD.interactable = true;
                break;
            case "b":
                textB.color = optionsTextSelectedColor;
                buttonB.interactable = false;
                
                textA.color = _optionsTextDefaultColor;
                buttonA.interactable = true;
                
                textC.color = _optionsTextDefaultColor;
                buttonC.interactable = true;
                
                textD.color = _optionsTextDefaultColor;
                buttonD.interactable = true;
                break;
            case "c":
                textC.color = optionsTextSelectedColor;
                buttonC.interactable = false;
                
                textA.color = _optionsTextDefaultColor;
                buttonA.interactable = true;
                
                textB.color = _optionsTextDefaultColor;
                buttonB.interactable = true;
                
                textD.color = _optionsTextDefaultColor;
                buttonD.interactable = true;
                break;
            case "d":
                textD.color = optionsTextSelectedColor;
                buttonD.interactable = false;
                
                textA.color = _optionsTextDefaultColor;
                buttonA.interactable = true;
                
                textB.color = _optionsTextDefaultColor;
                buttonB.interactable = true;
                
                textC.color = _optionsTextDefaultColor;
                buttonC.interactable = true;
                break;
            default:
                textA.color = _optionsTextDefaultColor;
                textB.color = _optionsTextDefaultColor;
                textC.color = _optionsTextDefaultColor;
                textD.color = _optionsTextDefaultColor;
                
                buttonA.interactable = true;
                buttonB.interactable = true;
                buttonC.interactable = true;
                buttonD.interactable = true;
                
                break;
        }
    }

    public void UpdatteQuestionsPage() {

        pageNow = pages[pageIndex];
        textA.text = pageNow["A"];
        textB.text = pageNow["B"];
        textC.text = pageNow["C"];
        textD.text = pageNow["D"];
        question.text = pageNow["question"];
        questionIcon.sprite = questionsIcons[pageIndex];
        confirmButton.interactable = false;
        choice = null;
        UpdateButtomStatus();
    }
    
    public void OptionA() { choice = "a"; UpdateButtomStatus(); confirmButton.interactable = true; }
    public void OptionB() { choice = "b"; UpdateButtomStatus(); confirmButton.interactable = true; }
    public void OptionC() { choice = "c"; UpdateButtomStatus(); confirmButton.interactable = true; }
    public void OptionD() { choice = "d"; UpdateButtomStatus(); confirmButton.interactable = true; }

    public void Confirm()
    {
        if (choice == "a") { classico++; }
        else if (choice == "b") { emotivo++; }
        else if (choice == "c") { curioso++; }
        else if (choice == "d") { intuitivo++; }
        pageIndex++;
        Debug.Log(pageIndex);
        FlipPage();
    }
    
    [RuntimeInitializeOnLoadMethod]
    private static void OnRuntimeMethodLoad()
    {
        classico = 0;
        emotivo = 0;
        curioso = 0;
        intuitivo = 0;
        choice = null;
    }

    public void Reset()
    {
        classico = 0;
        emotivo = 0;
        curioso = 0;
        intuitivo = 0;
        choice = null;
        pageIndex = 0;
        book.currentPage = 0;
        book.UpdateBook();
        
        menuCanvas.SetActive(true);
        quizCanvas.SetActive(false);
        finalCanvas.SetActive(false);

        _gameState = GameState.Menu;
    }
}
