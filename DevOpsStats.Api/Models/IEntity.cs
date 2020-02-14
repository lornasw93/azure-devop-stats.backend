namespace DevOpsStats.Api.Models
{
    public interface IEntity : IEntity<int> { }

    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
