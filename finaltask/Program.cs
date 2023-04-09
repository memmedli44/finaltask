using Home_Project.DataModel;
using Home_Project.Enums;
using Home_Project.genre;
using Home_Project.Helpers;
using Home_Project.Meneger;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace Home_Project
{
    internal class Program
    {
        const string databaseFile = "database.dat";
        static void Main(string[] args)

        {

            //PrintMenu();

            //return
            AuthorMeneger authormeneger = new AuthorMeneger();
            BookMeneger bookmeneger = new BookMeneger();
            int id = 0;
            Book book;
            Console.WriteLine("### Edeceyiniz emeliyyati daxil edin ###");
            var selectMenu = Helper.ReadEnum<MenuType>("Menu:");

        l1:
            switch (selectMenu)
            {
                case MenuType.AuthorAdd:
                    Console.Clear();
                    var author = new Author();
                    author.Name = Helper.ReadString("Muellifin adi:");
                    author.Surname = Helper.ReadString("Muellifin Soyadi:");
                    authormeneger.Add(author);

                    Console.WriteLine("### Edeceyiniz emeliyyati daxil edin ###");
                    selectMenu = Helper.ReadEnum<MenuType>("Menu:");
                    goto l1;
                case MenuType.AuthorEdit:
                    Console.Clear();
                    Console.WriteLine("Redakte etmek istediyiniz muellifi secin");
                    foreach (var item in authormeneger)
                    {
                        Console.WriteLine(item);

                    }
                    id = Helper.ReadInt("Muellifin Id-si:");
                    if (id == 0)
                    {
                        Console.WriteLine("### Edeceyiniz emeliyyati daxil edin ###");
                        selectMenu = Helper.ReadEnum<MenuType>("Menu:");

                        goto l1;

                    }
                    author = authormeneger.getbyid(id);
                    if (author == null)
                    {
                        Console.Clear();
                        goto case MenuType.AuthorEdit;

                    }
                    author.Name = Helper.ReadString("Muellifin adi:");
                    author.Surname = Helper.ReadString("Muellifin Soyadi:");
                    Console.Clear();
                    goto case MenuType.AuthorGetAll;



                case MenuType.AuthorRemove:
                    Console.Clear();
                    Console.WriteLine("Silmek istediyiniz muellifi secin");
                    foreach (var item in authormeneger)
                    {
                        Console.WriteLine(item);

                    }

                    id = Helper.ReadInteger("Author Id:", true, authormeneger.Min(x => x.Id), authormeneger.Max(x => x.Id));

                    author = authormeneger.getbyid(id);
                    if (author == null)
                    {
                        Console.Clear();
                        goto case MenuType.AuthorRemove;


                    }
                    authormeneger.Remove(author);
                    Console.Clear();
                    goto case MenuType.AuthorGetAll;




                case MenuType.AuthorGetAll:
                    Console.Clear();
                    foreach (var item in authormeneger)
                    {
                        Console.WriteLine(item);

                    }
                    Console.WriteLine("### Edeceyiniz emeliyyati daxil edin ###");
                    selectMenu = Helper.ReadEnum<MenuType>("Menu:");

                    goto l1;
                case MenuType.AuthorFindbyName:
                    break;
                case MenuType.AuthorGetbyId:
                    id = Helper.ReadInt("Axtardiginiz Sira nomresini daxil edin:");
                    if (id == 0)
                    {
                        Console.WriteLine("### Edeceyiniz emeliyyati daxil edin ###");
                        selectMenu = Helper.ReadEnum<MenuType>("Menu:");

                        goto l1;

                    }
                    author = authormeneger.getbyid(id);

                    if (author == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Muellif tapilmadi...");
                        goto case MenuType.AuthorGetbyId;


                    }
                    Console.WriteLine(author);
                    goto l1;
                case MenuType.BookAdd:

                    Console.Clear();

                    foreach (var item in authormeneger)
                    {
                        Console.WriteLine($"{item.Id}:{item.Name}{item.Surname}");
                    }
                l5:
                    id = Helper.ReadInteger("Author Id:", true, authormeneger.Min(x => x.Id), authormeneger.Max(x => x.Id));

                    if (id == 0)
                    {
                        goto l5;
                    }


                    book = new Book();
                    book.Authorld = id;
                    book.Genre = Helper.ReadEnum<Genre>("Janri Secin:");
                    book.Name = Helper.ReadString("Kitabin adi:");
                    book.PageCount = Helper.ReadInt("Kitabin Sehife sayi");
                    book.Price = Helper.ReadDecimal("kitabin Qiymeti:");

                    bookmeneger.Add(book);
                    Console.WriteLine("### Edeceyiniz emeliyyati daxil edin ###");
                    selectMenu = Helper.ReadEnum<MenuType>("Menu:");
                    goto l1;
                case MenuType.BookEdit:
                    Console.WriteLine("Redakte etmek istediyiniz kitabi secin");
                    foreach (var item in bookmeneger)
                    {
                        Console.WriteLine(item);

                    }
                    id = Helper.ReadInt("Muellif ID");
                    book = bookmeneger.getbyid(id);
                    if (book == null)
                    {
                        Console.Clear();
                        goto case MenuType.BookEdit;

                    }
                    book.Name = Helper.ReadString("Kitabin adi:");
                    Console.Clear();
                    goto case MenuType.BookGetAll;


                case MenuType.BookRemove:
                    Console.WriteLine("Silmek istediyiniz Kitabi secin");
                    foreach (var item in bookmeneger)
                    {
                        Console.WriteLine(item);

                    }
                    id = Helper.ReadInt("Kitabin Id-si");
                    book = bookmeneger.getbyid(id);
                    if (book == null)
                    {
                        Console.Clear();
                        goto case MenuType.BookRemove;


                    }
                    bookmeneger.Remove(book);
                    Console.Clear();
                    goto case MenuType.BookGetAll;

                case MenuType.BookGetAll:
                    Console.Clear();
                    foreach (var item in bookmeneger)
                    {
                        var aut = authormeneger.First(x => x.Id == item.Id);
                        Console.WriteLine($"{item} \n Muellifin adi-{aut.Name} \n Muellifin soyadi {aut.Surname}");

                    }
                    Console.WriteLine("### Edeceyiniz emeliyyati daxil edin ###");
                    selectMenu = Helper.ReadEnum<MenuType>("Menu:");
                    goto l1;
                case MenuType.BookFindbyName:
                    string name = Helper.ReadString("Axtardiginiz adi daxil edin:");
                    var data = bookmeneger.FindByName(name);
                    if (data.Length == 0)
                    {
                        Console.WriteLine("Tapilmadi");
                    }
                    foreach (var item in data)
                    {
                        Console.WriteLine(item);
                    }
                    goto l1;
                case MenuType.BookGetbyId:
                    id = Helper.ReadInt("kitabin adi");
                    if (id == 0)
                    {
                        Console.WriteLine("### Edeceyiniz emeliyyati daxil edin ###");
                        selectMenu = Helper.ReadEnum<MenuType>("Menu:");

                        goto l1;

                    }
                    book = bookmeneger.getbyid(id);

                    if (book == null)
                    {
                        Console.Clear();
                        Console.WriteLine("kitabin tapilmadi...");
                        goto case MenuType.BookGetbyId;


                    }
                    Console.WriteLine(book);
                    goto l1;
                case MenuType.SaveandExit:
                    DataBase db = new DataBase();
                    db.kitab = bookmeneger;
                    db.Yazar = authormeneger;
                    FileStream fileStream = File.Create(databaseFile);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fileStream, db);
                    fileStream.Flush();
                    fileStream.Close();
                    Console.WriteLine("Cixish ucun her hansi duymeni sixin!");
                    Console.ReadKey();
                    break;

                default:

                    break;
            }
        }

    }
}