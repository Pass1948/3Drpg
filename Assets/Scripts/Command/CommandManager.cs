using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CommandManager : MonoBehaviour
{
   public Player selectedPlayer;

    public Command activeCommand;

    Queue<Command> QueueCommands = new Queue<Command>();

    private void Start()
    {
        activeCommand = new MoveCommand(selectedPlayer, selectedPlayer.transform.position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = 0;
            QueueCommands.Enqueue(new MoveCommand(selectedPlayer, target));
        }
        

        if (!activeCommand.IsExecuting && QueueCommands.Count > 0)
        {
            activeCommand = QueueCommands.Dequeue();
            activeCommand.Execute();
        }
    }
}
