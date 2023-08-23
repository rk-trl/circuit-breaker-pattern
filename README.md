# Resilient Circuit-Breaker-Pattern
It will break the circuit for provided seconds if anything fail (i.e) it wont keep on retry on error scenario

* Microsoft.Extensions.Http.Polly - Nuget package needs to be added

* In Configure services, on configuring httpclient, can mention Http Error Policy

Ref: https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-circuit-breaker-pattern
