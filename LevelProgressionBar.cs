using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionBar : MonoBehaviour
{
    public float levelProgression;
    public float level2Progression;
    public float level3Progression;
    public float loevelProgression;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public Slider enemyOneSlider;
    public Slider enemyTwoSlider;
    public Slider enemyThreeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelProgression > 0)
        {
            enemyOneSlider.value += Time.deltaTime/60;
            levelProgression += Time.deltaTime/4;
            if (levelProgression > 15)
            {
                enemy1.SetActive(true);
                levelProgression = loevelProgression;
            }
        }
        if (level2Progression > 0)
        {
            enemyTwoSlider.value += Time.deltaTime/80;
            level2Progression += Time.deltaTime/4;
            if (level2Progression > 20)
            {
                enemy2.SetActive(true);
                level2Progression = loevelProgression;
            }
        }
        if (level3Progression > 0)
        {
            enemyThreeSlider.value += Time.deltaTime / 100;
            level3Progression += Time.deltaTime / 4;
            if (level3Progression > 25)
            {
                enemy3.SetActive(true);
                level3Progression = loevelProgression;
            }
        }

    }
    public void valueLe2Pro(float value)
    {
        level2Progression += value;
    }
    public void valueLe2Retry(float value)
    {
        level2Progression += value;
    }

    public void valueLe3Pro(float value2)
    {
        level3Progression += value2;
    }
}
