using Unity.TDD.Abstracts.Inputs;

namespace Unity.TDD.Abstracts.Controller
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; set; }
    }
}