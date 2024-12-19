using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroController : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (introText.rectTransform.localPosition.y < 791)
        {
            introText.rectTransform.Translate(movement * Time.deltaTime);
        }

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void LoadTestScene()
    {
        SceneManager.LoadScene("Test Scene");
    }
}
