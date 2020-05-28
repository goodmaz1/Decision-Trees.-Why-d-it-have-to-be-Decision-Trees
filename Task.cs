using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Task 
{

    public abstract bool run();
    
    public bool isSuccess = false;
    public bool taskFinished = false;
   
}

public class Selector : Task   //as shown in Millington, pg 346 (uses the first task to work)
{
    List<Task> children;
    Task currentTask;

    public Selector (List<Task> allTasks)
    {
        children = allTasks;
    }


    public override bool run()
    {
        foreach (Task c in children)

        {
           if( c.run() == true)
           {
                return  true;
           }
           
        }
        return false;
    }
}


public class Sequencer : Task //as shown in Millington, pg 346 (not sure what the difference is between this and Selector, or how to really use it...)
{
    List<Task> children;
    Task currentTask;

    public Sequencer(List<Task> allTasks)
    {
        children = allTasks;
    }


    public override bool run()
    {
        foreach (Task c in children)

        {
            if (c.run() != true)
            {
                return false;
            }

        }
        return true;
    }
}


public class isDoorClosed : Task //checks if door is closed and returns true if closed, false if open
{
    Door door;

    public isDoorClosed(Door theDoor)
    {
        door = theDoor;
    }

    public override bool run()
    {
        if (door.closed == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}

public class isDoorLocked : Task //checks if door is locked and returns true if closed, false if open
{
    Door door;

    public isDoorLocked(Door theDoor)
    {
        door = theDoor;
    }

    public override bool run()
    {
        if (door.locked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}



public class DoorOpen : Task
{
    Door door;

    public DoorOpen(Door theDoor)
    {
        door = theDoor;
    }

    public override bool run()
    {
        door.open();
        return true;
    }

}

public class moveTowardTarget : Task
{
    GameObject target;
    GameObject player;

    public moveTowardTarget(GameObject Player1, GameObject target1)
    {
        player = Player1;
        target = target1;
    }

    public override bool run()
    {
        Vector3 seekDirection = target.transform.position - player.transform.position;
        Debug.Log("Here2" + seekDirection);
        seekDirection.Normalize();
        seekDirection *= 5;
        player.transform.position += seekDirection * Time.deltaTime;

        return true;
    }

}