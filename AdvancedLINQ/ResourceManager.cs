using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ
{
    public class ResourceManager
    {
        public static List<User> LoadUserData()
        {
            List<User> userData = new List<User>();
            var Alan = new User { FirstName = "Alan", LastName = "James", BirthDate = Convert.ToDateTime("03/25/1991"), Points = 13 };
            userData.Add(new User { FirstName = "Alan", LastName = "James", BirthDate = Convert.ToDateTime("03/25/1991"), Points = 10 });
            userData.Add(new User { FirstName = "Joe", LastName = "Smith", BirthDate = Convert.ToDateTime("07/01/1986"), Points = 5 });
            userData.Add(new User { FirstName = "Victoria", LastName = "Frost", BirthDate = Convert.ToDateTime("06/14/1970"), Points = 60 });
            userData.Add(new User { FirstName = "Aria", LastName = "Stark", BirthDate = Convert.ToDateTime("09/12/2003"), Points = 13 });
            userData.Add(new User { FirstName = "Jhoanne", LastName = "Lopez", BirthDate = Convert.ToDateTime("03/25/1991"), Points = 0 });
            userData.Add(new User { FirstName = "shan", LastName = "James", BirthDate = Convert.ToDateTime("03/25/1991"), Points = 0 });

            return userData;
        }

        public static List<Post> LoadBlogsData()
        {
            List<Post> blogData = new List<Post>();

            blogData.Add(new Post { Title = "My story", Description = "I'll tell you intersting details of my story", IsPosted = false, Author = "Alan James" });
            blogData.Add(new Post { Title = "A newsmaker", Description = "A tutorial to write news articles", IsPosted = false, Author = "Joe Smith" });
            blogData.Add(new Post { Title = "The beloved pet", Description = "The story of my pet", IsPosted = false, Author = "Jhoanne Lopez" });
            blogData.Add(new Post { Title = "The beloved pet", Description = "The story of my pet", IsPosted = false, Author = "Jhoanne Lopez" });
            return blogData;
        }
    }
}
