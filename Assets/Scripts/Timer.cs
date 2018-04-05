using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float multiplier = 10000.0f;

    /// INPUT VARIBLES
    public GUIStyle timerStyle;
    public bool countdown = false; //switches between countdown and countup 

    public float hours = 24f;
    public float minutes = 0f;
    public float seconds = 0f;

    public bool printDebug = false;

    /// TIMER VARIABLES
    private bool pauseTimer = false; //(up)pauses timer

    private float timer = 0f;
    private float sec = 0f;
    private float min = 0f;
    private float hrs = 0f;

    /// DISPLAY VARIABLES
    private string strHours = "00";
    private string strMinutes = "00";
    private string strSeconds = "00";

    public string strHrs = "00";
    public string strMin = "00";
    public string strSec = "00";

    private string message = "Timing...";

    void Start()
    {
        if (!countdown)
        {
            message = "Count Up Timer initiated";
            sec = 0f;
            min = 0f;
            hrs = 0f;
        }
        else
        {
            message = "Count Down Timer initiated";
            sec = seconds;
            min = minutes;
            hrs = hours;
        }//end if
        if (printDebug) print("TimerJS - Countdown timer: " + countdown + ", " + message);
    }//end start

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            print(strHrs + ":" + strMin + ":" + strSec);

            hrs = 0;
            min = 0;
            sec = 0;

        }
        else
        {
        }

        if (Input.GetKeyUp("space"))
        {
            if (pauseTimer)
            {
                pauseTimer = false;
            }
            else
            {
                pauseTimer = true;
            }//end if
            if (printDebug) print("TimerCS - Paused: " + pauseTimer);
        }//end if

        if (pauseTimer)
        {
            message = "Timer paused";
            Time.timeScale = 0;
        }
        else
        {
            //message = "Timer resumed";
            Time.timeScale = 1;
        }//end if

        if (seconds > 59)
        {
            message = "Seconds must be less than 59!";
            return;
        }
        else if (minutes > 59)
        {
            message = "Minutes must be less than 59!";
        }
        else
        {
            FindTimer();
        }//end if
    }//end update

    /* TIMER FUNCTIONS */
    //Checks which Timer has been initiated
    void FindTimer()
    {
        if (!countdown)
        {
            CountUp();
        }
        else
        {
            CountDown();
        }//end if
    }//end FindTimer

    //Timer starts at 00:00:00 and counts up until reaches Time limit

    void CountUp()
    {
        // Eliminating seconds from this:
        timer += (Time.deltaTime * multiplier);

        if (timer >= 1f)
        {
            min++;
            timer = 0f;
        }//end if
        /*
        if (sec >= 60)
        {
            min++;
            sec = 0f;
        }//end if
        */
        if (min >= 60)
        {
            hrs++;
            min = 0f;
        }//end if

        if (sec >= seconds && min >= minutes && hrs >= hours)
        {
            sec = seconds;
            min = minutes;
            hrs = hours;

            message = "Time limit reached!";
            if (printDebug) print("TimerCS - Out of time!");
            ///----- TODO: UP -----\\\
        }//end if
    }//end countUp

    //Timer starts at specified time and counts down until it reaches 00:00:00
    void CountDown()
    {
        timer -= Time.deltaTime;

        if (timer <= -1f)
        {
            sec--;
            timer = 0f;
        }//end if

        if (hrs <= 0f)
        {
            hrs = 0f;
        }//end if       

        if (min <= 0f)
        {
            hrs--;
            min = 59f;
        }//end if

        if (sec <= 0f)
        {
            min--;
            sec = 59f;
        }//end if

        if (sec <= 0 && min <= 0 && hrs <= 0)
        {
            sec = 0;
            min = 0;
            hrs = 0;

            message = "Time's Up!";
            if (printDebug) print("TimerCS - Out of time!");
            ///----- TODO: DOWN -----\\\
        }//end if
    }//end countDown

    void FormatTimer()
    {
        if (sec < 10)
        {
            strSec = "0" + sec.ToString();
        }
        else
        {
            strSec = sec.ToString();
        }//end if

        if (min < 10)
        {
            strMin = "0" + min.ToString();
        }
        else
        {
            strMin = min.ToString();
        }//end if

        if (hrs < 10)
        {
            strHrs = "0" + hrs.ToString();
        }
        else
        {
            strHrs = hrs.ToString();
        }//end if

        if (seconds < 10)
        {
            strSeconds = "0" + seconds.ToString();
        }
        else
        {
            strSeconds = seconds.ToString();
        }//end if

        if (minutes < 10)
        {
            strMinutes = "0" + minutes.ToString();
        }
        else
        {
            strMinutes = minutes.ToString();
        }//end if

        if (hours < 10)
        {
            strHours = "0" + hours.ToString();
        }
        else
        {
            strHours = hours.ToString();
        }//end if
    }//end formatTimer

    /* DISPLAY TIMER */
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 90, 300, 30), "TIMER (C#)", timerStyle);
        FormatTimer();
        if (!countdown)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 45, 300, 90), strHrs + ":" + strMin +  " / " + strHours + ":" + strMinutes + ":" + strSeconds + "\n" + message + "\nPress Space to (Un)pause timer", timerStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 45, 300, 90), strHrs + ":" + strMin + ":" + strSec + "\n" + message + "\nPress Space to (Un)pause timer.", timerStyle);
        }//end if
    }//end onGui

    /* GETTER & SETTERS */
    public bool Paused
    {
        get { return pauseTimer; }
        set { pauseTimer = value; }
    }//end if

    public string Message
    {
        get { return message; }
        set { message = value; }
    }//end message

    public float Sec
    {
        get { return sec; }
    }//end seconds

    public float Min
    {
        get { return min; }
    }//end min

    public float Hrs
    {
        get { return hrs; }
    }//end hrs

}//end class