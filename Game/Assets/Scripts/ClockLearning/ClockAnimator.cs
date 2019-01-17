using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class ClockAnimator : MonoBehaviour
    {

 

        private const float
            hoursToDegreees = 360f / 12f,
            minutesToDegrees = 360f / 60f;
        //  secondsToDegrees = 360f / 60f;

        public Transform hours, minutes;// seconds;
        public AudioSource tick;
        private float timer = 1f;
        public float roundTimer = 60f;
        private bool touched;
        private int startZ, startZMinute;
        private int touchAccuracy;
        private bool AM;
        private GameObject go, db;
        private Text debuger;
        //DIGI
        private Text digiClockText;
        private DateTime time;
        private int minuteStep;
        private Button h_UP, h_DOWN, m_UP, m_DOWN, isAM;
        private bool hour;

        public Sprite sun;
        public Sprite sun_red;

        private void Start()
        {
            //for debugging purposes
            //db = GameObject.Find("DEB");
            // debuger = db.GetComponentInChildren<Text>();
            //Radius around touchableoject
            touchAccuracy = 100;
            //Checking if any objekt is currently being touched
            touched = false;
            //Check which object was chosen - hour or minute
            hour = true;
            minuteStep = 5;
            time = DateTime.Now;
            initializeDigiClock();



        }

        private void initializeDigiClock()
        {
            digiClockText = GameObject.Find("digiClock").GetComponent<Text>();
            h_UP = GameObject.Find("H_Up").GetComponent<Button>();
            h_DOWN = GameObject.Find("H_Down").GetComponent<Button>();
            m_UP = GameObject.Find("M_Up").GetComponent<Button>();
            m_DOWN = GameObject.Find("M_Down").GetComponent<Button>();
            isAM = GameObject.Find("TimeOfTheDay").GetComponent<Button>();
            h_UP.onClick.AddListener(HourUp);
            h_DOWN.onClick.AddListener(HourDown);
            m_UP.onClick.AddListener(MinuteUp);
            m_DOWN.onClick.AddListener(MinuteDown);
            isAM.onClick.AddListener(changeAM);
            touchCoutner = 0;
        }

        private int touchCoutner;

        //Change AM value to PM and the other way around
        private void changeAM()
        {
            touchCoutner++;
            if (AM)
            {

                time = time.AddHours(-12);
            }
            else
            {

                time = time.AddHours(12);
            }
        }

        private void HourUp()
        {

            time = time.AddHours(1);

        }

        private void HourDown()
        {

            time = time.AddHours(-1);

        }

        private void MinuteUp()
        {

            time = time.AddMinutes(minuteStep);

        }

        private void MinuteDown()
        {

            time = time.AddMinutes(-minuteStep);

        }
        //Check if currently AM or PM 
        public Boolean detectTime(DateTime currentTime)
        {
            if (currentTime.Hour > 11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Update()
        {

            tickSound();

            AM = detectTime(time);
            //SET AM PM PARAMETERS
            if (AM)
            {
                isAM.GetComponent<Image>().sprite = sun;
            }
            else
            {
                isAM.GetComponent<Image>().sprite = sun_red;
  
             }
            //Set Digi clock time
            digiClockText.text = time.ToString("HH:mm");

            //TOUCH DETECTION
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                //IF OBJECT WAS HIT THEN
                if (Physics.Raycast(ray, out hit, touchAccuracy))
                {   //IF THE OBJECT IS THE ONE WE WERE LOOKIGN FOR
                    if (hit.transform.name == "hour")
                    {   //DEPENDING ON THE TIME OF THE DAY COUNT START POSITION OF OBJECT IN DEGREES
                        if (AM)
                        {
                            startZ = 360 - (time.Hour * 30);
                        }
                        else
                        {
                            startZ = 360 - ((time.Hour - 12) * 30);
                        }
                        hour = true;
                        touched = true;

                    }
                    else if (hit.transform.name == "minute")
                    {

                        startZMinute = 360 - (time.Minute * 6);
                        touched = true;
                        hour = false;
                    }


                }
                //IF THE RIGHT OBJECT WAS TOUCHED 
                if (touched)
                {   //CHCECK IF THE USER IS STILL HOLDING IT OR MOVING THE FINGER OVER THE SCREEN 
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        // get the touch position from the screen touch to world point
                        if (hour)
                        {
                            Vector3 relativePos = Camera.main.ScreenToWorldPoint(touch.position) - hours.transform.position;
                            relativePos.Normalize();
                            float rot_z = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
                            hours.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                        }
                        else
                        {
                            Vector3 relativePos = Camera.main.ScreenToWorldPoint(touch.position) - minutes.transform.position;
                            relativePos.Normalize();
                            float rot_z = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
                            minutes.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

                        }
                        return;

                    }
                    else
                    {
                        if (hour)
                        {
                            int transformZ = (int)Math.Round(hours.transform.eulerAngles.z);
                            if (transformZ <= 20 || transformZ >= 340)
                            {
                                transformZ = 360;
                            }
                            int timeDif = (int)((transformZ - startZ) / (-hoursToDegreees));
                            time = time.AddHours(timeDif);
                        }
                        else
                        {
                            int transformZMinute = (int)Math.Round(minutes.transform.eulerAngles.z);

                            int timeDifMinute = (int)((transformZMinute - startZMinute) / (-minutesToDegrees));

                            time = time.AddMinutes(timeDifMinute);
                        }
                        touched = false;

                        return;
                    }
                }
            }
            //HERE SET CURRENT TIME SHOWN ON CLOCK

            if (!touched)
            {


                DateTime currtime = DateTime.Now;
                tickSound();
                hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegreees);
                minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
                // seconds.localRotation = Quaternion.Euler(0f, 0f, currtime.Second * -secondsToDegrees);

            }




        }

        private void tickSound()
        {

            timer -= Time.deltaTime;

            if (timer <= 0 && roundTimer > 0)
            {

                tick.PlayOneShot(tick.clip);

                timer = 1f;
                roundTimer -= 1f;
            }
        }



    }
}
