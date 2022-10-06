using OpenHumanTask.Sdk.Services.FluentBuilders;

namespace OpenHumanTask.Sdk.UnitTests.Data
{

    internal static class HumanTaskDefinitionFactory
    {

        internal static HumanTaskDefinition Create()
        {
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
                //.AddOutcome("fake-outcome", outcome =>
                //    outcome
                //        .When("${ $CONTEXT.form.data.reviewed }")
                //        .SetLocalizedOutcome("en", "fake-en-value")
                //        .SetLocalizedOutcome("fr", "fake-fr-value"))
                //.UseForm(form => )
                .UseStartDeadline(deadline =>
                    deadline
                        .ElapsesAfter(TimeSpan.FromMinutes(30))
                        .Escalates(escalation =>
                            escalation.ReassignTask()))
                .UseCompletionDeadline(deadline =>
                    deadline
                        .ElapsesAt(new(2023, 4, 4, 12, 30, 00, TimeSpan.Zero))
                        .Escalates(escalation =>
                            escalation
                                .CreateSubtask(subtask =>
                                    subtask
                                        .WithDefinition("fake-namespace.fake-other-task:1.0.0-unitTest")
                                        .WithInput(new { fakeProperty = "fake-value" }))))
                //.AddSubtask(subtask => 
                //    subtask.WithDefinition("fake-namespace.fake-other-task:1.5.1-unitTest"))
                .Build();
            return new();
        }

    }

}
