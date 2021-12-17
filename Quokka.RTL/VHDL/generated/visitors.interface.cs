using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public interface vhdArchitectureVisitorInterface : vhdVisitorInterface<vhdArchitecture> { }
public interface vhdArchitectureDeclarationsVisitorInterface : vhdVisitorInterface<vhdArchitectureDeclarations> { }
public interface vhdArchitectureImplementationVisitorInterface : vhdVisitorInterface<vhdArchitectureImplementation> { }
public interface vhdArchitectureImplementationBlockVisitorInterface : vhdVisitorInterface<vhdArchitectureImplementationBlock> { }
public interface vhdArrayTypeDeclarationVisitorInterface : vhdVisitorInterface<vhdArrayTypeDeclaration> { }
public interface vhdAttributeVisitorInterface : vhdVisitorInterface<vhdAttribute> { }
public interface vhdCommentVisitorInterface : vhdVisitorInterface<vhdComment> { }
public interface vhdCustomEntityPortVisitorInterface : vhdVisitorInterface<vhdCustomEntityPort> { }
public interface vhdDefaultSignalVisitorInterface : vhdVisitorInterface<vhdDefaultSignal> { }
public interface vhdEntityVisitorInterface : vhdVisitorInterface<vhdEntity> { }
public interface vhdEntityInterfaceVisitorInterface : vhdVisitorInterface<vhdEntityInterface> { }
public interface vhdFileVisitorInterface : vhdVisitorInterface<vhdFile> { }
public interface vhdLibraryReferenceVisitorInterface : vhdVisitorInterface<vhdLibraryReference> { }
public interface vhdLogicSignalVisitorInterface : vhdVisitorInterface<vhdLogicSignal> { }
public interface vhdStandardEntityPortVisitorInterface : vhdVisitorInterface<vhdStandardEntityPort> { }
public interface vhdTextVisitorInterface : vhdVisitorInterface<vhdText> { }
public interface vhdUseVisitorInterface : vhdVisitorInterface<vhdUse> { }
} // Quokka.RTL.VHDL
