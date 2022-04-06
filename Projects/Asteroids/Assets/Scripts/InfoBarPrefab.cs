using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBarPrefab : MonoBehaviour
{
    List<Image> Healts;
    Image BulletIcon;
    Image AsteroidIcon;
    Image EnemyIcon;
    Text BulletIndicator;
    Text AsteroidIndicator;
    Text EnemyIndicator;
    [SerializeField]
    public int DamageCounter = 0;
    public int BulletCounter = 10;
    int AsteroidCounter = 0;
    int EnemyCounter = 0;
    Color activeHealth = new Color(1f, 1f, 1f); //Original
    Color inactiveHealth = new Color(0.412f, 0.412f, 0.412f); //DimGray

    // Start is called before the first frame update
    void Start()
    {
        Healts = new List<Image>();

        Canvas canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>();

        Text[] indicators = canvas.GetComponentsInChildren<Text>();
        Image[] icons = canvas.GetComponentsInChildren<Image>();

        foreach (var c in indicators)
        {
            if (c.CompareTag("bulletCounter"))
                BulletIndicator = c;

            if (c.CompareTag("enemyCounter"))
                EnemyIndicator = c;

            if (c.CompareTag("asteroidCounter"))
                AsteroidIndicator = c;
        }

        foreach (var i in icons)
        {
            if (i.CompareTag("Health1"))
                Healts.Add(i);

            if (i.CompareTag("Health2"))
                Healts.Add(i);

            if (i.CompareTag("Health3"))
                Healts.Add(i);

            if (i.CompareTag("BulletIcon"))
                BulletIcon = i;

            if (i.CompareTag("AsteroidIcon"))
                AsteroidIcon = i;

            if (i.CompareTag("EnemyIcon"))
                EnemyIcon = i;
        }

        Reset();
    }

    // Update is called once per frame
    void Update()
    {

        if (DamageCounter > 0)
            Healts[Healts.Count - DamageCounter].color = inactiveHealth;

        BulletIndicator.text = BulletCounter.ToString();
        EnemyIndicator.text = EnemyCounter.ToString();
        AsteroidIndicator.text = AsteroidCounter.ToString();
    }

    public void IncreaseAsteroidCounter()
    {
        AsteroidCounter++;
    }

    public void IncreaseEnemyCounter()
    {
        EnemyCounter++;
    }

    public void DecreaseBulletCounter()
    {
        if (BulletCounter > 0) BulletCounter--;
    }

    public void UpdateDamage()
    {
        if (DamageCounter <= 3) DamageCounter++;
        if (DamageCounter > 3) DamageCounter = 0;
    }

    public void Reset()
    {
        DamageCounter = 0;
        BulletCounter = 10;
        AsteroidCounter = 0;
        EnemyCounter = 0;
        Healts[0].color = activeHealth;
        Healts[1].color = activeHealth;
        Healts[2].color = activeHealth;
        BulletIndicator.text = BulletCounter.ToString();
        EnemyIndicator.text = EnemyCounter.ToString();
        AsteroidIndicator.text = AsteroidCounter.ToString();
    }
}
