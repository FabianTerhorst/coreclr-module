using Microsoft.CodeAnalysis;

#pragma warning disable RS2008

namespace AltV.Net.Async.CodeGen
{
    public static class Diagnostics
    {
        public static DiagnosticDescriptor AsyncEntityShouldImplementEntity =
            new(
                "ALTV0001",
                "Invalid async entity",
                "Async entity {0} should implement alt:V's entity",
                "AsyncEntity",
                DiagnosticSeverity.Error,
                true
            );
        
        public static DiagnosticDescriptor AsyncEntityInterfacePropertyNotFoundInClass =
            new(
                "ALTV0002",
                "Invalid async entity",
                "Property {0} from interface {1} was not found in class {2}",
                "AsyncEntity",
                DiagnosticSeverity.Error,
                true
            );
        
        public static DiagnosticDescriptor AsyncEntitySetterNotFound =
            new(
                "ALTV0003",
                "Cannot find setter",
                "Setter {0} from interface {1} was not found in class {2}",
                "AsyncEntity",
                DiagnosticSeverity.Error,
                true
            );
        
        public static DiagnosticDescriptor AsyncEntityGetterNotFound =
            new(
                "ALTV0004",
                "Cannot find getter",
                "Getter {0} from interface {1} was not found in class {2}",
                "AsyncEntity",
                DiagnosticSeverity.Error,
                true
            );
        
        public static DiagnosticDescriptor AsyncEntityShouldImplementInterface =
            new(
                "ALTV0005",
                "Invalid async entity",
                "Async entity {0} should implement specified interface {1}",
                "AsyncEntity",
                DiagnosticSeverity.Error,
                true
            );
        
        public static DiagnosticDescriptor AsyncEntityInterfaceMethodNotFoundInClass =
            new(
                "ALTV0006",
                "Invalid async entity",
                "Method {0} from interface {1} was not found in class {2}",
                "AsyncEntity",
                DiagnosticSeverity.Error,
                true
            );
        
        public static DiagnosticDescriptor AsyncEntityClassShouldBePartial =
            new(
                "ALTV0007",
                "Invalid async entity",
                "Async entity class {0} should be declared as partial",
                "AsyncEntity",
                DiagnosticSeverity.Error,
                true
            );
        
        public static DiagnosticDescriptor AsyncEntityInterfaceShouldBePartial =
            new(
                "ALTV0008",
                "Invalid async entity interface",
                "Async entity interface {0} should be declared as partial",
                "AsyncEntity",
                DiagnosticSeverity.Error,
                true
            );
    }
}