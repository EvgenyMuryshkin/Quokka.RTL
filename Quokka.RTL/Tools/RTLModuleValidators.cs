using Microsoft.CodeAnalysis;

namespace Quokka.RTL.Tools
{
    public interface IRTLModuleValidator
    {

    }

    public interface IRTLModuleScheduleValidator : IRTLModuleValidator
    {
        void Validate(SyntaxNode schedule);
    }
}
