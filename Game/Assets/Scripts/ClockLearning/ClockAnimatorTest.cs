using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class ClockAnimatorTest : MonoBehaviour
    {

        private const float
            hoursToDegreees = 360f / 12f,
            minutesToDegrees = 360f / 60f;
        //  secondsToDegrees = 360f / 60f;

        public Transform hours, minutes;// seconds;
        public AudioSource tick, success, fail;
        public float roundTimer = 60f;
        private bool touched;
        private int startZ, startZMinute;
        private int touchAccuracy;
        private GameObject go, db;
        private Text debuger;
        //DIGI
        private Text digiClockText;
        private DateTime time;
        private int minuteStep;
        private bool isAM;
        private Button h_UP, h_DOWN, m_UP, m_DOWN;
        private bool hour;
        private Animator anim;

        private void Start()
        {
            anim = GameObject.Find("basic").GetComponent<Animator>();
            //for debugging purposes
            //   db = GameObject.Find("DEB");
            // debuger = db.GetComponentInChildren<Text>();
            //Radius around touchable object
            touchAccuracy = 100;
            //Checking if any objekt is currently being touched
            touched = false;
            //Check which object was chosen - hour or minute
            hour = true;
            minuteStep = 5;
            time = DateTime.Now;
            initializeDigiClock();
            generateRandomTime();
            anim.SetBool("isHappy", false);
            anim.SetBool("isSad", false);
            counter = 0;


        }
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

        private void initializeDigiClock()
        {
            digiClockText = GameObject.Find("digiClock").GetComponent<Text>();


        }

        private DateTime randomTime;
        public static int RoundTo(int value)
        {
            var remainder = value % 5;
            var result = remainder < 5 - remainder
                ? (value - remainder) //round down
                : (value + (5 - remainder)); //round up
            return result;
        }
        private void generateRandomTime()
        {
            System.Random rnd = new System.Random();
            int hour = rnd.Next(0, 25);
            int minute = RoundTo(rnd.Next(0, 55));
            randomTime = new DateTime(time.Year, time.Month, time.Day, hour, minute, 0);
            isAM = detectTime(randomTime);

        }

        private int counter;
        public void Update()
        {

            if (counter == 50)
            {
                anim.SetBool("isHappy", false);
                anim.SetBool("isSad", false);

            }
            else
            {
                counter++;
            }



            //Set Digi clock time
            digiClockText.text = randomTime.ToString("HH:mm");

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
                        if (isAM)
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
                {

                    //CHCECK IF THE USER IS STILL HOLDING IT OR MOVING THE FINGER OVER THE SCREEN 
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
                        if (checkTime())
                        {
                            generateRandomTime();
                            successSound();
                            counter = 0;
                            anim.SetBool("isHappy", true);



                        }
                        else
                        {
                            failSound();
                            counter = 0;
                            anim.SetBool("isSad", true);




                        }

                        return;
                    }
                }
            }
            //HERE SET CURRENT TIME SHOWN ON CLOCK

            if (!touched)
            {


                DateTime currtime = DateTime.Now;

                hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegreees);
                minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
                // seconds.localRotation = Quaternion.Euler(0f, 0f, currtime.Second * -secondsToDegrees);

            }




        }

        private bool checkTime()
        {
            if (randomTime.Hour == time.Hour)
            {

                if (randomTime.Minute > time.Minute - 2 && randomTime.Minute < time.Minute + 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void failSound()
        {


            fail.PlayOneShot(fail.clip);

        }

        private void successSound()
        {


            success.PlayOneShot(success.clip);

        }

    }
}
