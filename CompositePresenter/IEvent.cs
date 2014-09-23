namespace CompositePresenter
{
    public interface IEvent
    {
       
    }

    public interface IEvent<T>
    {
        T EventArgs { get; set; }
    }
}