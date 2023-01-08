using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class GameplayController : MonoBehaviour
{
    public Scene currentScene;
    public LevelObject levelData;

    public GameObject optionsPanel;
    public GameObject controlsPanel;
    public GameObject finishPanel;
    public GameObject deathPanel;

    public TextMeshProUGUI carrotFinishText;
    public TextMeshProUGUI finishTime;

    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public AudioClip[] sfx;
    public AudioSource sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        finishPanel.SetActive(false);
        deathPanel.SetActive(false);
        levelData.isFinished = false;
        levelData.currentCarrots = 0;
        Time.timeScale = 1;
        levelData.timeSpentInLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelData.isFinished == true)
		{
            finishPanel.SetActive(true);
            Time.timeScale = 0;
		}

        levelData.timeSpentInLevel += Time.deltaTime;

        carrotFinishText.text = levelData.currentCarrots + " / " + levelData.carrotTotal;
        finishTime.text = Mathf.Round(levelData.timeSpentInLevel).ToString() + " s";
    }

    public void SetMusicLevel(float sliderValue)
	{
        musicMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
	}

    public void SetSFXLevel(float sliderValue)
	{
        sfxMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
	}

    public void ASFXTest()
	{
        int x = Random.Range(0, 2);
        sfxPlayer.clip = sfx[x];
        sfxPlayer.Play();
	}

    public void StartGame()
	{
        SceneManager.LoadScene(1);
	}

    public void ShowOptions()
	{
        optionsPanel.SetActive(true);
    }

    public void HideOptions()
	{
        optionsPanel.SetActive(false);
    }

    public void ShowControls()
	{
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
	{
        controlsPanel.SetActive(false);
    }

    public void PreviousLevel()
	{
        SceneManager.LoadScene(levelData.nextLevel - 2);
	}

    public void ReloadLevel()
	{
        SceneManager.LoadScene(currentScene.name);
	}

    public void SkipLevel()
	{
        SceneManager.LoadScene(levelData.nextLevel);
	}

    public void ReturnToTilescreen()
	{
        SceneManager.LoadScene(0);
	}

}
