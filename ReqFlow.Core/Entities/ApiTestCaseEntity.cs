namespace ReqFlow.Core.Entities;

public class ApiTestCaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public Guid ApiDefinitionId { get; set; }
}