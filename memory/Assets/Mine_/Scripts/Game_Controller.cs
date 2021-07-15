using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool FirstGuess, SecondGuess;

    private int CountGuesses;
    private int CountCorrectGuesses;
    private int GameGuesses;

    private int FirstGuessIndex, SecondGuessIndex;

    private string FirstGuessPuzzle, SecondGuessPuzzle;

    void Start()
    {
        GetButtons();
        AddListener();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        GameGuesses = gamePuzzles.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("But");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }
    
    public void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void AddListener()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    
    public void PickAPuzzle()
    {
        Debug.Log("Clicking");
        if (!FirstGuess)
        {
            FirstGuess = true;
            FirstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            FirstGuessPuzzle = gamePuzzles[FirstGuessIndex].name;
            btns[FirstGuessIndex].image.sprite = gamePuzzles[FirstGuessIndex];
        }
        else if (!SecondGuess)
        {
            SecondGuess = true;
            SecondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            SecondGuessPuzzle = gamePuzzles[SecondGuessIndex].name;
            btns[SecondGuessIndex].image.sprite = gamePuzzles[SecondGuessIndex];
            CountGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }

    }

    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);

        if (FirstGuessPuzzle == SecondGuessPuzzle)
        {
            yield return new WaitForSeconds(.5f);

            btns[FirstGuessIndex].interactable = false;
            btns[SecondGuessIndex].interactable = false;

            btns[FirstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[SecondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            btns[FirstGuessIndex].image.sprite = bgImage;
            btns[SecondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.5f);

        FirstGuess = SecondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        CountCorrectGuesses++;
        
        if(CountCorrectGuesses == GameGuesses)
        {
            Debug.Log("Your Game is finished");
            Debug.Log("It took u " + CountGuesses + " many guesses to finish the game");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

}
