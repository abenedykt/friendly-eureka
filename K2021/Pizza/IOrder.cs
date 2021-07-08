namespace Pizza
{
    public interface IOrder
    {
        void Add(IOrderItem orderItem);
        bool IsValid();
        void Remove(int index);
    }
}