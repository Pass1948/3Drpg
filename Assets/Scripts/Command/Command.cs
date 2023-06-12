using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public abstract class Command
{
    bool _isExecuting = false;
    public bool IsExecuting { get => _isExecuting; }
    public async void Execute()
    {
        _isExecuting = true;
        await AsyncExecuter();
        _isExecuting = false;
    }

    protected abstract Task AsyncExecuter();
}
