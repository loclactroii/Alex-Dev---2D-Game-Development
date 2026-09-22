using UnityEngine;

public interface ICounterable
{
    public bool CanBeCouner { get; }
    public void HandleCounter();
}
