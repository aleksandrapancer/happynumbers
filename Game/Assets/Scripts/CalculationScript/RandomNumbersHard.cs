using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.CalculationScript.Level;

public class RandomNumbersHard : MonoBehaviour
{
    private Random random;

    [SerializeField]
    public Text star1 = null, star2 = null, star3 = null, star4 = null, calculation = null, score = null;
  
    public Button star1BTN, star2BTN, star3BTN, star4BTN;
    public List<string> listOfStars;
    public AudioSource correctSound, incorrectSound;

    private int sum, firstNumber, secondNumber, correctStar, points = 0, value;
   
    GameObject go;
     Vector3 positionsSTAR1start, positionsSTAR1stop, positionsSTAR2start, positionsSTAR2stop, positionsSTAR3start, positionsSTAR3stop, positionsSTAR4start, positionsSTAR4stop;

     private int speed1, speed2, speed3, speed4;
    private void Update()
    {
        //Debug.Log(star1BTN.transform.position);
        //STAR 1
        star1BTN.transform.position = Vector3.MoveTowards(star1BTN.transform.position,
            positionsSTAR1stop, (speed1 * Time.deltaTime));
        //  Debug.Log(star1BTN.transform.position.y+ " "+ positionsSTAR1stop.y);
        if (Mathf.Round(star1BTN.transform.position.y) == Mathf.Round(positionsSTAR1stop.y))
        {

            star1BTN.transform.position = positionsSTAR1start;

        }

        //STAR 2
        star2BTN.transform.position = Vector3.MoveTowards(star2BTN.transform.position,
            positionsSTAR2stop, (speed2 * Time.deltaTime));
        //    Debug.Log(star2BTN.transform.position.y + " " + positionsSTAR2stop.y);
        if (Mathf.Round(star2BTN.transform.position.y) == Mathf.Round(positionsSTAR2stop.y))
        {

            star2BTN.transform.position = positionsSTAR2start;


        }
        //STAR 3
        star3BTN.transform.position = Vector3.MoveTowards(star3BTN.transform.position,
            positionsSTAR3stop, (speed3 *Time.deltaTime));
        //    Debug.Log(star2BTN.transform.position.y + " " + positionsSTAR2stop.y);
        if (Mathf.Round(star3BTN.transform.position.y) == Mathf.Round(positionsSTAR3stop.y))
        {

            star3BTN.transform.position = positionsSTAR3start;


        }
        //STAR 4
        star4BTN.transform.position = Vector3.MoveTowards(star4BTN.transform.position,
            positionsSTAR4stop, (speed4 * Time.deltaTime));
        //    Debug.Log(star2BTN.transform.position.y + " " + positionsSTAR2stop.y);
        if (Mathf.Round(star4BTN.transform.position.y) == Mathf.Round(positionsSTAR4stop.y))
        {

            star4BTN.transform.position = positionsSTAR4start;


        }
    }

    private void Start()
    {
	    int width = (int)(Screen.width*0.8);
	    Debug.Log(width);
	    speed1 = 70;
	    speed2 = 75;
	    speed3 = 73;
	    speed4 = 79;
        //enum w zależności od poziomu gry
        positionsSTAR1start= new Vector3(star1BTN.transform.position.x, star1BTN.transform.position.y,
            star1BTN.transform.position.z);
        positionsSTAR1stop= new Vector3(star1BTN.transform.position.x, star1BTN.transform.position.y -width,
            star1BTN.transform.position.z);

        positionsSTAR2start= new Vector3(star2BTN.transform.position.x, star2BTN.transform.position.y,
            star2BTN.transform.position.z);
        positionsSTAR2stop= new Vector3(star2BTN.transform.position.x, star2BTN.transform.position.y-width,
            star2BTN.transform.position.z);

        positionsSTAR3start=new Vector3(star3BTN.transform.position.x, star3BTN.transform.position.y,
            star3BTN.transform.position.z);
        positionsSTAR3stop = new Vector3(star3BTN.transform.position.x, star3BTN.transform.position.y-width,
            star3BTN.transform.position.z);

        positionsSTAR4start= new Vector3(star4BTN.transform.position.x, star4BTN.transform.position.y,
            star4BTN.transform.position.z);
       positionsSTAR4stop= new Vector3(star4BTN.transform.position.x, star4BTN.transform.position.y-width,
            star4BTN.transform.position.z); 

        CreateCalculation(LevelEnum.hard);
        
   
        star1BTN.onClick.AddListener(() => CheckCorrectlyResult(1));
        star2BTN.onClick.AddListener(() => CheckCorrectlyResult(2));
        star3BTN.onClick.AddListener(() => CheckCorrectlyResult(3));
        star4BTN.onClick.AddListener(() => CheckCorrectlyResult(4));
        

    }

    public void CheckCorrectlyResult(int numberStar)
    {
        Debug.Log(numberStar+ " "+ correctStar);
        if (numberStar == correctStar)
        {
            CreateCalculation(LevelEnum.hard);
            correctSound.Play();

        
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

        if (level.Equals(LevelEnum.hard))
        {
            sign = GetEnum(Random.Range(1, 3));
           
        }
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