# circuit-breaker-pattern
It will break the circuit for provided seconds if anything fail (i.e) it wont keep on retry on error scenario

* Microsoft.Extensions.Http.Polly - Nuget package needs to be added

* In Configure services, on configuring httpclient, can mention Http Error Policy
