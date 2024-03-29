﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermode : MonoBehaviour
{
    public static Playermode instance;

    //This allows me to test for if the players are fused or not, allowing me to lock off certain code so that we don't get stuck in a fission/fusion loop
    private bool playerFused = true;
    //Allows fusion and fission to be bound to the same button
    private int coolDown = 0;

    //Just public slots for the prefab players
    public GameObject defaultPlayer;
    public GameObject coldPlayer;
    public GameObject hotPlayer;

    //These are for instantiating and destroying without causing issues with deleting files
    private GameObject cloneDefaultPlayer;
    private GameObject cloneColdPlayer;
    private GameObject cloneHotPlayer;

    //These are so I can access the position of the instantiated players, so that I may instantiate again in relation to them
    private Transform defaultPlayerPosition;
    private Transform coldPlayerPosition;
    private Transform hotPlayerPosition;

    //These help with instantiating the fused player
    private float distanceBetweenFission;
    private Vector3 averageBetweenFission;

    void Start()
    {
        instance = this;



        Setup();
    }


    public void Setup()
    {
        //Instantiates the default player at the begining of the game at 0,0,0
        cloneDefaultPlayer = Instantiate(defaultPlayer, transform.position, Quaternion.identity) as GameObject;
    }


    void Update()
    {
        //MOVE THIS INTO A GM SCRIPT BECAUSE IT DOESN'T NEED TO BE HERE ASDFJKLNGKAWSUEBVIHBASK:VOWOBLADIBFLIKA
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (playerFused == true)
        {
            if (coolDown <= 0)
            {
                //gets the fused player's position every single frame
                defaultPlayerPosition = cloneDefaultPlayer.transform;


                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Destroys fused player
                    Destroy(cloneDefaultPlayer);
                    //instantiates fission players
                    cloneColdPlayer = Instantiate(coldPlayer, defaultPlayerPosition.position, Quaternion.identity) as GameObject;
                    cloneHotPlayer = Instantiate(hotPlayer, defaultPlayerPosition.position, Quaternion.identity) as GameObject;
                    //stops this code from running again
                    playerFused = false;
                    coolDown = 1;
                }
            }   
        }

        if (playerFused == false)
        {
            if (coolDown <= 0)
            {
                //Gets orange fission's position
                hotPlayerPosition = cloneHotPlayer.transform;
                //Gets cold fission's position
                coldPlayerPosition = cloneColdPlayer.transform;
                //Gets the exact distance between them, for proximity code later
                distanceBetweenFission = Vector3.Distance(coldPlayerPosition.position, hotPlayerPosition.position);
                //Gets the exact position between the 2 fissions. this is where we will instantiate the fused player
                averageBetweenFission = Vector3.Lerp(coldPlayerPosition.transform.position, hotPlayerPosition.transform.position, 0.5f);

                //This tests that they are close enough to fuse
                if (distanceBetweenFission <= 1.5f)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        //Destroys fission players
                        Destroy(cloneColdPlayer);
                        Destroy(cloneHotPlayer);
                        //Instantiate fused player
                        cloneDefaultPlayer = Instantiate(defaultPlayer, averageBetweenFission, Quaternion.identity) as GameObject;
                        //stops this code from running again
                        playerFused = true;
                    }
                }
            }

        }
        //This is a one frame cooldown timer to make sure that the fusion code doesn't run on the same frame as the fission code
        if (coolDown > 0)
        {
            coolDown--;
        }
    }
}
