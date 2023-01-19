using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CommandLog
{
    public static Queue<Command> commands = new Queue<Command>();
}
class Invoker
{
    private Command moveCommand;
    public bool disableLog = false;

    

    public void SetCommand(Command command)
    {
        moveCommand = command;
    }

    public void ExecuteCommand(Command command)
    {
        if (!disableLog)
        {
            //CommandLog.commands.Enqueue(moveCommand);
        }

        Debug.Log(command);
        moveCommand.Execute();
    }


}
