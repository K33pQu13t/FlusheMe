namespace FlusheMe.Base;

/// <summary>
/// Interface for configs which should be cleared after they processed
/// </summary>
public interface IAutoClearOnProcessed
{
    /// <summary>
    /// Should this config be cleared after it has processed
    /// </summary>
    public bool? AutoClearOnProcessed { get; set; }
}