using Home_Project.DataModel;
using Home_Project.Infrastuctur;
using System.Collections;

namespace Home_Project.Meneger
{
    [Serializable]

    public class AuthorMeneger : IMeneger<Author>, IEnumerable<Author>
    {
        Author[] data = new Author[0];
        public void Add(Author item)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = item;
        }

        public void Edit(Author item)
        {
            var index = Array.IndexOf(data, item);
            if (index == -1)
            {
                return;
            }
            var found = data[index];
            found.Name = item.Name;    
        }

        public void GetAll(Author item)
        {
            throw new NotImplementedException();
        }

        public Author this[int index] 
        {
            get
            { 
                return data[index];
            }
      
        }
        public void Remove(Author item)
        {
            int index=Array.IndexOf(data, item);
            if (index == -1)
            {
                return;
            }
                int len=data.Length-1;
                for (int i = index; i < len; i++)
                {
                    data[i] = data[i+1];
                }
                Array.Resize(ref data, len);
            
        }

        public IEnumerator<Author> GetEnumerator()
        {
            foreach (Author item in data)
            {
                yield return item;
            }
        }

        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Author getbyid(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }

        public void Exit(Author item)
        {
            Console.WriteLine("Cixish ucun her hansi duymeni sixin!");
            Console.ReadKey();
        }

        public Author[] FindByName(string name)
        {
           return Array.FindAll(data, item => item.Name.StartsWith( name));
        }
    }
}
