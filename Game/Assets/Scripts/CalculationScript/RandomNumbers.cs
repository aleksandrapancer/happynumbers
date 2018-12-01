using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.CalculationScript.Level;

public class RandomNumbers : MonoBehaviour
{
    private Random random;

    [SerializeField]
    public Text star1 = null, star2 = null, star3 = null, star4 = null, calculation = null, score = null;

    public AudioSource correctSound, incorrectSound;

    private int sum, firstNumber, secondNumber, correctStar, points = 0, value;
    public List<string> listOfStars;
    GameObject go;
    RandomStarColor rndStarColor;

    private void Start()
    {
        //enum w zależności od poziomu gry
        CreateCalculation(LevelEnum.hard);


        go = GameObject.Find("Panel_stars");
        rndStarColor = go.GetComponentInChildren<RandomStarColor>();
    }

    public void CheckCorrectlyResult(int numberStar)
    {
        if (numberStar == correctStar)
        {
            CreateCalculation(LevelEnum.hard);
            correctSound.Play();

            rndStarColor.randStars(); 
        }
        else
        {
            incorrectSound.Play();
        }
    }
    public void PlaySong()
    {

    }

    public void CreateCalculation(LevelEnum level)
    {
        CleanStars();

        var maxRange = maxRangeOfLevel[level];
        SignEnum sign;

        if (level.Equals(LevelEnum.easy))
            sign = GetEnum(Random.Range(1, 3));
        else
            sign = GetEnum(Random.Range(1, 5));


        firstNumber = Random.Range(1, maxRange);
        secondNumber = Random.Range(0, maxRange);


        switch (sign)
        {
            case SignEnum.addition:
                do
                {
                    secondNumber = Random.Range(0, maxRange);
                    sum = firstNumber + secondNumber;
                } while (sum >= maxRange);

                calculation.text = firstNumber + " + " + secondNumber + " = ";
                break;

            case SignEnum.subtraction:
                do
                {
                    secondNumber = Random.Range(0, maxRange);
                    sum = firstNumber - secondNumber;
                } while (sum >= maxRange || sum < 0);


                calculation.text = firstNumber + " - " + secondNumber + " = ";
                break;

            case SignEnum.multiplication:
                do
                {
                    secondNumber = Random.Range(1, maxRange);
                    sum = firstNumber * secondNumber;
                } while (sum >= maxRange);

                calculation.text = firstNumber + " * " + secondNumber + " = ";
                break;

            case SignEnum.division:
                do
                {
                    secondNumber = Random.Range(1, maxRange);
                    sum = firstNumber / secondNumber;
                    value = firstNumber % secondNumber;
                } while (sum >= maxRange || value != 0);


                calculation.text = firstNumber + " / " + secondNumber + " = ";
                break;
        }

        FillStars(level);
    }

    public void CleanStars()
    {
        listOfStars.Clear();
        star1.text = "";
        star2.text = "";
        star3.text = "";
        star4.text = "";
    }

    public void FillStars(LevelEnum level)
    {
        correctStar = Random.Range(1, 5);
        var maxRange = maxRangeOfLevel[level];

        switch (correctStar)
        {
            case 1:
                star1.text = sum.ToString();
                break;
            case 2:
                star2.text = sum.ToString();
                break;
            case 3:
                star3.text = sum.ToString();
                break;
            case 4:
                star4.text = sum.ToString();
                break;
        }

        if (star1.text == "")
        {
            string number = RandomStarText(maxRange);
            listOfStars.Add(number);
            star1.text = number;
        }
        if (star2.text == "")
        {
            string number = RandomStarText(maxRange);
            listOfStars.Add(number);
            star2.text = number;
        }
        if (star3.text == "")
        {
            string number = RandomStarText(maxRange);
            listOfStars.Add(number);
            star3.text = number;
        }
        if (star4.text == "")
        {
            string number = RandomStarText(maxRange);
            listOfStars.Add(number);
            star4.text = number;
        }
    }

    public string RandomStarText(int maxRange)
    {
        int resume;
        do
        {
            resume = Random.Range(0, maxRange);
        } while (resume == sum || listOfStars.Contains(resume.ToString()));


        return resume.ToString();
    }

    public SignEnum GetEnum(int index)
    {
        switch (index)
        {
            case 1:
                return SignEnum.addition;
            case 2:
                return SignEnum.subtraction;
            case 3:
                return SignEnum.multiplication;
            default:
                return SignEnum.division;
        }
    }
}