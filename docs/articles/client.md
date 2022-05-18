# Client-side C# module

> [!WARNING]
> C# client-side module cannot be used in production yet.<br>
> The module **is still in development**, and can be released regardless of alt:V updates.<br>

Until the C# client-side module is publicly released in order to use it you need to:
* Have debug enabled (`debug: true` in altv.cfg)
* Have sandboxing disabled (`disableRestrictedSandbox: true` in altv.cfg)

> [!CAUTION]
> Beware that disabled sandboxing gives server a full access to your personal data.<br>
> Only join your own servers with sandboxing disabled.

You need the following requirements to develop resources for the c# module:

* Latest [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0).

## Next steps

Check out [Create resource](getting-started/create-resource.md) to create a C# client resource