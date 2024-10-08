using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject retryBtn;
    public GameObject fatCat;
    public GameObject pirateCat;

    public RectTransform levelFront;
    public Text levelTxt;

    int level = 0;
    int score = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);

        // lv.1 10% 확률로 고양이를 더 생성해준다.
        if(level == 1)
        {
            int p = Random.Range(0, 10);
            if(p < 1) Instantiate(normalCat);
        }
        // lv.2 30% 확률로 고양이를 더 생성해준다.
        else if(level == 2)
        {
            int p = Random.Range(0, 10);
            if (p < 3) Instantiate(normalCat);
        }
        // lv.3 뚱뚱한 고양이를 생성해준다.
        else if (level == 3)
        {
            Instantiate(fatCat);
        }
        // lv.4 해적 고양이를 생성해준다.
        else if (level >= 4)
        {
            Instantiate(pirateCat);
        }

    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        score++;
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1f, 1f);
    }
}
