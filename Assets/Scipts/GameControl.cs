using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject duck1,duck2,duck3,bomb,rb;
    public double spawnTime,spawnBomb,spawnRB;
    double m_spawnTime1, m_spawnTime2, m_spawnTime3, m_bomb, m_rb ;
    int m_score, highsore=0;
    int m_health;
    bool m_dead;
    public AudioSource quack,bom,rain,click;
    public Image[] health;
    UI m_ui;
    public Text high,set;
    // Start is called before the first frame update
    void Start()
    {
        m_ui = FindObjectOfType<UI>();
        m_ui.SetScoreText("Score: " + m_score);
        m_score = 0;
        m_health= 3;
        m_spawnTime1 = 2;
        m_spawnTime2 = 5;
        m_spawnTime3 = 10;
        m_bomb = 20;
        m_rb = 30;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime1-= Time.deltaTime;
        m_spawnTime2-= Time.deltaTime*1.25;
        m_spawnTime3-= Time.deltaTime*1.5;
        m_bomb -= Time.deltaTime;
        m_rb -= Time.deltaTime;
        if (m_dead)
        {
            health[0].enabled=false;
            m_ui.SetScoreText("");
            high.text = "High Score: " + highsore.ToString();
            set.text = "Your Score: " + m_score.ToString();
            m_ui.ShowGameoverPanel(true);
            m_health = 3;
            m_spawnTime1 = 2;
            m_spawnTime2 = 5;
            m_spawnTime3 = 10;
            m_bomb = 20;
            m_rb = 30;
            return;
        }
        for(int i=0;i<health.Length;i++)
        {
            if(i<m_health)
            {
                health[i].enabled= true;
            }
            else health[i].enabled = false;
        }
        if(m_spawnTime1<=0)
        {
            SpawnLV1();
            m_spawnTime1 = spawnTime;
        }
        if(m_spawnTime2<=0)
        {
            SpawnLV2();
            m_spawnTime2 = spawnTime;
        }
        if(m_spawnTime3<=0)
        {
            SpawnLV3();
            m_spawnTime3 = spawnTime;
        }
        if(m_bomb<=0)
        {
            SpawnBomb();
            m_bomb = spawnBomb;
        }
        if (m_rb <= 0)
        {
            SpawnRB();
            m_rb = spawnRB;
        }
    }
    public void Click()
    {
        click.Play();
    }
    public void SpawnLV1()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-9, 9), 6);
        if(duck1)
        {
            Instantiate(duck1,spawnPos,Quaternion.identity);
        }
    }
    public void SpawnLV2()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-9, 9), 6);
        if (duck2)
        {
            Instantiate(duck2, spawnPos, Quaternion.identity);
        }
    }
    public void SpawnLV3()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-9, 9), 6);
        if (duck3)
        {
            Instantiate(duck3, spawnPos, Quaternion.identity);
        }
    }
    public void SpawnBomb()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-9, 9), 6);
        if (bomb)
        {
            Instantiate(bomb, spawnPos, Quaternion.identity);
        }
    }
    public void SpawnRB()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-9, 9), 6);
        if (rb)
        {
            Instantiate(rb, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore(int score)
    { 
        m_score = score; 
    }
    public int Score() 
    { 
        return m_score; 
    }
    public void I1()
    {
        quack.Play();
        m_score++;
        if (m_score > highsore) highsore = m_score;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public void I2()
    {
        quack.Play();
        m_score +=2;
        if(m_score >highsore) highsore= m_score;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public void I3()
    {
        quack.Play();
        m_score +=3;
        if (m_score > highsore) highsore = m_score;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public void Bomb()
    {
        bom.Play();
        m_score /= 2;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public void Rainbow()
    {
        rain.Play();
        if (m_health == 5) return;
        else m_health++;
    }
    public bool isDead() 
    { 
        return m_dead; 
    }
    public void SetGameover()
    {
        m_health--;
        if (m_health == 0)
        {
            m_dead = true;
        }
    }
    public void Replay()
    {
        m_score = 0;
        m_dead = false;
        m_ui.SetScoreText("Score: " + m_score);
        m_ui.ShowGameoverPanel(false);
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
