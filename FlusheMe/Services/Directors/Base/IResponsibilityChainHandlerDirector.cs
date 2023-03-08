using FlusheMe.DTO.Directors.Base;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services.Directors.Base;

public interface IResponsibilityChainHandlerDirector<TArgument>
    where TArgument : IDirectorArgument
{
    /// <summary>
    /// Get chain of responsibilities first element,
    /// which can contain further handlers
    /// </summary>
    /// <param name="argument"></param>
    /// <returns><see cref="ResponsibilityChainHandler"/> element or <see cref="null"/> if argument does not pass</returns>
    public ResponsibilityChainHandler? GetChain(TArgument argument);
}