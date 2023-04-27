using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class State<TStateID>
{
    public StateMachine<TStateID> StateMachine { get; set; }

    public virtual void OnEnter() { OnResume(); }
    public virtual void OnExit() { OnSuspend(); }
    public virtual void OnSuspend() { }
    public virtual void OnResume() { }
}
