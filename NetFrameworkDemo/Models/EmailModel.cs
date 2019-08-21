using System.Collections.Generic;

namespace NetFrameworkDemo.Models
{
    public class EmailModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> FavoriteColors { get; set; }
    }
}