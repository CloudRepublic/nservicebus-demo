# NServicebus Demo
This repo contains a demo for the Particular Platform, including NServiceBus, Service Pulse and Service Insight.

## Demo
- A customer requests approval
- In parralel the
  - finance department performs a credit check
  - The legal department performs a background check
  - A timeout is registered
- If all checks are ok then all departments are updated.
- If all checks are not ok then the account management department is notified

## Start
- Make sure that you have an NServiceBus license
- Select all projects as startup, except the messages project
- Start and press enter in the front-end
