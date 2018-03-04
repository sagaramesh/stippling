using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSequencer : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    private GameObject Slider;

    // Colors and corresponding colliders

    private GameObject col1;
    private Color32 C1 = new Color32(255, 98, 0, 255);
    private GameObject col2;
    private Color32 C2 = new Color32(255, 145, 0, 255);
    private GameObject col3;
    private Color32 C3 = new Color32(255, 200, 2, 255);
    private GameObject col4;
    private Color32 C4 = new Color32(255, 255, 2, 255);
    private GameObject col5;
    private Color32 C5 = new Color32(138, 201, 0, 255);
    private GameObject col6;
    private Color32 C6 = new Color32(8, 161, 105, 255);
    private GameObject col7;
    private Color32 C7 = new Color32(0, 177, 219, 255);
    private GameObject col8;
    private Color32 C8 = new Color32(16, 131, 230, 255);
    private GameObject col9;
    private Color32 C9 = new Color32(65, 76, 199, 255);
    private GameObject col10;
    private Color32 C10 = new Color32(127, 49, 179, 255);
    private GameObject col11;
    private Color32 C11 = new Color32(223, 48, 158, 255);
    private GameObject col12;
    private Color32 C12 = new Color32(212, 6, 6, 255);
    private GameObject col13;
    private Color32 C13 = new Color32(255, 255, 255, 255);
    private GameObject col14;
    private Color32 C14 = new Color32(128, 128, 128, 255);

    // Screen positions:

    private Vector3 screen1 = new Vector3(0f, 0f, 0f);
    private Vector3 screen2 = new Vector3(-14.4f, 0f, 0f);
    private Vector3 screen3 = new Vector3(-28.8f, 0f, 0f);
    private Vector3 screen4 = new Vector3(-43.2f, 0f, 0f);

    // Dynamic components:

    private GameObject s1Next;
    private bool s1NextActive = false;
    private GameObject s2Next;
    private bool s2NextActive = false;
    private GameObject check;
    private bool checkActive = false;

    private GameObject colorSelector;

    // Shapes:

    private GameObject pyramid;
    private GameObject cylinder;
    private GameObject sphere;
    private GameObject cube;

    // S3:

    private GameObject s3_1;
    private GameObject s3_2;
    private GameObject s3_3;
    private GameObject s3_4;
    private GameObject s3_5;

    private GameObject s3_check;
    private GameObject s3_x;

    // Standard:

    private Vector3 zeroScale = new Vector3(0f, 0f, 0f);
    private Vector3 fullScale = new Vector3(1f, 1f, 1f);
    private Color32 faded = new Color32(255, 255, 255, 255);

    // Tracked variables:

    // Script use:
    private Color32 selectedColor;
    // Data use:
    private string userColor;
    private string userShape;
    private int selectedRating = 0;
    private bool goodData;

    private bool ratingChosen = false;
    private bool validData = false;

    // Extras:

    private GameObject blackScreen;
    private bool complete = false;

	// Use this for initialization
	void Start () {

        LogData.NewPerson("\"" + System.DateTime.Now.ToString("dddd, MMMM dd, yyyy h:mm:ss tt") + "\"");

        Slider = GameObject.Find("Slider");

        col1 = GameObject.Find("C (1)");
        col2 = GameObject.Find("C (2)");
        col3 = GameObject.Find("C (3)");
        col4 = GameObject.Find("C (4)");
        col5 = GameObject.Find("C (5)");
        col6 = GameObject.Find("C (6)");
        col7 = GameObject.Find("C (7)");
        col8 = GameObject.Find("C (8)");
        col9 = GameObject.Find("C (9)");
        col10 = GameObject.Find("C (10)");
        col11= GameObject.Find("C (11)");
        col12 = GameObject.Find("C (12)");
        col13 = GameObject.Find("C (13)");
        col14 = GameObject.Find("C (14)");

        s1Next = GameObject.Find("S1_next");
        s2Next = GameObject.Find("S2_next");
        check = GameObject.Find("Check");

        colorSelector = GameObject.Find("S1_selector");
        colorSelector.transform.localPosition = zeroScale;
        colorSelector.transform.localScale = zeroScale;

        pyramid = GameObject.Find("S2_pyramid");
        cylinder = GameObject.Find("S2_cylinder");
        sphere = GameObject.Find("S2_sphere");
        cube = GameObject.Find("S2_cube");

        s3_1 = GameObject.Find("S3_1");
        s3_2 = GameObject.Find("S3_2");
        s3_3 = GameObject.Find("S3_3");
        s3_4 = GameObject.Find("S3_4");
        s3_5 = GameObject.Find("S3_5");

        s3_check = GameObject.Find(("S3_check"));
        s3_x = GameObject.Find(("S3_X"));
                         
        s1Next.transform.localScale = zeroScale;
        s2Next.transform.localScale = zeroScale;
        check.transform.localScale = zeroScale;

        blackScreen = GameObject.Find("FG");
		
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(OpeningFade(0.0f, 1.0f));
        s1Next.GetComponent<SpriteRenderer>().material.color = selectedColor;
        s2Next.GetComponent<SpriteRenderer>().material.color = selectedColor;

        if (ratingChosen && validData){
            iTween.ScaleTo(check, fullScale, 0.5f);
        }

        if (Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Next / check buttons:

                if (hit.transform.gameObject.name == "S1_next"){
                    iTween.MoveTo(Slider, screen2, 0.75f);
                }
                else if (hit.transform.gameObject.name == "S2_next")
                {
                    iTween.MoveTo(Slider, screen3, 0.75f);
                }
                else if (hit.transform.gameObject.name == "Check")
                {
                    iTween.MoveTo(Slider, screen4, 0.75f);
                }


                // SCREEN 1:

                if (hit.transform.gameObject.name == "C (1)"){
                    ColorSelector(new Vector3(col1.transform.localPosition.x, col1.transform.localPosition.y, col1.transform.localPosition.z + 0.02f), C1);
                    userColor = "C1";
                }
                else if (hit.transform.gameObject.name == "C (2)")
                {
                    ColorSelector(new Vector3(col2.transform.localPosition.x, col2.transform.localPosition.y, col2.transform.localPosition.z + 0.02f), C2);
                    userColor = "C2";
                }
                else if (hit.transform.gameObject.name == "C (3)")
                {
                    ColorSelector(new Vector3(col3.transform.localPosition.x, col3.transform.localPosition.y, col3.transform.localPosition.z + 0.02f), C3);
                    userColor = "C3";
                }
                else if (hit.transform.gameObject.name == "C (4)")
                {
                    ColorSelector(new Vector3(col4.transform.localPosition.x, col4.transform.localPosition.y, col4.transform.localPosition.z + 0.02f), C4);
                    userColor = "C4";
                }
                else if (hit.transform.gameObject.name == "C (5)")
                {
                    ColorSelector(new Vector3(col5.transform.localPosition.x, col5.transform.localPosition.y + 0.06f, col5.transform.localPosition.z + 0.02f), C5);
                    userColor = "C5";
                }
                else if (hit.transform.gameObject.name == "C (6)")
                {
                    ColorSelector(new Vector3(col6.transform.localPosition.x, col6.transform.localPosition.y + 0.06f, col6.transform.localPosition.z + 0.02f), C6);
                    userColor = "C6";
                }
                else if (hit.transform.gameObject.name == "C (7)")
                {
                    ColorSelector(new Vector3(col7.transform.localPosition.x, col7.transform.localPosition.y + 0.06f, col7.transform.localPosition.z + 0.02f), C7);
                    userColor = "C7";
                }
                else if (hit.transform.gameObject.name == "C (8)")
                {
                    ColorSelector(new Vector3(col8.transform.localPosition.x, col8.transform.localPosition.y + 0.06f, col8.transform.localPosition.z + 0.02f), C8);
                    userColor = "C8";
                }
                else if (hit.transform.gameObject.name == "C (9)")
                {
                    ColorSelector(new Vector3(col9.transform.localPosition.x, col9.transform.localPosition.y + 0.04f, col9.transform.localPosition.z + 0.02f), C9);
                    userColor = "C9";
                }
                else if (hit.transform.gameObject.name == "C (10)")
                {
                    ColorSelector(new Vector3(col10.transform.localPosition.x, col10.transform.localPosition.y + 0.04f, col10.transform.localPosition.z + 0.02f), C10);
                    userColor = "C10";
                }
                else if (hit.transform.gameObject.name == "C (11)")
                {
                    ColorSelector(new Vector3(col11.transform.localPosition.x, col11.transform.localPosition.y + 0.04f, col11.transform.localPosition.z + 0.02f), C11);
                    userColor = "C11";
                }
                else if (hit.transform.gameObject.name == "C (12)")
                {
                    ColorSelector(new Vector3(col12.transform.localPosition.x, col12.transform.localPosition.y + 0.04f, col12.transform.localPosition.z + 0.02f), C12);
                    userColor = "C12";
                }
                else if (hit.transform.gameObject.name == "C (13)")
                {
                    ColorSelector(new Vector3(col13.transform.localPosition.x, col13.transform.localPosition.y + 0.067f, col13.transform.localPosition.z + 0.02f), C13);
                    userColor = "C13";
                }
                else if (hit.transform.gameObject.name == "C (14)")
                {
                    ColorSelector(new Vector3(col14.transform.localPosition.x, col14.transform.localPosition.y + 0.067f, col14.transform.localPosition.z + 0.02f), C14);
                    userColor = "C14";
                }else{}

                // SCREEN 2:

                if (hit.transform.gameObject.name == "S2_pyramid"){
                    ShapeSelect(pyramid);

                    cylinder.GetComponent<SpriteRenderer>().material.color = faded;
                    sphere.GetComponent<SpriteRenderer>().material.color = faded;
                    cube.GetComponent<SpriteRenderer>().material.color = faded;

                    userShape = "Pyramid";
                }
                else if (hit.transform.gameObject.name == "S2_cylinder")
                {
                    ShapeSelect(cylinder);

                    pyramid.GetComponent<SpriteRenderer>().material.color = faded;
                    sphere.GetComponent<SpriteRenderer>().material.color = faded;
                    cube.GetComponent<SpriteRenderer>().material.color = faded;

                    userShape = "Cylinder";
                }
                else if (hit.transform.gameObject.name == "S2_sphere")
                {
                    ShapeSelect(sphere);

                    pyramid.GetComponent<SpriteRenderer>().material.color = faded;
                    cylinder.GetComponent<SpriteRenderer>().material.color = faded;
                    cube.GetComponent<SpriteRenderer>().material.color = faded;

                    userShape = "Sphere";
                }
                else if (hit.transform.gameObject.name == "S2_cube")
                {
                    ShapeSelect(cube);

                    pyramid.GetComponent<SpriteRenderer>().material.color = faded;
                    cylinder.GetComponent<SpriteRenderer>().material.color = faded;
                    sphere.GetComponent<SpriteRenderer>().material.color = faded;

                    userShape = "Cube";
                }

                // SCREEN 3:

                if (hit.transform.gameObject.name == "S3_1")
                {
                    Rating(s3_1);

                    s3_2.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_3.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_4.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_5.GetComponent<SpriteRenderer>().material.color = faded;

                    selectedRating = 1;
                } 
                else if (hit.transform.gameObject.name == "S3_2")
                {
                    Rating(s3_2);

                    s3_1.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_3.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_4.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_5.GetComponent<SpriteRenderer>().material.color = faded;

                    selectedRating = 2;
                }
                else if (hit.transform.gameObject.name == "S3_3")
                {
                    Rating(s3_3);

                    s3_1.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_2.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_4.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_5.GetComponent<SpriteRenderer>().material.color = faded;

                    selectedRating = 3;
                }
                else if (hit.transform.gameObject.name == "S3_4")
                {
                    Rating(s3_4);

                    s3_1.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_2.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_3.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_5.GetComponent<SpriteRenderer>().material.color = faded;

                    selectedRating = 4;
                }
                else if (hit.transform.gameObject.name == "S3_5")
                {
                    Rating(s3_5);

                    s3_1.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_2.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_3.GetComponent<SpriteRenderer>().material.color = faded;
                    s3_4.GetComponent<SpriteRenderer>().material.color = faded;

                    selectedRating = 5;
                }

                // S3 Check / X:

                if (hit.transform.gameObject.name == "S3_check")
                {
                    DataValidation(s3_check);
                    s3_x.GetComponent<SpriteRenderer>().material.color = faded;
                    goodData = true;
                } else if (hit.transform.gameObject.name == "S3_X")
                {
                    DataValidation(s3_x);
                    s3_check.GetComponent<SpriteRenderer>().material.color = faded;
                    goodData = false;
                }

                // Track data on spreadsheet:

                if (hit.transform.gameObject.name == "Check" && complete == false){
                    LogData.NewTrialResult(userColor);
                    LogData.NewTrialResult(userShape);
                    LogData.NewTrialResult(selectedRating.ToString());
                    LogData.NewTrialResult(goodData.ToString());
                    complete = true;
                }

            }
        }
	}

    void ColorSelector(Vector3 colorPos, Color32 chosenColor)
    {

        // Move color selector to correct position:
        colorSelector.transform.localPosition = colorPos;

        // Scale up on click:
        colorSelector.transform.localScale = zeroScale;
        iTween.ScaleTo(colorSelector, fullScale, 0.25f);

        // Change selected color:
        selectedColor = chosenColor;

        // Activate next button:
        if (s1NextActive == false)
        {
            iTween.ScaleTo(s1Next, fullScale, 0.5f);
            s1NextActive = true;
        }
        else
        {
            s1Next.transform.localScale = fullScale;
        }
    }

    void ShapeSelect(GameObject chosenShape){
        chosenShape.GetComponent<SpriteRenderer>().material.color = selectedColor;

        // Activate next button:
        if (s2NextActive == false)
        {
            iTween.ScaleTo(s2Next, fullScale, 0.5f);
            s2NextActive = true;
        }
        else
        {
            s2Next.transform.localScale = fullScale;
        }
    }

    void Rating(GameObject chosenRating)
    {
        chosenRating.GetComponent<SpriteRenderer>().material.color = selectedColor;
        ratingChosen = true;
    }

    void DataValidation(GameObject confirmationIcon)
    {
        confirmationIcon.GetComponent<SpriteRenderer>().material.color = selectedColor;
        validData = true;
    }

    IEnumerator OpeningFade(float intro_aValue, float intro_aTime)
    {
        float intro_alpha = blackScreen.GetComponent<SpriteRenderer>().material.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / intro_aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(intro_alpha, intro_aValue, t));
            blackScreen.GetComponent<SpriteRenderer>().material.color = newColor;

            yield return new WaitForEndOfFrame();
        }
    }
}
