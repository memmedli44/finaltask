using Home_Project.DataModel;
using Home_Project.Infrastuctur;
using System.Collections;

namespace Home_Project.Meneger
{
    [Serializable]

    public class BookMeneger : IMeneger<Book>, IEnumerable<Book>
    {
        Book[]data=new Book[0];
        public void Add(Book item)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = item;
        }

        public void Edit(Book item)
        {
            var index = Array.IndexOf(data, item);
            if (index == -1)
            {
                return;
            }
            var found = data[index];
            found.Name= item.Name;
            found.Authorld= item.Authorld;
            found.Price= item.Price;
            found.Genre= item.Genre;
        }
        public void GetAll(Book item)
        {
            throw new NotImplementedException();
        }
        public void Remove(Book item)
        {
            int index = Array.IndexOf(data, item);
            if (index == -1)
            {
                
                int len = data.Length - 1;
                for (int i = index; i < len; i++)
                {
                    data[i] = data[i + 1];
                }
                Array.Resize(ref data, len);
            }
        }
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book item in data)
            {
                yield return item;
            }
        }

       

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }

        public Book getbyid(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }

        public void Exit(Book item)
        {
            throw new NotImplementedException();
        }

        public Book[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Name.StartsWith(name));
        }
    }
}
