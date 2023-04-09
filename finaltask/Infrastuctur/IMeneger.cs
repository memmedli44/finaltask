namespace Home_Project.Infrastuctur
{
    public interface IMeneger <T>
    {
        void Add(T item);

        void GetAll(T item);

        void Edit(T item);
        
        void Remove(T item);
        void Exit(T item);

        T getbyid(int id);
        T[] FindByName(string name);
    }
}
