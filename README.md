# TAP recipe: .Net 7 with externalised configuration

This repository is used as a playground to experiment with Tanzu Application Platform (TAP) and externalise configuration for a 
.Net application.

## TODOs

- [x] Setup two basic workloads, a consumer and a provider (for now independent)
- [ ] Integrates consumer and provider (hardcoded configuration)
- [ ] Externalise consumer configuration
    - [ ] Leverage SteelToe configuration extensions to read from Kubernetes ConfigMaps and Secrets
    - [ ] Setup a Spring Config Server and leverage SteelToe configuration extensions to read from it
