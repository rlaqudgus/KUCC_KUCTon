using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // player
    // timer
    public UIManager ui;
    public int[] dateCount = { 9, 1 };
    [SerializeField] int timeInterval = 3;
    public float timer;
    [SerializeField] AudioSource audioNormal, audioBoss;
    [SerializeField] GameObject objWarning;

    // Start is called before the first frame update
    void Start()
    {
        objWarning.SetActive(false);
        audioNormal.Play();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (dateCount[0] == 10 && dateCount[1] < 27)
        {
            if (audioNormal.isPlaying) { audioNormal.Stop(); }
            if (!audioBoss.isPlaying) { audioBoss.Play(); }
        }
        else if (dateCount[0] == 12)
        {
            if (audioNormal.isPlaying) { audioNormal.Stop(); }
            if (!audioBoss.isPlaying) { audioBoss.Play(); }
        }
        else
        {
            if (!audioNormal.isPlaying) { audioNormal.Play(); }
            if (audioBoss.isPlaying) { audioBoss.Stop(); }
        }

        timecheck();
        uiCheck();
    }

    IEnumerator showWarning()
    {
        objWarning.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        objWarning.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        objWarning.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        objWarning.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        objWarning.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        objWarning.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        objWarning.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        objWarning.SetActive(false);
    }

    void timecheck()
    {
        if (timer > timeInterval)
        {
            dateCount[1]++;
            timer = 0;
            switch (dateCount[0])
            {
                case 9:
                    if (dateCount[1] == 31) { dateCount[0]++; dateCount[1] = 1; }
                    if (dateCount[1] == 28) { Debug.Log("show "); StartCoroutine(showWarning()); }
                    break;
                case 11:
                    if (dateCount[1] == 31) { dateCount[0]++; dateCount[1] = 1; }
                    if (dateCount[1] == 28) { StartCoroutine(showWarning()); }
                    break;

                case 10:
                    if (dateCount[1] == 32) { dateCount[0]++; dateCount[1] = 1; }
                    break;

                case 12:
                    if (dateCount[1] == 22) { SceneManager.LoadScene("Clear");} //넘어가기
                   break;

            }

        }
    }

 
    void uiCheck()
    {
        ui.dateCount.text = dateCount[0].ToString() + "월" + " " + dateCount[1].ToString() + "일";
    }

    
}
