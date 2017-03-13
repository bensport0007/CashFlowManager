namespace FluentNHibernateSQLiteCSharp.Entities.Interfaces
{
    internal interface IPost
    {
        string Description { get; }
        int Id { get; }
        int Number { get; }
    }
}