using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MoveCommand : Command
{
    Vector3 target;
    Player player;


    public MoveCommand(Player player, Vector3 target)
    {
        this.player = player;
        this.target = target;
    }


    protected override async Task AsyncExecuter()
    {
        while (player.transform.position != target)
        {
            player.transform.position = Vector3.MoveTowards
                (
                player.transform.position,
                target,
                0.05f
                );
            await Task.Delay(20);
        }
    }

  
}
