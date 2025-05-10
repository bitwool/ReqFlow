namespace ReqFlow.Core.Entities;

public class ApiDefinitionEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public String Method { get; set; }
}