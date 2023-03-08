namespace FlusheMe.Base;

public interface IDeferredExecution
{
    /// <summary>
    /// How much days must pass to execute. Null for never
    /// </summary>
    public int? DaysAwayToProcess { get; set; }
}