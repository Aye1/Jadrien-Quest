﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;
using System;

public class UIManager : MonoBehaviour {

    public DualityBar mentalBar;
    public DualityBar healthBar;
    public Player player;
    public GameController gameController;
    public Canvas pauseMenu;
    public Text spiritCount;

    private BlackScreen _blackScreen;
     

	// Use this for initialization
	void Start () {
        _blackScreen = GetComponentInChildren<BlackScreen>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(mentalBar != null && player != null)
        {
            mentalBar.CurrentValue = player.Mental;
        }
        if(healthBar != null && healthBar != null && player != null)
        {
            healthBar.CurrentValue = player.Health;
        }
        if (spiritCount != null && player != null)
        {
            spiritCount.text = "Spirit: " + player.Spirit;
        }
        pauseMenu.enabled = gameController.pause;

	}

    public void LaunchBlackScreenTransition()
    {
        if (_blackScreen != null)
        {
            _blackScreen.LaunchTransition();
        }
        else
        {
            Debug.Log("Black screen not found");
        }
    }
}
