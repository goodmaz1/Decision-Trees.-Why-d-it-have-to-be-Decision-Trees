using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indy : MonoBehaviour
{

    public List<Task> toDoList;
    public Door bigDoor;
    public GameObject Treasure;
    Task CurrentTask;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            CurrentTask = doTheThing();         
            CurrentTask.run();
                       
        }
    }


    Task doTheThing()
    {

      
        List<Task> getStuffDoneList = new List<Task>();


        Task CheckIfDoorLocked = new isDoorLocked(bigDoor);
        Task openTheDoorKronk = new DoorOpen(bigDoor);
        getStuffDoneList.Add(CheckIfDoorLocked);
        getStuffDoneList.Add(openTheDoorKronk);
        Sequencer cmonInDoorsUnlocked = new Sequencer(getStuffDoneList);


        List<Task> goGetIt = new List<Task>();
        Task moveForward = new moveTowardTarget(this.gameObject, bigDoor.gameObject);
        Task getTreasure = new moveTowardTarget(this.gameObject, Treasure.gameObject);
        goGetIt.Add(moveForward);
        goGetIt.Add(getTreasure);
        Sequencer moveAlready = new Sequencer(goGetIt);

        List<Task> goGetTheTreasureIndy = new List<Task>();
        goGetTheTreasureIndy.Add(cmonInDoorsUnlocked);
        goGetTheTreasureIndy.Add(moveAlready);
        Selector doItNow = new Selector(goGetTheTreasureIndy);

        return doItNow;
        
    }

}

