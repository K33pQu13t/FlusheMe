using FlusheMe.DTO.ResponsibilityChain.Base;
using FlusheMe.Services.ResponsibilityChain.Base;

namespace FlusheMe.Services.ResponsibilityChain;

/// <summary>
/// Abstaction of element of chain of responsibility
/// </summary>
public class ResponsibilityChainHandler : IHandler
{
    /// <summary>
    /// Argument to pass some data to handler instance
    /// </summary>
    protected readonly IHandlerArgument? _argument;

    /// <summary>
    /// Handler to call next
    /// </summary>
    private ResponsibilityChainHandler? _nextHandler;

    /// <param name="argument">some data for handler instance</param>
    public ResponsibilityChainHandler(IHandlerArgument? argument = null)
    {
        _argument = argument;
    }

    /// <summary>
    /// Adds handler to last node of chain, so it would be rised last
    /// </summary>
    /// <param name="handler"></param>
    public void AddHandlerToEndOfChain(ResponsibilityChainHandler? handler)
    {
        if (_nextHandler != null)
        {
            _nextHandler.AddHandlerToEndOfChain(handler);
            return;
        }

        _nextHandler = handler;
    }

    /// <summary>
    /// Handle method and rise next handler.
    /// First added handler would be rised first.
    /// Base method just rises next handler with no logic before
    /// </summary>
    public virtual void Handle()
    {
        _nextHandler?.Handle();
    }
}