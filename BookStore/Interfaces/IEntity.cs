namespace BookStore.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}