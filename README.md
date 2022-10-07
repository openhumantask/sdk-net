# Open Human Task Specification<br>NET Software Development Kit

[![contributions welcome](https://img.shields.io/badge/contributions-welcome-green.svg?style=flat)](https://github.com/openhumantask/specification/issues)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://github.com/openhumantask/specification/blob/master/LICENSE)
[<img src="http://img.shields.io/badge/slack-@openhumantask-red?style=social&logo=slack">](https://cloud-native.slack.com/messages/serverless-workflow) 

Provides .NET API/SPI and Model Validation for the [Open Human Task Specification](https://github.com/openhumantask/specification).

With this SDK, you can:

- [x] Read and write human task JSON and YAML definitions
- [x] Programmatically build human task definitions
- [x] Validate human task definitions (both schema and DSL integrity validation)

## Status

| Latest Releases | Conformance to spec version |
| :---: | :---: |
| [0.1.x](https://github.com/openhumantask/sdk-net/releases/) | [v0.1](https://github.com/openhumantask/specification/tree/0.1.x) |

### Getting Started

```bash
dotnet nuget add package OpenHumanTask.Sdk
```

```csharp
services.AddOpenHumanTask();
```

### How to use

#### Building human task definitions programatically

You can build human task definitions programatically using the SDK's fluent builder API exposed by the `HumanTaskDefinitionBuilder`.

```csharp
 var definition = new HumanTaskDefinitionBuilder()
  .WithName("fake-task")
  .WithNamespace("oht.sdk.unit-tests")
  .WithVersion("1.0.0-unitTest")
  .UseSpecVersion("0.1.0")
  .UseExpressionLanguage("jq")
  .UseAutomaticCompletionBehavior("reviewed", complete =>
      complete
          .When("${ $CONTEXT.form.data }")
          .SetOutput(new { fakeProperty = "fake-data" }))
  .Assign(assign => 
      assign
          .ToPotentialOwners(all => 
              all
                  .Users()
                  .WithClaim("role", "clerk"))
          .ToBusinessAdministrators(single =>
              single.User("fake-user@email.com"))
          .ToGroup("fake-group", all =>
              all
                  .Users()
                  .InRole(GenericHumanRole.PotentialOwner))
          .ToNotificationRecipients(all =>
              all
                  .Users()
                  .InGroup("fake-group")))
  .AddOutcome("fake-outcome", outcome =>
      outcome
          .When("${ $CONTEXT.form.data.reviewed }")
          .Outputs("en", "fake-en-value")
          .Outputs("fr", "fake-fr-value"))
  .UseForm(form => 
      form
          .WithData("${ $CONTEXT.inputData }")
          .DisplayUsing(view => 
              view
                  .OfType("jsonform")
                  .WithTemplate("fake-jsonform-template")))
  .UseStartDeadline(deadline =>
      deadline
          .ElapsesAfter(TimeSpan.FromMinutes(30))
          .Escalates(then =>
              then.Reassign()))
  .UseCompletionDeadline(deadline =>
      deadline
          .ElapsesAt(new(2023, 4, 4, 12, 30, 00, TimeSpan.Zero))
          .Escalates(then =>
              then.StartSubtask("fake-subtask-1", subtask =>
                  subtask
                      .WithDefinition("fake-namespace.fake-other-task:1.0.0-unitTest")
                      .WithInput("${ $CONTEXT.form.inputData }"))))
  .AddSubtask("fake-subtask-2", subtask =>
      subtask.WithDefinition("fake-namespace.fake-other-task:1.5.1-unitTest"))
  .AnnotateWith("fake-annotation-key", "fake-annotation-value")
  .Build();
```

YAML output:

```yaml
id: oht.sdk.unit-tests.fake-task:1.0.0-unitTest
name: fake-task
namespace: oht.sdk.unit-tests
version: 1.0.0-unitTest
specVersion: 0.1.0
routingMode: none
expressionLanguage: jq
peopleAssignments:
  potentialOwners:
  - users:
      withClaims:
      - type: role
        value: clerk
  businessAdministrators:
  - user: fake-user@email.com
  notificationRecipients:
  - users:
      inGroup: fake-group
  groups:
  - name: fake-group
    members:
    - users:
        inGenericRole: potentialOwner
form:
  data:
    state: ${ $CONTEXT.inputData }
subtasks:
- name: fake-subtask-2
  task:
    name: fake-other-task:1
    namespace: fake-namespace
subtaskExecutionMode: sequential
deadlines:
- type: start
  elapsesAfter: PT30M
  escalations:
  - action:
      reassignment: {}
- type: completion
  elapsesAt: 2023-04-04T12:30:00.0000000+00:00
  escalations:
  - action:
      subtask:
        name: fake-subtask-1
        task:
          name: fake-other-task:1
          namespace: fake-namespace
        input: ${ $CONTEXT.form.inputData }
completionBehaviors:
- name: reviewed
  type: automatic
  condition: ${ $CONTEXT.form.data }
outcomes:
- name: fake-outcome
  condition: ${ $CONTEXT.form.data.reviewed }
  value:
    fr: fake-fr-value
annotations:
  fake-annotation-key: fake-annotation-value
```

#### Reading human task definitions

```csharp
...
var reader = HumanTaskDefinitionReader.Create();
using(Stream stream = File.OpenRead("human-task.json"))
{
  var definition = reader.Read(stream);
}
...
```
